
namespace Travelers
{
    partial class _SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_SettingsForm));
            this._DisplayGroupBox = new System.Windows.Forms.GroupBox();
            this._UseMultipleMonitorsCheckBox = new System.Windows.Forms.CheckBox();
            this._MonitorComboBox = new System.Windows.Forms.ComboBox();
            this._MonitorLabel = new System.Windows.Forms.Label();
            this._TabControl = new System.Windows.Forms.TabControl();
            this._SettingsTabPage = new System.Windows.Forms.TabPage();
            this._AboutTabPage = new System.Windows.Forms.TabPage();
            this._GitHubPictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this._TravelersFontLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._DisplayGroupBox.SuspendLayout();
            this._TabControl.SuspendLayout();
            this._SettingsTabPage.SuspendLayout();
            this._AboutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GitHubPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _DisplayGroupBox
            // 
            this._DisplayGroupBox.Controls.Add(this._UseMultipleMonitorsCheckBox);
            this._DisplayGroupBox.Controls.Add(this._MonitorComboBox);
            this._DisplayGroupBox.Controls.Add(this._MonitorLabel);
            this._DisplayGroupBox.Location = new System.Drawing.Point(12, 3);
            this._DisplayGroupBox.Name = "_DisplayGroupBox";
            this._DisplayGroupBox.Size = new System.Drawing.Size(284, 99);
            this._DisplayGroupBox.TabIndex = 0;
            this._DisplayGroupBox.TabStop = false;
            this._DisplayGroupBox.Text = "&Display";
            // 
            // _UseMultipleMonitorsCheckBox
            // 
            this._UseMultipleMonitorsCheckBox.AutoSize = true;
            this._UseMultipleMonitorsCheckBox.Location = new System.Drawing.Point(6, 66);
            this._UseMultipleMonitorsCheckBox.Name = "_UseMultipleMonitorsCheckBox";
            this._UseMultipleMonitorsCheckBox.Size = new System.Drawing.Size(143, 19);
            this._UseMultipleMonitorsCheckBox.TabIndex = 1;
            this._UseMultipleMonitorsCheckBox.Text = "&Use Multiple Monitors";
            this._UseMultipleMonitorsCheckBox.UseVisualStyleBackColor = true;
            this._UseMultipleMonitorsCheckBox.CheckedChanged += new System.EventHandler(this.UseMultipleMonitorsCheckBox_CheckedChanged);
            // 
            // _MonitorComboBox
            // 
            this._MonitorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._MonitorComboBox.FormattingEnabled = true;
            this._MonitorComboBox.Location = new System.Drawing.Point(6, 37);
            this._MonitorComboBox.Name = "_MonitorComboBox";
            this._MonitorComboBox.Size = new System.Drawing.Size(143, 23);
            this._MonitorComboBox.TabIndex = 1;
            this._MonitorComboBox.SelectedIndexChanged += new System.EventHandler(this.MonitorComboBox_SelectedIndexChanged);
            // 
            // _MonitorLabel
            // 
            this._MonitorLabel.AutoSize = true;
            this._MonitorLabel.Location = new System.Drawing.Point(6, 19);
            this._MonitorLabel.Name = "_MonitorLabel";
            this._MonitorLabel.Size = new System.Drawing.Size(50, 15);
            this._MonitorLabel.TabIndex = 0;
            this._MonitorLabel.Text = "&Monitor";
            // 
            // _TabControl
            // 
            this._TabControl.Controls.Add(this._SettingsTabPage);
            this._TabControl.Controls.Add(this._AboutTabPage);
            this._TabControl.Location = new System.Drawing.Point(12, 12);
            this._TabControl.Name = "_TabControl";
            this._TabControl.SelectedIndex = 0;
            this._TabControl.Size = new System.Drawing.Size(432, 170);
            this._TabControl.TabIndex = 1;
            // 
            // _SettingsTabPage
            // 
            this._SettingsTabPage.Controls.Add(this._DisplayGroupBox);
            this._SettingsTabPage.Location = new System.Drawing.Point(4, 24);
            this._SettingsTabPage.Name = "_SettingsTabPage";
            this._SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._SettingsTabPage.Size = new System.Drawing.Size(424, 186);
            this._SettingsTabPage.TabIndex = 0;
            this._SettingsTabPage.Text = "Settings";
            this._SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // _AboutTabPage
            // 
            this._AboutTabPage.Controls.Add(this._GitHubPictureBox);
            this._AboutTabPage.Controls.Add(this.label4);
            this._AboutTabPage.Controls.Add(this._TravelersFontLinkLabel);
            this._AboutTabPage.Controls.Add(this.label3);
            this._AboutTabPage.Controls.Add(this.label2);
            this._AboutTabPage.Controls.Add(this.label1);
            this._AboutTabPage.Location = new System.Drawing.Point(4, 24);
            this._AboutTabPage.Name = "_AboutTabPage";
            this._AboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._AboutTabPage.Size = new System.Drawing.Size(424, 142);
            this._AboutTabPage.TabIndex = 1;
            this._AboutTabPage.Text = "About";
            this._AboutTabPage.UseVisualStyleBackColor = true;
            // 
            // _GitHubPictureBox
            // 
            this._GitHubPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._GitHubPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_GitHubPictureBox.Image")));
            this._GitHubPictureBox.Location = new System.Drawing.Point(234, 93);
            this._GitHubPictureBox.Name = "_GitHubPictureBox";
            this._GitHubPictureBox.Size = new System.Drawing.Size(143, 34);
            this._GitHubPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._GitHubPictureBox.TabIndex = 5;
            this._GitHubPictureBox.TabStop = false;
            this._GitHubPictureBox.Click += new System.EventHandler(this.GitHubPictureBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Screensaver is free and Open Source at:";
            // 
            // _TravelersFontLinkLabel
            // 
            this._TravelersFontLinkLabel.AutoSize = true;
            this._TravelersFontLinkLabel.Location = new System.Drawing.Point(164, 68);
            this._TravelersFontLinkLabel.Name = "_TravelersFontLinkLabel";
            this._TravelersFontLinkLabel.Size = new System.Drawing.Size(79, 15);
            this._TravelersFontLinkLabel.TabIndex = 3;
            this._TravelersFontLinkLabel.TabStop = true;
            this._TravelersFontLinkLabel.Text = "&Travelers Font";
            this._TravelersFontLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TravelersFontLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Travelers Font found here:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Copyright 2020, Kevin Wiegand aka NinjaPuffer Enterprises";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Travelers Screensaver";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 189);
            this.Controls.Add(this._TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "_SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this._DisplayGroupBox.ResumeLayout(false);
            this._DisplayGroupBox.PerformLayout();
            this._TabControl.ResumeLayout(false);
            this._SettingsTabPage.ResumeLayout(false);
            this._AboutTabPage.ResumeLayout(false);
            this._AboutTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GitHubPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _DisplayGroupBox;
        private System.Windows.Forms.ComboBox _MonitorComboBox;
        private System.Windows.Forms.Label _MonitorLabel;
        private System.Windows.Forms.CheckBox _UseMultipleMonitorsCheckBox;
        private System.Windows.Forms.TabControl _TabControl;
        private System.Windows.Forms.TabPage _SettingsTabPage;
        private System.Windows.Forms.TabPage _AboutTabPage;
        private System.Windows.Forms.LinkLabel _TravelersFontLinkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox _GitHubPictureBox;
        private System.Windows.Forms.Label label4;
    }
}