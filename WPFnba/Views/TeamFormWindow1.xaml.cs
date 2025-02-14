using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for TeamFormWindow1.xaml
    /// </summary>
    public partial class TeamFormWindow1 : Window
    {
        private TeamController _teamController; // Instance of the controller to manage data logic

        /// <summary>
        /// Constructor to initialize the form for adding a new team.
        /// </summary>
        /// <param name="teamController">The team controller instance.</param>
        public TeamFormWindow1(TeamController teamController)
        {
            InitializeComponent(); // Initializes the window components

            // Assign the controller instance
            _teamController = teamController;
        }

        /// <summary>
        /// Handles the save event to add a new team to the database.
        /// </summary>
        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are going to add a record. Are you sure?"); // Confirmation message

            try
            {
                // Extract the ID and last updated time from the DataTable
                int id = 0; // Team ID (will be auto-generated)
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time

                // Create a list with the new team data
                List<string> newTeamData = new List<string>
                {
                    id.ToString(), // Team ID
                    TeamName_tbox.Text.Trim(), // Team name
                    TeamConference_tbox.Text.Trim(), // Team conference
                    TeamRecord_tbox.Text.Trim(), // Team record
                    TeamLogo_tbox.Text.Trim(), // Team logo URL
                    dateLastUpdated // Last updated time
                };

                // Call the controller method to add the new team to the database
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