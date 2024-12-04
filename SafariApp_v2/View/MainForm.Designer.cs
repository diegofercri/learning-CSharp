using System.Windows.Forms;

namespace SafariApp_v2.View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.safariMenu = new System.Windows.Forms.MenuStrip();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moreInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statsContainer = new System.Windows.Forms.GroupBox();
            this.plantStats = new System.Windows.Forms.Label();
            this.gazellesStats = new System.Windows.Forms.Label();
            this.lionStats = new System.Windows.Forms.Label();
            this.safariPanel = new System.Windows.Forms.Panel();
            this.safariMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // safariMenu
            // 
            this.safariMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.safariMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.safariMenu.Location = new System.Drawing.Point(0, 0);
            this.safariMenu.Name = "safariMenu";
            this.safariMenu.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.safariMenu.Size = new System.Drawing.Size(708, 24);
            this.safariMenu.TabIndex = 0;
            this.safariMenu.Text = "safariMenu";
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseToolStripMenuItem,
            this.playToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.functionsToolStripMenuItem.Text = "Functions";
            // this.functionsToolStripMenuItem.Click += new System.EventHandler(this.functionsToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.stepToolStripMenuItem.Text = "Step";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.moreInfoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // moreInfoToolStripMenuItem
            // 
            this.moreInfoToolStripMenuItem.Name = "moreInfoToolStripMenuItem";
            this.moreInfoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.moreInfoToolStripMenuItem.Text = "More Info";
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(173, 95);
            this.stepButton.Margin = new System.Windows.Forms.Padding(5);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(70, 20);
            this.stepButton.TabIndex = 4;
            this.stepButton.Text = "STEP";
            this.stepButton.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(253, 95);
            this.resetButton.Margin = new System.Windows.Forms.Padding(5);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(70, 20);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(93, 95);
            this.stopButton.Margin = new System.Windows.Forms.Padding(5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(70, 20);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(13, 95);
            this.playButton.Margin = new System.Windows.Forms.Padding(5);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(70, 20);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "PLAY";
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statsContainer);
            this.panel1.Location = new System.Drawing.Point(9, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 50);
            this.panel1.TabIndex = 3;
            // 
            // statsContainer
            // 
            this.statsContainer.Controls.Add(this.plantStats);
            this.statsContainer.Controls.Add(this.gazellesStats);
            this.statsContainer.Controls.Add(this.lionStats);
            this.statsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsContainer.Location = new System.Drawing.Point(0, 0);
            this.statsContainer.Margin = new System.Windows.Forms.Padding(2);
            this.statsContainer.Name = "statsContainer";
            this.statsContainer.Padding = new System.Windows.Forms.Padding(2);
            this.statsContainer.Size = new System.Drawing.Size(690, 50);
            this.statsContainer.TabIndex = 0;
            this.statsContainer.TabStop = false;
            this.statsContainer.Text = "Stats:";
            // 
            // plantStats
            // 
            this.plantStats.AutoSize = true;
            this.plantStats.Location = new System.Drawing.Point(183, 23);
            this.plantStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.plantStats.Name = "plantStats";
            this.plantStats.Size = new System.Drawing.Size(39, 13);
            this.plantStats.TabIndex = 2;
            this.plantStats.Text = "Plants:";
            // 
            // gazellesStats
            // 
            this.gazellesStats.AutoSize = true;
            this.gazellesStats.Location = new System.Drawing.Point(81, 23);
            this.gazellesStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gazellesStats.Name = "gazellesStats";
            this.gazellesStats.Size = new System.Drawing.Size(50, 13);
            this.gazellesStats.TabIndex = 1;
            this.gazellesStats.Text = "Gazelles:";
            // 
            // lionStats
            // 
            this.lionStats.AutoSize = true;
            this.lionStats.Location = new System.Drawing.Point(6, 23);
            this.lionStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lionStats.Name = "lionStats";
            this.lionStats.Size = new System.Drawing.Size(33, 13);
            this.lionStats.TabIndex = 0;
            this.lionStats.Text = "Lion: ";
            // 
            // panelSafari
            // 
            this.safariPanel.Location = new System.Drawing.Point(9, 122);
            this.safariPanel.Margin = new System.Windows.Forms.Padding(2);
            this.safariPanel.Name = "panelSafari";
            this.safariPanel.Size = new System.Drawing.Size(690, 452);
            this.safariPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 585);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.safariMenu);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.safariPanel);
            this.MainMenuStrip = this.safariMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.safariMenu.ResumeLayout(false);
            this.safariMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statsContainer.ResumeLayout(false);
            this.statsContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MenuStrip safariMenu;
        private ToolStripMenuItem functionsToolStripMenuItem;
        private ToolStripMenuItem stepToolStripMenuItem;
        private ToolStripMenuItem pauseToolStripMenuItem;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem moreInfoToolStripMenuItem;
        private Button stepButton;
        private Button resetButton;
        private Button stopButton;
        private Button playButton;
        private Panel panel1;
        private GroupBox statsContainer;
        private Label plantStats;
        private Label gazellesStats;
        private Label lionStats;
        private Panel safariPanel;
    }
}
