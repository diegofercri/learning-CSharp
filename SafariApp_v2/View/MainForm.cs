using System;
using System.Windows.Forms;

namespace SafariApp_v2.View
{
    public partial class MainForm : Form
    {
        private Controller.Controller controller; // Controller that handles the logic

        internal MainForm(Controller.Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // Play button click event handler
        private void playButton_Click(object sender, EventArgs e)
        {
            controller.playSafari();
        }

        // Stop button click event handler
        private void stopButton_Click(object sender, EventArgs e)
        {
            controller.stopSafari();
        }

        // Step button click event handler
        private void stepButton_Click(object sender, EventArgs e)
        {
            controller.stepSafari();
        }

        // Reset button click event handler
        private void resetButton_Click(object sender, EventArgs e)
        {
            controller.stopSafari();
        }
    }
}