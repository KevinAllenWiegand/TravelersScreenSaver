﻿using System;

namespace Travelers
{
    public static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // No arguents means show the settings screen.
            // We don't have one at the moment, so just bail.
            if (args == null || args.Length == 0)
            {
                return;
            }

            // We don't have one at the moment, so just bail.
            // /c means to show the settings as a modal dialog.
            if (args != null && args.Length > 0 && args[0].ToLower() == "/c")
            {
                return;
            }

            // No preview support yet.
            // /p <hwnd> means to preview the screensaver as a child window of <hwnd>.
            if (args != null && args.Length > 1 && args[0].ToLower() == "/p")
            {
                var hwndString = args[1];
                return;
            }

            // /s means to run the screen saver.
            if (args != null && args.Length > 0 && args[0].ToLower() == "/s")
            {
                using (var game = new TravelersScreenSaver())
                {
                    game.Run();
                }
            }
        }
    }
}