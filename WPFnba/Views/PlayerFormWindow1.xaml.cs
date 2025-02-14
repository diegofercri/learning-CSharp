using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for PlayerFormWindow1.xaml
    /// </summary>
    public partial class PlayerFormWindow1 : Window
    {
        private PlayerController _playerController; // Instance of the controller to manage data logic

        /// <summary>
        /// Constructor to initialize the form for adding a new player.
        /// </summary>
        /// <param name="playerController">The player controller instance.</param>
        public PlayerFormWindow1(PlayerController playerController)
        {
            InitializeComponent(); // Initializes the window components

            // Assign the controller instance
            _playerController = playerController;
        }

        /// <summary>
        /// Handles the save event to add a new player to the database.
        /// </summary>
        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are going to add a record. Are you sure?"); // Confirmation message

            try
            {
                // Extract the ID and last updated time from the DataTable
                int id = 0; // Player ID (will be auto-generated)
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time

                // Create a list with the new player data
                List<string> newPlayerData = new List<string>
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

                // Call the controller method to add the new player to the database
                bool success = _playerController.AddPlayer(newPlayerData);

                if (success) // Check if an error occurred during the addition
                {
                    MessageBox.Show("The player was added successfully.");
                    this.Close(); // Close the window after the addition
                }
                else
                {
                    MessageBox.Show("An error occurred while adding the player.");
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