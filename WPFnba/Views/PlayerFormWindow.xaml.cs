using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WPFnba.View
{
    /// <summary>
    /// Interaction logic for PlayerFormWindow.xaml
    /// </summary>
    public partial class PlayerFormWindow : Window
    {
        private PlayerController _playerController; // Instance of the controller to manage data logic
        private DataRow playerRow; // Stores the selected player row for updating

        /// <summary>
        /// Constructor to initialize the form with player data.
        /// </summary>
        /// <param name="playerController">The player controller instance.</param>
        /// <param name="playerData">The DataTable containing player data.</param>
        public PlayerFormWindow(PlayerController playerController, DataTable playerData)
        {
            InitializeComponent(); // Initializes the window components

            if (playerData == null || playerData.Rows.Count == 0)
            {
                MessageBox.Show("No valid data provided for the player.");
                this.Close(); // Closes the window if no valid data is provided
                return;
            }

            // Assign the controller instance
            _playerController = playerController;

            // Get the first row from the DataTable (assuming there's only one player)
            playerRow = playerData.Rows[0];

            // Load player data into the UI fields
            this.PlayerPhoto_tbox.Text = playerRow["headShotUrl"]?.ToString() ?? string.Empty; // Player photo URL
            this.PlayerFirstName_tbox.Text = playerRow["firstName"]?.ToString() ?? string.Empty; // Player's first name
            this.PlayerLastName_tbox.Text = playerRow["lastName"]?.ToString() ?? string.Empty; // Player's last name
            this.PlayerTeam_tbox.Text = playerRow["team"]?.ToString() ?? string.Empty; // Player's team
            this.PlayerPosition_tbox.Text = playerRow["position"]?.ToString() ?? string.Empty; // Player's position
            this.PlayerJerseyNumber_tbox.Text = playerRow["jerseyNumber"]?.ToString() ?? string.Empty; // Player's jersey number
            this.PlayerAge_tbox.Text = playerRow["age"]?.ToString() ?? string.Empty; // Player's age
            this.PlayerDateOfBirth_tbox.Text = playerRow["dateOfBirth"]?.ToString() ?? string.Empty; // Player's date of birth
            this.PlayerHeight_tbox.Text = playerRow["height"]?.ToString() ?? string.Empty; // Player's height
            this.PlayerWeight_tbox.Text = playerRow["weight"]?.ToString() ?? string.Empty; // Player's weight
            this.PlayerPoints_tbox.Text = playerRow["careerPoints"]?.ToString() ?? string.Empty; // Career points
            this.PlayerBlocks_tbox.Text = playerRow["careerBlocks"]?.ToString() ?? string.Empty; // Career blocks
            this.PlayerAssists_tbox.Text = playerRow["careerAssists"]?.ToString() ?? string.Empty; // Career assists
            this.PlayerRebounds_tbox.Text = playerRow["careerRebounds"]?.ToString() ?? string.Empty; // Career rebounds
            this.PlayerTurnovers_tbox.Text = playerRow["careerTurnovers"]?.ToString() ?? string.Empty; // Career turnovers
            this.PlayerThree_tbox.Text = playerRow["careerPercentageThree"]?.ToString() ?? string.Empty; // Three-point percentage
            this.PlayerFreethrow_tbox.Text = playerRow["careerPercentageFreethrow"]?.ToString() ?? string.Empty; // Free throw percentage
            this.PlayerFieldGoal_tbox.Text = playerRow["careerPercentageFieldGoal"]?.ToString() ?? string.Empty; // Field goal percentage
        }

        /// <summary>
        /// Handles the save event to update player data in the database.
        /// </summary>
        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are going to modify a record. Are you sure?"); // Confirmation message

            if (playerRow == null)
            {
                MessageBox.Show("Player data is not available.");
                return;
            }

            try
            {
                // Extract the ID and last updated time from the DataTable
                int id = Convert.ToInt32(playerRow["id"]); // Player ID
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time

                // Create a list with the updated player data
                List<string> updatedPlayerData = new List<string>
                {
                    id.ToString(), // Player ID
                    PlayerFirstName_tbox.Text.Trim(), // First name
                    PlayerLastName_tbox.Text.Trim(), // Last name
                    PlayerTeam_tbox.Text.Trim(), // Team
                    PlayerPosition_tbox.Text.Trim(), // Position
                    PlayerDateOfBirth_tbox.Text.Trim(), // Date of birth
                    PlayerHeight_tbox.Text.Trim(), // Height
                    PlayerWeight_tbox.Text.Trim(), // Weight
                    PlayerJerseyNumber_tbox.Text.Trim(), // Jersey number
                    PlayerAge_tbox.Text.Trim(), // Age
                    PlayerPoints_tbox.Text.Trim(), // Career points
                    PlayerBlocks_tbox.Text.Trim(), // Career blocks
                    PlayerAssists_tbox.Text.Trim(), // Career assists
                    PlayerRebounds_tbox.Text.Trim(), // Career rebounds
                    PlayerTurnovers_tbox.Text.Trim(), // Career turnovers
                    PlayerThree_tbox.Text.Trim(), // Three-point percentage
                    PlayerFreethrow_tbox.Text.Trim(), // Free throw percentage
                    PlayerFieldGoal_tbox.Text.Trim(), // Field goal percentage
                    PlayerPhoto_tbox.Text.Trim(), // Photo URL
                    dateLastUpdated // Last updated time
                };

                // Call the controller method to update the data in the database
                bool success = _playerController.UpdatePlayer(updatedPlayerData);

                if (success) // Check if an error occurred during the update
                {
                    MessageBox.Show("The update was successful.");
                    this.Close(); // Close the window after the update
                }
                else
                {
                    MessageBox.Show("An error occurred during the update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing data: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the cancel event to close the window without making changes.
        /// </summary>
        private void Cancel_Event(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window without making any modifications
        }
    }
}