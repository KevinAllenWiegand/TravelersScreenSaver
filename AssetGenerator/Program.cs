using System;
using System.Drawing;

namespace AssetGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var font = new Font(new FontFamily("MarsVoyager Travelers"), 55);
            // Orange
            var orangeBrush = new SolidBrush(Color.FromArgb(250, 110, 30));
            // Red
            var redBrush = new SolidBrush(Color.FromArgb(255, 16, 0));
            // Yellow
            var yellowBrush = new SolidBrush(Color.FromArgb(230, 160, 10));
            var maximumSize = new SizeF(0, 0);

            using (var bitmap = new Bitmap(1, 1))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                foreach (var item in alphabet)
                {
                    SizeF size = graphics.MeasureString(item.ToString(), font);

                    if (size.Width > maximumSize.Width)
                    {
                        maximumSize.Width = size.Width;
                    }

                    if (size.Height > maximumSize.Height)
                    {
                        maximumSize.Height = size.Height;
                    }
                }
            }

            using (var bitmap = new Bitmap((int)Math.Ceiling(maximumSize.Width) * 26, (int)Math.Ceiling(maximumSize.Height)))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);

                var index = 0;

                foreach (var item in alphabet)
                {
                    graphics.DrawString(item.ToString(), font, orangeBrush, index * (int)Math.Ceiling(maximumSize.Width), 0);
                    index++;
                }

                graphics.Save();

                bitmap.Save("TravelersAlphabetOrange.png");
            }

            using (var bitmap = new Bitmap((int)Math.Ceiling(maximumSize.Width) * 26, (int)Math.Ceiling(maximumSize.Height)))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);

                var index = 0;

                foreach (var item in alphabet)
                {
                    graphics.DrawString(item.ToString(), font, redBrush, index * (int)Math.Ceiling(maximumSize.Width), 0);
                    index++;
                }

                graphics.Save();

                bitmap.Save("TravelersAlphabetRed.png");
            }

            using (var bitmap = new Bitmap((int)Math.Ceiling(maximumSize.Width) * 26, (int)Math.Ceiling(maximumSize.Height)))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);

                var index = 0;

                foreach (var item in alphabet)
                {
                    graphics.DrawString(item.ToString(), font, yellowBrush, index * (int)Math.Ceiling(maximumSize.Width), 0);
                    index++;
                }

                graphics.Save();

                bitmap.Save("TravelersAlphabetYellow.png");
            }
        }
    }
}
