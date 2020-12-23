using System;
using System.Windows.Forms;

namespace Travelers
{
    public partial class _SettingsForm : Form
    {
        public _SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _MonitorComboBox.Items.Add("Primary");

            for (var index = 0; index < Screen.AllScreens.Length; index++)
            {
                _MonitorComboBox.Items.Add($"Monitor {index + 1}");
            }

            var monitor = AppSettings.GetIntSetting(AppSettings.MonitorSetting);

            _MonitorComboBox.SelectedIndex = monitor;

            var hasMultipleMonitors = Screen.AllScreens.Length > 1;

            _UseMultipleMonitorsCheckBox.Enabled = hasMultipleMonitors;

            if (hasMultipleMonitors)
            {
                var useMultipleMonitors = AppSettings.GetBooleanSetting(AppSettings.UseMultipleMonitorsSetting);

                _UseMultipleMonitorsCheckBox.Checked = useMultipleMonitors;
            }
        }

        private void MonitorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppSettings.SetIntSetting(AppSettings.MonitorSetting, _MonitorComboBox.SelectedIndex);
        }

        private void UseMultipleMonitorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _MonitorComboBox.Enabled = !_UseMultipleMonitorsCheckBox.Checked;
            AppSettings.SetBooleanSetting(AppSettings.UseMultipleMonitorsSetting, _UseMultipleMonitorsCheckBox.Checked);
        }
    }
}
