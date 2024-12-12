using SafariApp_v2.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SafariApp_v2.View
{
    /// <summary>
    /// Main form for the safari simulation application. Displays the safari grid and statistics.
    /// </summary>
    public partial class MainForm : Form
    {
        // Variables
        private SafariController controller; // Reference to the controller that manages the safari simulation
        private DataGridView beingsGrid; // DataGridView used to display the safari entities (Lions, Gazelles, Plants)

        // Constructor
        /// <summary>
        /// Initializes the main form with the given controller and subscribes to the ModelUpdated event.
        /// </summary>
        /// <param name="controller">The SafariController that manages the safari simulation</param>
        internal MainForm(SafariController controller)
        {
            InitializeComponent();
            this.controller = controller; // Set the controller
            InitializeDataGridView(); // Initialize the DataGridView to display safari entities

            // Subscribe to the ModelUpdated event to update the grid when the model changes
            controller.ModelUpdated += UpdateBeingsGrid;
        }

        // Methods
        /// <summary>
        /// Initializes the DataGridView to display the safari entities in a grid layout.
        /// </summary>
        private void InitializeDataGridView()
        {
            beingsGrid = new DataGridView
            {
                Dock = DockStyle.Fill, // Make the DataGridView fill the entire safariPanel
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Adjust columns to fill the available space
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells, // Automatically size rows based on content
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeColumns = false,
                RowHeadersVisible = false,
                ColumnHeadersVisible = false,
                BorderStyle = BorderStyle.None
            };

            // Subscribe to the CellFormatting event to customize the cell appearance based on content
            beingsGrid.CellFormatting += BeingsGrid_CellFormatting;

            // Add the DataGridView to the safariPanel (this will display the grid in the form)
            safariPanel.Controls.Add(beingsGrid);
        }

        /// <summary>
        /// Handles the form's Load event to initialize the grid and display the initial statistics.
        /// </summary>
        /// <param name="sender">The object that is raising the event (Form)</param>
        /// <param name="e">Event arguments for the Load event</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateBeingsGrid(); // Update the grid with current data from the controller
            UpdateStats(); // Load initial stats data
        }

        /// <summary>
        /// Customizes the cell appearance based on the entity type (Plant, Gazelle, Lion, Empty).
        /// </summary>
        /// <param name="sender">The object that is raising the event (DataGridView)</param>
        /// <param name="e">Event arguments that contain the cell formatting details</param>
        private void BeingsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return; // If the cell is empty, do nothing

            string cellValue = e.Value.ToString();

            // Set the cell's background and foreground color based on the entity type
            if (cellValue == "Plant")
            {
                e.CellStyle.BackColor = Color.Green;
                e.CellStyle.ForeColor = Color.White;
            }
            else if (cellValue == "Gazelle")
            {
                e.CellStyle.BackColor = Color.Brown;
                e.CellStyle.ForeColor = Color.White;
            }
            else if (cellValue == "Lion")
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Updates the grid with the current entities in the safari (Lions, Gazelles, Plants).
        /// </summary>
        public void UpdateBeingsGrid()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateBeingsGrid));
                return; // Ensure thread safety when updating UI elements
            }

            var beings = controller.getBeings();

            beingsGrid.Rows.Clear(); // Clear rows
            beingsGrid.Columns.Clear(); // Clear columns

            int rows = beings.GetLength(0); // Get the number of rows (height of the safari)
            int cols = beings.GetLength(1); // Get the number of columns (width of the safari)

            // Add columns to the DataGridView dynamically based on the safari's width
            for (int col = 0; col < cols; col++)
            {
                beingsGrid.Columns.Add($"Col{col}", "");
            }

            beingsGrid.RowTemplate.Height = safariPanel.Height / rows; // Set the row height proportionally to fit in the panel

            // Populate the grid with the current data
            for (int row = 0; row < rows; row++)
            {
                var rowData = new object[cols];
                for (int col = 0; col < cols; col++)
                {
                    // Set the cell value
                    rowData[col] = beings[row, col];
                }
                beingsGrid.Rows.Add(rowData); // Add the row data to the grid
            }

            // Refresh the statistics display
            UpdateStats();
        }

        /// <summary>
        /// Updates the statistics labels with the current data from the controller (number of Lions, Gazelles, Plants, Turn).
        /// </summary>
        private void UpdateStats()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateStats));
                return; // Ensure thread safety when updating UI elements
            }

            // Update the stats labels
            lionStats.Text = $"Lions: {controller.GetNumLionsAlive()}";
            gazellesStats.Text = $"Gazelles: {controller.GetNumGazellesAlive()}";
            plantStats.Text = $"Plants: {controller.GetNumPlantsAlive()}";
            turnStats.Text = $"Turn: {controller.GetTurn()}";
        }

        /// <summary>
        /// Handles the Play button click event. Starts the safari simulation.
        /// </summary>
        /// <param name="sender">The object that raised the event (Button)</param>
        /// <param name="e">Event arguments for the click event</param>
        private void playButton_Click(object sender, EventArgs e)
        {
            controller.playSafari(); // Call the controller to auto play the safari
        }

        /// <summary>
        /// Handles the Stop button click event. Stops the safari simulation.
        /// </summary>
        /// <param name="sender">The object that raised the event (Button)</param>
        /// <param name="e">Event arguments for the click event</param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            controller.stopSafari(); // Call the controller to stop the safari
        }

        /// <summary>
        /// Handles the Step button click event. Advances the safari simulation by one step.
        /// </summary>
        /// <param name="sender">The object that raised the event (Button)</param>
        /// <param name="e">Event arguments for the click event</param>
        private void stepButton_Click(object sender, EventArgs e)
        {
            controller.stepSafari(); // Call the controller to advance one step in the simulation
        }

        /// <summary>
        /// Handles the Reset button click event. Resets the safari simulation.
        /// </summary>
        /// <param name="sender">The object that raised the event (Button)</param>
        /// <param name="e">Event arguments for the click event</param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            controller.resetSafari(); // Call the controller to reset the safari simulation
        }
    }
}
