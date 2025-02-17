using System;
using System.Collections.Generic;
using System.Windows;

namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for TeamFormWindow1.xaml.
    /// This window allows users to add a new team.
    /// </summary>
    public partial class TeamFormWindow1 : Window
    {
        private TeamController _teamController; // Instance of the controller to manage data logic

        /// <summary>
        /// Constructor for the TeamFormWindow1 class.
        /// Initializes the window and assigns the controller instance.
        /// </summary>
        /// <param name="teamController">The controller instance for handling team operations.</param>
        public TeamFormWindow1(TeamController teamController)
        {
            InitializeComponent(); // Initialize the components of the window
            // Assign the controller instance
            _teamController = teamController;
        }

        /// <summary>
        /// Handles the "Save" button click event.
        /// Adds a new team to the database.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are about to add a record. Are you sure?"); // Confirmation message

            try
            {
                // Extract the ID and last updated timestamp
                int id = 0; // Team ID (will be auto-generated)
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time

                // Create a list with the new team's data
                List<string> newTeamData = new List<string>
                {
                    id.ToString(), // Team ID
                    TeamName_tbox.Text.Trim(), // Team name
                    TeamConference_tbox.Text.Trim(), // Team conference
                    TeamRecord_tbox.Text.Trim(), // Team record
                    TeamLogo_tbox.Text.Trim(), // Team logo URL
                    dateLastUpdated // Last updated timestamp
                };

                // Call the controller method to add the team to the database
                bool success = _teamController.AddTeam(newTeamData);

                if (success) // Check if an error occurred during the addition
                {
                    MessageBox.Show("The team was added successfully.");
                    this.Close(); // Close the window after the addition
                }
                else
                {
                    MessageBox.Show("An error occurred while adding the team.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing the data: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the "Cancel" button click event.
        /// Closes the window without making any changes.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void Cancel_Event(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window without making any modifications
        }
    }
}