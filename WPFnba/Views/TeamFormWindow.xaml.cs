using System.Collections.Generic;
using System;
using System.Data;
using System.Windows;

namespace WPFnba.View
{
    /// <summary>
    /// Interaction logic for TeamFormWindow.xaml
    /// </summary>
    public partial class TeamFormWindow : Window
    {
        private TeamController _teamController; // Instance of the controller to manage data logic
        private DataRow teamRow; // Stores the selected team row for updating

        /// <summary>
        /// Constructor to initialize the form with team data.
        /// </summary>
        /// <param name="teamController">The team controller instance.</param>
        /// <param name="teamData">The DataTable containing team data.</param>
        public TeamFormWindow(TeamController teamController, DataTable teamData)
        {
            InitializeComponent(); // Initializes the window components

            if (teamData == null || teamData.Rows.Count == 0)
            {
                MessageBox.Show("No valid data provided for the team.");
                this.Close(); // Closes the window if no valid data is provided
                return;
            }

            // Assign the controller instance
            _teamController = teamController;

            // Get the first row from the DataTable (assuming there's only one team)
            teamRow = teamData.Rows[0];

            // Load team data into the UI fields
            this.TeamLogo_tbox.Text = teamRow["teamLogoUrl"]?.ToString() ?? string.Empty; // Team logo URL
            this.TeamName_tbox.Text = teamRow["name"]?.ToString() ?? string.Empty; // Team name
            this.TeamConference_tbox.Text = teamRow["conference"]?.ToString() ?? string.Empty; // Team conference
            this.TeamRecord_tbox.Text = teamRow["record"]?.ToString() ?? string.Empty; // Team record
        }

        /// <summary>
        /// Handles the save event to update team data in the database.
        /// </summary>
        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are going to modify a record. Are you sure?"); // Confirmation message

            if (teamRow == null)
            {
                MessageBox.Show("Team data is not available.");
                return;
            }

            try
            {
                // Extract the ID and last updated time from the DataTable
                int id = Convert.ToInt32(teamRow["id"]); // Team ID
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Current date and time

                // Create a list with the updated team data
                List<string> updatedTeamData = new List<string>
                {
                    id.ToString(), // Team ID
                    TeamName_tbox.Text.Trim(), // Team name
                    TeamConference_tbox.Text.Trim(), // Team conference
                    TeamRecord_tbox.Text.Trim(), // Team record
                    TeamLogo_tbox.Text.Trim(), // Team logo URL
                    dateLastUpdated // Last updated time
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