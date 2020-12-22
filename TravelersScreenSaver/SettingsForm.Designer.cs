
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
            this._DisplayGroupBox = new System.Windows.Forms.GroupBox();
            this._UseMultipleMonitorsCheckBox = new System.Windows.Forms.CheckBox();
            this._MonitorComboBox = new System.Windows.Forms.ComboBox();
            this._MonitorLabel = new System.Windows.Forms.Label();
            this._DisplayGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _DisplayGroupBox
            // 
            this._DisplayGroupBox.Controls.Add(this._UseMultipleMonitorsCheckBox);
            this._DisplayGroupBox.Controls.Add(this._MonitorComboBox);
            this._DisplayGroupBox.Controls.Add(this._MonitorLabel);
            this._DisplayGroupBox.Location = new System.Drawing.Point(12, 12);
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
            // _SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 121);
            this.Controls.Add(this._DisplayGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "_SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this._DisplayGroupBox.ResumeLayout(false);
            this._DisplayGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _DisplayGroupBox;
        private System.Windows.Forms.ComboBox _MonitorComboBox;
        private System.Windows.Forms.Label _MonitorLabel;
        private System.Windows.Forms.CheckBox _UseMultipleMonitorsCheckBox;
    }
}