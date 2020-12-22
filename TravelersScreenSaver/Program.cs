using System;

namespace Travelers
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // No arguents means show the settings screen.
            if (args == null || args.Length == 0)
            {
                using (var settingsForm = new _SettingsForm())
                {
                    settingsForm.ShowDialog();
                }

                return;
            }

            // /c means to show the settings, possibly with a parent.
            if (args != null && args.Length > 0 && args[0].Trim().ToLower().StartsWith("/c"))
            {
                var parts = args[0].Split(new string[] { ":", " " }, StringSplitOptions.RemoveEmptyEntries);
                var hwndString = parts.Length > 0 ? parts[parts.Length - 1] : String.Empty;
                long hwnd;

                long.TryParse(hwndString, out hwnd);

                using (var settingsForm = new _SettingsForm())
                {
                    if (hwnd > 0)
                    {
                        settingsForm.ShowDialog(new ParentHwndWrapper((IntPtr)hwnd));
                    }
                    else
                    {
                        settingsForm.ShowDialog();
                    }
                }

                return;
            }

            // /p <hwnd> means to preview the screensaver as a child window of <hwnd>.
            // No preview support yet.
            if (args != null && args.Length > 1 && args[0].Trim().ToLower() == "/p")
            {
                var hwndString = args[1];
                return;
            }

            // /s means to run the screen saver.
            if (args != null && args.Length > 0 && args[0].Trim().ToLower() == "/s")
            {
                using (var game = new TravelersScreenSaver())
                {
                    game.Run();
                }
            }
        }
    }
}
