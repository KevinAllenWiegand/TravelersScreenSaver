using System.Configuration;

namespace Travelers
{
    public static class AppSettings
    {
        public const string MonitorSetting = "monitor";
        public const string UseMultipleMonitorsSetting = "useMultipleMonitors";

        public static string GetStringSetting(string key)
        {
            string value = null;

            try
            {
                value = ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
            }

            return value ?? string.Empty;
        }

        public static bool GetBooleanSetting(string key)
        {
            try
            {
                var settingString = ConfigurationManager.AppSettings[key] ?? null;

                if (bool.TryParse(settingString, out bool value))
                {
                    return value;
                }
            }
            catch (ConfigurationErrorsException)
            {
            }

            return false;
        }

        public static void SetStringSetting(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
            }
        }

        public static void SetBooleanSetting(string key, bool value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value.ToString());
                }
                else
                {
                    settings[key].Value = value.ToString();
                }

                configFile.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
            }
        }
    }
}
