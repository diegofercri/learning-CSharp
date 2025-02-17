using System.Collections.Generic;
using System;
using System.Data;
using System.Windows;

namespace WPFnba.View
{
    /// <summary>
    /// Interaction logic for TeamFormWindow.xaml.
    /// This window allows users to view and update team information.
    /// </summary>
    public partial class TeamFormWindow : Window
    {
        private TeamController _teamController; // Instance of the controller to manage data logic
        private DataRow teamRow; // Stores the selected team's row for updates

        /// <summary>
        /// Constructor for the TeamFormWindow class.
        /// Initializes the window and loads team data into the form fields.
        /// </summary>
        /// <param name="teamController">The controller instance for handling team operations.</param>
        /// <param name="teamData">A DataTable containing the team's data to be loaded.</param>
        public TeamFormWindow(TeamController teamController, DataTable teamData)
        {
            InitializeComponent(); // Initialize the components of the window

            if (teamData == null || teamData.Rows.Count == 0)
            {
                MessageBox.Show("No valid team data was provided.");
                this.Close(); // Close the window if no valid data is available
                return;
            }

            // Assign the controller instance
            _teamController = teamController;

            // Get the first row from the DataTable (assuming only one team is passed)
            teamRow = teamData.Rows[0];

            // Load the team's data into the UI fields
            this.TeamLogo_tbox.Text = teamRow["teamLogoUrl"]?.ToString() ?? string.Empty; // Team logo URL
            this.TeamName_tbox.Text = teamRow["name"]?.ToString() ?? string.Empty; // Team name
            this.TeamConference_tbox.Text = teamRow["conference"]?.ToString() ?? string.Empty; // Team conference
            this.TeamRecord_tbox.Text = teamRow["record"]?.ToString() ?? string.Empty; // Team record
        }

        /// <summary>
        /// Handles the "Save" button click event.
        /// Updates the team's data in the database.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are about to modify a record. Are you sure?"); // Confirmation message

            if (teamRow == null)
            {
                MessageBox.Show("Team data is not available.");
                return;
            }

            try
            {
                // Extract the ID and last updated timestamp from the DataTable
                int id = Convert.ToInt32(teamRow["id"]); // Team ID
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time

                // Create a list with the updated data
                List<string> updatedTeamData = new List<string>
                {
                    id.ToString(), // Team ID
                    TeamName_tbox.Text.Trim(), // Team name
                    TeamConference_tbox.Text.Trim(), // Team conference
                    TeamRecord_tbox.Text.Trim(), // Team record
                    TeamLogo_tbox.Text.Trim(), // Team logo URL
                    dateLastUpdated // Last updated timestamp
                };

                // Call the controller method to update the data in the database
                bool success = _teamController.UpdateTeam(updatedTeamData);

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