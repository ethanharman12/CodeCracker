﻿namespace Code2
{
    partial class CodeMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeMain));
            this.Answer1 = new System.Windows.Forms.Label();
            this.Answer2 = new System.Windows.Forms.Label();
            this.Answer3 = new System.Windows.Forms.Label();
            this.Answer4 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.totalGamesPlayedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalTimePlayedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.AverageLabel = new System.Windows.Forms.Label();
            this.SlowLabel = new System.Windows.Forms.Label();
            this.FastLabel = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Answer1
            // 
            this.Answer1.AutoSize = true;
            this.Answer1.BackColor = System.Drawing.Color.Black;
            this.Answer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Answer1.Location = new System.Drawing.Point(554, 75);
            this.Answer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(20, 22);
            this.Answer1.TabIndex = 0;
            this.Answer1.Text = "0";
            // 
            // Answer2
            // 
            this.Answer2.AutoSize = true;
            this.Answer2.BackColor = System.Drawing.Color.Black;
            this.Answer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Answer2.Location = new System.Drawing.Point(554, 120);
            this.Answer2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Answer2.Name = "Answer2";
            this.Answer2.Size = new System.Drawing.Size(20, 22);
            this.Answer2.TabIndex = 1;
            this.Answer2.Text = "0";
            // 
            // Answer3
            // 
            this.Answer3.AutoSize = true;
            this.Answer3.BackColor = System.Drawing.Color.Black;
            this.Answer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Answer3.Location = new System.Drawing.Point(554, 165);
            this.Answer3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Answer3.Name = "Answer3";
            this.Answer3.Size = new System.Drawing.Size(20, 22);
            this.Answer3.TabIndex = 2;
            this.Answer3.Text = "0";
            // 
            // Answer4
            // 
            this.Answer4.AutoSize = true;
            this.Answer4.BackColor = System.Drawing.Color.Black;
            this.Answer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Answer4.Location = new System.Drawing.Point(554, 208);
            this.Answer4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Answer4.Name = "Answer4";
            this.Answer4.Size = new System.Drawing.Size(20, 22);
            this.Answer4.TabIndex = 3;
            this.Answer4.Text = "0";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(519, 251);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(70, 35);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.TabStop = false;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalGamesPlayedToolStripMenuItem,
            this.totalTimePlayedToolStripMenuItem,
            this.averageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(257, 94);
            // 
            // totalGamesPlayedToolStripMenuItem
            // 
            this.totalGamesPlayedToolStripMenuItem.Name = "totalGamesPlayedToolStripMenuItem";
            this.totalGamesPlayedToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.totalGamesPlayedToolStripMenuItem.Text = "Total Games Played: 0";
            // 
            // totalTimePlayedToolStripMenuItem
            // 
            this.totalTimePlayedToolStripMenuItem.Name = "totalTimePlayedToolStripMenuItem";
            this.totalTimePlayedToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.totalTimePlayedToolStripMenuItem.Text = "Total Time Played: 0";
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.averageToolStripMenuItem.Text = "Average: 0";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Code";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(514, 303);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(104, 20);
            this.TimeLabel.TabIndex = 5;
            this.TimeLabel.Text = "Time: 0.00.00";
            this.TimeLabel.Visible = false;
            // 
            // AverageLabel
            // 
            this.AverageLabel.AutoSize = true;
            this.AverageLabel.Location = new System.Drawing.Point(520, 328);
            this.AverageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AverageLabel.Name = "AverageLabel";
            this.AverageLabel.Size = new System.Drawing.Size(97, 20);
            this.AverageLabel.TabIndex = 6;
            this.AverageLabel.Text = "Avg: 0.00.00";
            this.AverageLabel.Visible = false;
            // 
            // SlowLabel
            // 
            this.SlowLabel.AutoSize = true;
            this.SlowLabel.Location = new System.Drawing.Point(627, 328);
            this.SlowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SlowLabel.Name = "SlowLabel";
            this.SlowLabel.Size = new System.Drawing.Size(104, 20);
            this.SlowLabel.TabIndex = 8;
            this.SlowLabel.Text = "Slow: 0.00.00";
            this.SlowLabel.Visible = false;
            // 
            // FastLabel
            // 
            this.FastLabel.AutoSize = true;
            this.FastLabel.Location = new System.Drawing.Point(632, 303);
            this.FastLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FastLabel.Name = "FastLabel";
            this.FastLabel.Size = new System.Drawing.Size(102, 20);
            this.FastLabel.TabIndex = 7;
            this.FastLabel.Text = "Fast: 0.00.00";
            this.FastLabel.Visible = false;
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(597, 251);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(70, 35);
            this.PauseButton.TabIndex = 9;
            this.PauseButton.TabStop = false;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // CodeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 388);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.SlowLabel);
            this.Controls.Add(this.FastLabel);
            this.Controls.Add(this.AverageLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.Answer4);
            this.Controls.Add(this.Answer3);
            this.Controls.Add(this.Answer2);
            this.Controls.Add(this.Answer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CodeMain";
            this.Text = "Code";
            this.Activated += new System.EventHandler(this.CodeMain_Activated);
            this.Deactivate += new System.EventHandler(this.CodeMain_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CodeMain_FormClosed);
            this.Resize += new System.EventHandler(this.CodeMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Answer1;
        private System.Windows.Forms.Label Answer2;
        private System.Windows.Forms.Label Answer3;
        private System.Windows.Forms.Label Answer4;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem totalGamesPlayedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalTimePlayedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label AverageLabel;
        private System.Windows.Forms.Label SlowLabel;
        private System.Windows.Forms.Label FastLabel;
        private System.Windows.Forms.Button PauseButton;
    }
}

