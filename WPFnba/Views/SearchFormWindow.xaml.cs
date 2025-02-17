using System;
using System.Windows;
using WPFnba.View;

namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for SearchFormWindow.xaml.
    /// This window allows users to search for a player by their last name and load their data in the main window.
    /// </summary>
    public partial class SearchFormWindow : Window
    {
        private PlayerController _playerController; // Instance of the controller to manage data logic
        private MainWindow _mainWindow; // Reference to the main window

        /// <summary>
        /// Constructor for the SearchFormWindow class.
        /// Initializes the window and assigns the controller and main window instances.
        /// </summary>
        /// <param name="playerController">The controller instance for handling player operations.</param>
        /// <param name="mainWindow">The reference to the main window.</param>
        public SearchFormWindow(PlayerController playerController, MainWindow mainWindow)
        {
            InitializeComponent(); // Initialize the components of the window
            // Assign the controller instance
            _playerController = playerController;
            _mainWindow = mainWindow; // Assign the reference to the main window
        }

        /// <summary>
        /// Handles the "Search" button click event.
        /// Searches for a player by their last name and loads their data in the main window.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void Search_Event(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchPlayerData = PlayerLastName_tbox.Text.Trim(); // Last name of the player

                // Call the controller method to retrieve the player's ID by their last name
                int id = _playerController.GetPlayerByLastName(searchPlayerData);

                if (id != -1) // Check if the player was found
                {
                    this.Close(); // Close the window after the search
                    _mainWindow.LoadPlayerData(id); // Load the player's data in the main window
                }
                else
                {
                    MessageBox.Show("Player not found.");
                    this.Close(); // Close the window if the player is not found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while processing data: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the "Cancel" button click event.
        /// Closes the window without performing any action.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void Cancel_Event(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window without making any modifications
        }
    }
}