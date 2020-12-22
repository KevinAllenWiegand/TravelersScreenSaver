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

            var index = 0;

            foreach (var screen in Screen.AllScreens)
            {
                if (!screen.Primary)
                {
                    index++;
                    _MonitorComboBox.Items.Add($"Monitor {index}");
                }
            }

            var monitor = AppSettings.GetStringSetting(AppSettings.MonitorSetting);
            var monitorIndex = _MonitorComboBox.Items.IndexOf(monitor);

            if (monitor != null && monitorIndex != -1)
            {
                _MonitorComboBox.SelectedIndex = monitorIndex;
            }
            else
            {
                _MonitorComboBox.SelectedIndex = 0;
            }

            var hasMultipleMonitors = Screen.AllScreens.Length > 1;

            _UseMultipleMonitorsCheckBox.Enabled = hasMultipleMonitors;

            if (hasMultipleMonitors)
            {
                var useMultipleMonitors = AppSettings.GetBooleanSetting(AppSettings.UseMultipleMonitorsSetting);

                _UseMultipleMonitorsCheckBox.Checked = useMultipleMonitors.Value;
            }
        }

        private void MonitorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppSettings.SetStringSetting(AppSettings.MonitorSetting, _MonitorComboBox.SelectedItem.ToString());
        }

        private void UseMultipleMonitorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _MonitorComboBox.Enabled = !_UseMultipleMonitorsCheckBox.Checked;
            AppSettings.SetBooleanSetting(AppSettings.UseMultipleMonitorsSetting, _UseMultipleMonitorsCheckBox.Checked);
        }
    }
}
