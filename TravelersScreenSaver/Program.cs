using System;

namespace Travelers
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // No arguents means show the settings screen.
            // /c means to show the settings as a modal dialog.
            // We don't have one at the moment, so just bail.
            if (args == null || args.Length == 0 || (args != null && args.Length > 0 && args[0].Trim().ToLower() == "/c"))
            {
                using (var settingsForm = new _SettingsForm())
                {
                    settingsForm.ShowDialog();
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
