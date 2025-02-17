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

        internal void LoadPlayerPhoto(int playerId)
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

        internal void LoadPlayerData(int playerId)
        {
            // Examen 3
            // Obtener los datos del jugador desde el controlador
            string photoUrl = _playerController.GetPlayerPhoto(playerId);

            if (!string.IsNullOrEmpty(photoUrl))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(photoUrl, UriKind.Absolute);
                    bitmap.EndInit();
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

            // Obtener los datos del jugador desde el controlador
            DataTable playerData = _playerController.GetPlayerData(playerId);

            if (playerData is null || playerData.Rows.Count == 0)
            {
                MessageBox.Show("An error has occurred while trying to load player data.");
                return;
            }

            // Vincular los datos del jugador al primer DataGrid (PlayerDataTable)
            PlayerDataTable.ItemsSource = playerData.DefaultView;

            // Supongamos que también tienes un método para obtener las estadísticas del jugador
            DataTable playerStats = _playerController.GetPlayerStats(playerId);

            if (playerStats is null || playerStats.Rows.Count == 0)
            {
                MessageBox.Show("An error has occurred while trying to load player stats.");
                return;
            }

            // Vincular las estadísticas del jugador al segundo DataGrid (PlayerStatsTable)
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
                // Abrir la ventana de actualización del equipo y pasar los datos actuales
                TeamFormWindow1 addWindow = new TeamFormWindow1(_teamController);
                addWindow.ShowDialog(); // Mostrar la ventana de actualización como modal

                // Después de actualizar, recargar la lista de equipos para reflejar los cambios
                this.LoadTeams();
            }
            else
            {
                // Abrir la ventana de actualización del equipo y pasar los datos actuales
                PlayerFormWindow1 addWindow = new PlayerFormWindow1(_playerController);
                addWindow.ShowDialog(); // Mostrar la ventana de actualización como modal

                // Después de actualizar, recargar la lista de equipos para reflejar los cambios
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
                // Verificar si se ha seleccionado un equipo en la lista
                if (TeamsList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a team before editing.");
                }
                else
                {
                    // Obtener los datos del equipo desde la base de datos
                    int selectedTeamId = (int)TeamsList.SelectedValue;

                    DataTable teamData = _teamController.GetTeam(selectedTeamId); // Método que devuelve el equipo seleccionado

                    // Verificar si se encontraron datos del equipo
                    if (teamData != null && teamData.Rows.Count > 0)
                    {
                        // Abrir la ventana de actualización del equipo y pasar los datos actuales
                        TeamFormWindow updateWindow = new TeamFormWindow(_teamController, teamData);
                        updateWindow.ShowDialog(); // Mostrar la ventana de actualización como modal

                        // Después de actualizar, recargar la lista de equipos para reflejar los cambios
                        this.LoadTeams();
                    }
                    else
                    {
                        // Mostrar mensaje de error si no se encontraron los datos del equipo
                        MessageBox.Show("No se encontró el equipo seleccionado.");
                    }
                }
            }
            else
            {
                // Verificar si se ha seleccionado un equipo en la lista
                if (TeamPlayersList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a player before editing.");
                }
                else
                {
                    // Obtener los datos del equipo desde la base de datos
                    int selectedPlayerId = (int)TeamPlayersList.SelectedValue;

                    DataTable playerData = _playerController.GetPlayer(selectedPlayerId); // Método que devuelve el equipo seleccionado

                    // Verificar si se encontraron datos del equipo
                    if (playerData != null && playerData.Rows.Count > 0)
                    {
                        // Abrir la ventana de actualización del equipo y pasar los datos actuales
                        PlayerFormWindow updateWindow = new PlayerFormWindow(_playerController, playerData);
                        updateWindow.ShowDialog(); // Mostrar la ventana de actualización como modal

                        // Después de actualizar, recargar la lista de equipos para reflejar los cambios
                        this.LoadTeams();
                    }
                    else
                    {
                        // Mostrar mensaje de error si no se encontraron los datos del equipo
                        MessageBox.Show("No se encontró el jugador seleccionado.");
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
                // Verificar si se ha seleccionado un equipo en la lista
                if (TeamsList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a team before deleting.");
                }
                else
                {
                    // Obtener los datos del equipo desde la base de datos
                    int selectedTeamId = (int)TeamsList.SelectedValue;

                    // Muestra un cuadro de diálogo de confirmación antes de eliminar
                    MessageBoxResult result = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este team?",
                        "Confirmar eliminación",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    // Si el usuario confirma la eliminación, procede a eliminar al jugador
                    if (result == MessageBoxResult.Yes)
                    {
                        // Llama al método del controlador para eliminar el jugador
                        bool success = _teamController.DeleteTeam(selectedTeamId);

                        // Verifica si ocurrió algún error en la eliminación
                        if (success)
                        {
                            MessageBox.Show("Team eliminado correctamente.", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el team", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                            // Después de eliminar, recarga la lista de equipos para reflejar los cambios
                            LoadTeams();
                        }
                    }
                }
            }
            else
            {
                // Verificar si se ha seleccionado un equipo en la lista
                if (TeamPlayersList.SelectedValue is null)
                {
                    MessageBox.Show("You have to select a player before deleting.");
                }
                else
                {
                    // Obtener los datos del equipo desde la base de datos
                    int selectedPlayerId = (int)TeamPlayersList.SelectedValue;

                    // Muestra un cuadro de diálogo de confirmación antes de eliminar
                    MessageBoxResult result = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este jugador?",
                        "Confirmar eliminación",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    // Si el usuario confirma la eliminación, procede a eliminar al jugador
                    if (result == MessageBoxResult.Yes)
                    {
                        // Llama al método del controlador para eliminar el jugador
                        bool success = _teamController.DeleteTeam(selectedPlayerId);

                        // Verifica si ocurrió algún error en la eliminación
                        if (success)
                        {
                            MessageBox.Show("Jugador eliminado correctamente.", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el jugador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                            // Después de eliminar, recarga la lista de equipos para reflejar los cambios
                            LoadTeams();
                        }
                    }
                }
            }
        }

        // Examen 3
        // Search menu event
        private void Search_Event(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the PrintWindow and show it as modal
            SearchFormWindow searchWindow = new SearchFormWindow(_playerController, this);
            searchWindow.ShowDialog();
        }

        // Examen 1
        // Print menu event
        private void Print_Event(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the PrintWindow and show it as modal
            PrintPreviewWindow preview = new PrintPreviewWindow(printView);
            preview.ShowDialog();
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

            // Examen 3
            // Print Shortcut with Ctrl + B
            if (e.Key == Key.B && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Search_Event(sender, e);
            }

            // Examen 1
            // Print Shortcut with Ctrl + P
            if (e.Key == Key.P && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Print_Event(sender, e);
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

            // Salir de la aplicación con Ctrl + Q
            if (e.Key == Key.Q && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Exit_Event(sender, e);
            }
        }
    }
}
