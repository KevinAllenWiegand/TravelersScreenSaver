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
            var brush1 = new SolidBrush(Color.FromArgb(255, 117, 38));
            var brush2 = new SolidBrush(Color.FromArgb(255, 16, 0));
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
                    graphics.DrawString(item.ToString(), font, brush1, index * (int)Math.Ceiling(maximumSize.Width), 0);
                    index++;
                }

                graphics.Save();

                bitmap.Save("TravelersAlphabet.png");
            }

            using (var bitmap = new Bitmap((int)Math.Ceiling(maximumSize.Width) * 26, (int)Math.Ceiling(maximumSize.Height)))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);

                var index = 0;

                foreach (var item in alphabet)
                {
                    graphics.DrawString(item.ToString(), font, brush2, index * (int)Math.Ceiling(maximumSize.Width), 0);
                    index++;
                }

                graphics.Save();

                bitmap.Save("TravelersAlphabet2.png");
            }
        }
    }
}
