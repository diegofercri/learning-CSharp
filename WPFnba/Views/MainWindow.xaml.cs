using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPFnba.Views;

namespace WPFnba.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PlayerController _playerController;
        private readonly TeamController _teamController;
        private DataTable teams;
        private DataTable teamPlayers;

        public MainWindow()
        {
            InitializeComponent();
            // Instance repositories
            PlayerRepository playerRepository = new PlayerRepository();
            TeamRepository teamRepository = new TeamRepository();
            // Instance controllers
            _playerController = new PlayerController(playerRepository);
            _teamController = new TeamController(teamRepository);
            // Load data
            LoadTeams();
        }

        private void LoadTeams()
        {
            teams = _teamController.GetTeams();
            if (teams is null)
            {
                MessageBox.Show("An error has occurred while trying to load teams.");
                return;
            }
            TeamsList.ItemsSource = teams.DefaultView; // Fill the list with the teams
            TeamsList.SelectedValuePath = "Id"; // Field to use as id
            TeamsList.DisplayMemberPath = "Name"; // Field to show in the list

            if (TeamsList.Items.Count > 0)
            {
                TeamsList.SelectedIndex = 0;
                int selectedTeamId = (int)TeamsList.SelectedValue;
                LoadTeamLogo(selectedTeamId);
                LoadTeamPlayers(selectedTeamId);
            }
            else
            {
                MessageBox.Show("There are no teams to show");
            }
        }

        private void LoadTeamLogo(int teamId)
        {
            if (teams == null)
            {
                MessageBox.Show("An error occurred while trying to load the team logo.");
                return;
            }

            DataRow teamRow = teams.AsEnumerable().FirstOrDefault(row => row.Field<int>("id") == teamId);
            if (teamRow != null)
            {
                string logoUrl = teamRow.Field<string>("teamLogoUrl");
                if (!string.IsNullOrEmpty(logoUrl))
                {
                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(logoUrl, UriKind.Absolute);
                        bitmap.EndInit();
                        TeamLogo.Source = bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading the logo: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("There is no logo for the selected team.");
                }
            }
            else
            {
                MessageBox.Show("The selected team was not found.");
            }
        }

        private void TeamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamsList.SelectedValue != null)
            {
                int selectedTeamId = (int)TeamsList.SelectedValue;
                LoadTeamLogo(selectedTeamId);
                LoadTeamPlayers(selectedTeamId);
            }
        }

        private void LoadTeamPlayers(int teamId)
        {
            teamPlayers = _playerController.GetPlayersByTeam(teamId);
            if (teamPlayers is null)
            {
                MessageBox.Show("An error has occurred while trying to load team players.");
                return;
            }

            // Check if the column already exists
            if (!teamPlayers.Columns.Contains("DisplayName"))
            {
                // Combined column to show Position, FirstName and LastName
                teamPlayers.Columns.Add("DisplayName", typeof(string), "Position + ' -> ' + FirstName + ' ' + LastName");
            }

            TeamPlayersList.ItemsSource = teamPlayers.DefaultView; // Fill the list with the players
            TeamPlayersList.SelectedValuePath = "Id"; // Field to use as id
            TeamPlayersList.DisplayMemberPath = "DisplayName"; // Field to show in the list

            if (TeamPlayersList.Items.Count > 0)
            {
                TeamPlayersList.SelectedIndex = 0;
                int selectedPlayerId = (int)TeamPlayersList.SelectedValue;
                LoadPlayerPhoto(selectedPlayerId);
                LoadPlayerData(selectedPlayerId);
            }
            else
            {
                MessageBox.Show("There are no team players to show");
            }
        }

        private void LoadPlayerPhoto(int playerId)
        {
            if (teamPlayers == null)
            {
                MessageBox.Show("An error occurred while trying to load the player photo.");
                return;
            }

            DataRow teamPlayersRow = teamPlayers.AsEnumerable().FirstOrDefault(row => row.Field<int>("id") == playerId);
            if (teamPlayersRow != null)
            {
                string headShotUrl = teamPlayersRow.Field<string>("headShotUrl");
                if (!string.IsNullOrEmpty(headShotUrl))
                {
                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(headShotUrl, UriKind.Absolute);
                        bitmap.EndInit();
                        PlayerPhoto.Source = bitmap;
                        PlayerPhoto2.Source = bitmap;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading the player photo: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("There is no photo for the selected player.");
                }
            }
            else
            {
                MessageBox.Show("The selected player was not found.");
            }
        }

        private void TeamPlayersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamPlayersList.SelectedValue != null)
            {
                int selectedPlayerId = (int)TeamPlayersList.SelectedValue;
                LoadPlayerPhoto(selectedPlayerId);
                LoadPlayerData(selectedPlayerId);
            }
        }

        private void LoadPlayerData(int playerId)
        {
            // Get the player data from the controller
            DataTable playerData = _playerController.GetPlayerData(playerId);
            if (playerData is null || playerData.Rows.Count == 0)
            {
                MessageBox.Show("An error has occurred while trying to load player data.");
                return;
            }

            // Bind the player data to the first DataGrid (PlayerDataTable)
            PlayerDataTable.ItemsSource = playerData.DefaultView;

            // Assume you also have a method to get the player stats
            DataTable playerStats = _playerController.GetPlayerStats(playerId);
            if (playerStats is null || playerStats.Rows.Count == 0)
            {
                MessageBox.Show("An error has occurred while trying to load player stats.");
                return;
            }

            // Bind the player stats to the second DataGrid (PlayerStatsTable)
            PlayerStatsTable.ItemsSource = playerStats.DefaultView;
        }

        // Add menu event
        private void Add_Event(object sender, RoutedEventArgs e)
        {
            // Get the selected tab
            TabItem selectedTab = TabControl.SelectedItem as TabItem;
            string header = selectedTab.Header.ToString();

            // Call the corresponding method depending on the selected tab
            if (header == "Teams")
            {
                // Open the team add window and pass the current data
                TeamFormWindow1 addWindow = new TeamFormWindow1(_teamController);
                addWindow.ShowDialog(); // Show the update window as modal
                // After updating, reload the team list to reflect the changes
                this.LoadTeams();
            }
            else
            {
                // Open the player add window and pass the current data
                PlayerFormWindow1 addWindow = new PlayerFormWindow1(_playerController);
                addWindow.ShowDialog(); // Show the update window as modal
                // After updating, reload the team list to reflect the changes
                this.LoadTeams();
            }
        }

        // Edit menu event
        private void Edit_Event(object sender, RoutedEventArgs e)
        {
            // Get the selected tab
            TabItem selectedTab = TabControl.SelectedItem as TabItem;
            string header = selectedTab.Header.ToString();

            // Call the corresponding method depending on the selected tab
            if (header == "Teams")
            {
                // Check if a team has been selected in the list
                if (TeamsList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a team before editing.");
                }
                else
                {
                    // Get the team data from the database
                    int selectedTeamId = (int)TeamsList.SelectedValue;
                    DataTable teamData = _teamController.GetTeam(selectedTeamId); // Method that returns the selected team

                    // Check if team data was found
                    if (teamData != null && teamData.Rows.Count > 0)
                    {
                        // Open the team update window and pass the current data
                        TeamFormWindow updateWindow = new TeamFormWindow(_teamController, teamData);
                        updateWindow.ShowDialog(); // Show the update window as modal
                        // After updating, reload the team list to reflect the changes
                        this.LoadTeams();
                    }
                    else
                    {
                        // Show an error message if the team data was not found
                        MessageBox.Show("The selected team was not found.");
                    }
                }
            }
            else
            {
                // Check if a player has been selected in the list
                if (TeamPlayersList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a player before editing.");
                }
                else
                {
                    // Get the player data from the database
                    int selectedPlayerId = (int)TeamPlayersList.SelectedValue;
                    DataTable playerData = _playerController.GetPlayer(selectedPlayerId); // Method that returns the selected player

                    // Check if player data was found
                    if (playerData != null && playerData.Rows.Count > 0)
                    {
                        // Open the player update window and pass the current data
                        PlayerFormWindow updateWindow = new PlayerFormWindow(_playerController, playerData);
                        updateWindow.ShowDialog(); // Show the update window as modal
                        // After updating, reload the team list to reflect the changes
                        this.LoadTeams();
                    }
                    else
                    {
                        // Show an error message if the player data was not found
                        MessageBox.Show("The selected player was not found.");
                    }
                }
            }
        }

        // Delete menu event
        private void Delete_Event(object sender, RoutedEventArgs e)
        {
            // Get the selected tab
            TabItem selectedTab = TabControl.SelectedItem as TabItem;
            string header = selectedTab.Header.ToString();

            // Call the corresponding method depending on the selected tab
            if (header == "Teams")
            {
                // Check if a team has been selected in the list
                if (TeamsList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a team before deleting.");
                }
                else
                {
                    // Get the team data from the database
                    int selectedTeamId = (int)TeamsList.SelectedValue;

                    // Show a confirmation dialog before deleting
                    MessageBoxResult result = MessageBox.Show(
                        "Are you sure you want to delete this team?",
                        "Confirm deletion",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    // If the user confirms the deletion, proceed to delete the team
                    if (result == MessageBoxResult.Yes)
                    {
                        // Call the controller method to delete the team
                        bool success = _teamController.DeleteTeam(selectedTeamId);

                        // Check if any error occurred during deletion
                        if (success)
                        {
                            MessageBox.Show("Team deleted successfully.", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error deleting the team", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        // After deleting, reload the team list to reflect the changes
                        LoadTeams();
                    }
                }
            }
            else
            {
                // Check if a player has been selected in the list
                if (TeamPlayersList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a player before deleting.");
                }
                else
                {
                    // Get the player data from the database
                    int selectedPlayerId = (int)TeamPlayersList.SelectedValue;

                    // Show a confirmation dialog before deleting
                    MessageBoxResult result = MessageBox.Show(
                        "Are you sure you want to delete this player?",
                        "Confirm deletion",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    // If the user confirms the deletion, proceed to delete the player
                    if (result == MessageBoxResult.Yes)
                    {
                        // Call the controller method to delete the player
                        bool success = _playerController.DeletePlayer(selectedPlayerId);

                        // Check if any error occurred during deletion
                        if (success)
                        {
                            MessageBox.Show("Player deleted successfully.", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error deleting the player", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        // After deleting, reload the team list to reflect the changes
                        LoadTeams();
                    }
                }
            }
        }

        // Help menu event
        private void Help_Event(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the HelpWindow and show it as modal
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        // Info menu event
        private void Info_Event(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the InfoWindow and show it as modal
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.ShowDialog();
        }

        // Exit event
        private void Exit_Event(object sender, RoutedEventArgs e)
        {
            // Close the application
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Add Shortcut with Ctrl + A
            if (e.Key == Key.A && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Add_Event(sender, e);
            }

            // Edit Shortcut with Ctrl + E
            if (e.Key == Key.E && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Edit_Event(sender, e);
            }

            // Delete Shortcut with Ctrl + D
            if (e.Key == Key.D && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Delete_Event(sender, e);
            }

            // Help Shortcut with Ctrl + H
            if (e.Key == Key.H && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Help_Event(sender, e);
            }

            // Info Shortcut with Ctrl + I
            if (e.Key == Key.I && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Info_Event(sender, e);
            }

            // Exit the application with Ctrl + Q
            if (e.Key == Key.Q && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Exit_Event(sender, e);
            }
        }
    }
}