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
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moreInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.statsContainer = new System.Windows.Forms.GroupBox();
            this.elephantStats = new System.Windows.Forms.Label();
            this.turnStats = new System.Windows.Forms.Label();
            this.plantStats = new System.Windows.Forms.Label();
            this.gazellesStats = new System.Windows.Forms.Label();
            this.lionStats = new System.Windows.Forms.Label();
            this.safariPanel = new System.Windows.Forms.Panel();
            this.play10Button = new System.Windows.Forms.Button();
            this.safariMenu.SuspendLayout();
            this.statsPanel.SuspendLayout();
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
            this.safariMenu.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.safariMenu.Size = new System.Drawing.Size(944, 26);
            this.safariMenu.TabIndex = 0;
            this.safariMenu.Text = "safariMenu";
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.functionsToolStripMenuItem.Text = "Functions";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.moreInfoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(157, 26);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // moreInfoToolStripMenuItem
            // 
            this.moreInfoToolStripMenuItem.Name = "moreInfoToolStripMenuItem";
            this.moreInfoToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.moreInfoToolStripMenuItem.Text = "More Info";
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(338, 117);
            this.stepButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(93, 25);
            this.stepButton.TabIndex = 3;
            this.stepButton.Text = "STEP";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(445, 117);
            this.resetButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(93, 25);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(124, 117);
            this.stopButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(93, 25);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(17, 117);
            this.playButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(93, 25);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "PLAY";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.statsContainer);
            this.statsPanel.Location = new System.Drawing.Point(12, 47);
            this.statsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(920, 62);
            this.statsPanel.TabIndex = 5;
            // 
            // statsContainer
            // 
            this.statsContainer.Controls.Add(this.elephantStats);
            this.statsContainer.Controls.Add(this.turnStats);
            this.statsContainer.Controls.Add(this.plantStats);
            this.statsContainer.Controls.Add(this.gazellesStats);
            this.statsContainer.Controls.Add(this.lionStats);
            this.statsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsContainer.Location = new System.Drawing.Point(0, 0);
            this.statsContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsContainer.Name = "statsContainer";
            this.statsContainer.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statsContainer.Size = new System.Drawing.Size(920, 62);
            this.statsContainer.TabIndex = 0;
            this.statsContainer.TabStop = false;
            this.statsContainer.Text = "Stats:";
            // 
            // elephantStats
            // 
            this.elephantStats.AutoSize = true;
            this.elephantStats.Location = new System.Drawing.Point(240, 28);
            this.elephantStats.Name = "elephantStats";
            this.elephantStats.Size = new System.Drawing.Size(70, 16);
            this.elephantStats.TabIndex = 4;
            this.elephantStats.Text = "Elephants:";
            // 
            // turnStats
            // 
            this.turnStats.AutoSize = true;
            this.turnStats.Location = new System.Drawing.Point(811, 28);
            this.turnStats.Name = "turnStats";
            this.turnStats.Size = new System.Drawing.Size(37, 16);
            this.turnStats.TabIndex = 0;
            this.turnStats.Text = "Turn:";
            // 
            // plantStats
            // 
            this.plantStats.AutoSize = true;
            this.plantStats.Location = new System.Drawing.Point(371, 28);
            this.plantStats.Name = "plantStats";
            this.plantStats.Size = new System.Drawing.Size(47, 16);
            this.plantStats.TabIndex = 1;
            this.plantStats.Text = "Plants:";
            // 
            // gazellesStats
            // 
            this.gazellesStats.AutoSize = true;
            this.gazellesStats.Location = new System.Drawing.Point(108, 28);
            this.gazellesStats.Name = "gazellesStats";
            this.gazellesStats.Size = new System.Drawing.Size(63, 16);
            this.gazellesStats.TabIndex = 2;
            this.gazellesStats.Text = "Gazelles:";
            // 
            // lionStats
            // 
            this.lionStats.AutoSize = true;
            this.lionStats.Location = new System.Drawing.Point(8, 28);
            this.lionStats.Name = "lionStats";
            this.lionStats.Size = new System.Drawing.Size(38, 16);
            this.lionStats.TabIndex = 3;
            this.lionStats.Text = "Lion: ";
            // 
            // safariPanel
            // 
            this.safariPanel.Location = new System.Drawing.Point(12, 150);
            this.safariPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.safariPanel.Name = "safariPanel";
            this.safariPanel.Size = new System.Drawing.Size(920, 556);
            this.safariPanel.TabIndex = 6;
            // 
            // play10Button
            // 
            this.play10Button.Location = new System.Drawing.Point(231, 117);
            this.play10Button.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.play10Button.Name = "play10Button";
            this.play10Button.Size = new System.Drawing.Size(93, 25);
            this.play10Button.TabIndex = 7;
            this.play10Button.Text = "PLAY 10";
            this.play10Button.UseVisualStyleBackColor = true;
            this.play10Button.Click += new System.EventHandler(this.play10Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 720);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.play10Button);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.safariMenu);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.safariPanel);
            this.MainMenuStrip = this.safariMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.safariMenu.ResumeLayout(false);
            this.safariMenu.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.statsContainer.ResumeLayout(false);
            this.statsContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MenuStrip safariMenu;
        private ToolStripMenuItem functionsToolStripMenuItem;
        private ToolStripMenuItem stepToolStripMenuItem;
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
        private Panel statsPanel;
        private GroupBox statsContainer;
        private Label plantStats;
        private Label gazellesStats;
        private Label lionStats;
        private Panel safariPanel;
        private Label turnStats;
        /* Examen 1 */
        private Label elephantStats;
        private Button play10Button;
    }
}
