using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BlitzcrankClient.Reconocimiento
{
    // https://github.com/Skinz3/League-of-Legends-Bot/blob/master/Sources/LeagueBot/LeagueBot/ApiHelpers/ImageHelper.cs
    class ImageHelper
    {
        public static string GetColor(int x, int y)
        {
            return ColorTranslator.ToHtml(Color.FromArgb(Interop.GetPixelColor(new Point(x, y)).ToArgb()));
        }
        public static void WaitForColor(int x, int y, string colorHex)
        {
            Color color = Interop.GetPixelColor(new Point(x, y));

            while (ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb())) != colorHex)
            {
                color = Interop.GetPixelColor(new Point(x, y));
                Thread.Sleep(1000);
            }
        }
        private static Bitmap GetScreenShot()
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            {
                using (Graphics gfx = Graphics.FromImage(result))
                {
                    gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                }
            }
            return result;
        }
        private static Bitmap GetCapture()
        {
            return ApplicationCapture.CaptureApplication("League of Legends");
        }

        private static Bitmap GetCaptureUx()
        {
            return ApplicationCapture.CaptureApplication("RiotClientUx");
        }

        public static List<Point> getAllExistingColorPositions(Color color)
        {
            int searchValue = color.ToArgb();
            List<Point> ExistingColors = new List<Point>();

            using (Bitmap bmp = GetCaptureUx())
            {
                using (FastBitmap bitmap = new FastBitmap(bmp))
                {
                    bitmap.Lock();

                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            if (searchValue == bitmap.GetPixelInt(x, y))
                            {
                                ExistingColors.Add(new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (1024 / 2) + x, (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (768 / 2) + y));
                            }
                        }
                    }
                }
            }

            return ExistingColors;
        }

        public static Point? GetColorPosition(Color color)
        {
            int searchValue = color.ToArgb();

            using (Bitmap bmp = GetCaptureUx())
            {
                using (FastBitmap bitmap = new FastBitmap(bmp))
                {
                    bitmap.Lock();

                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            if (searchValue == bitmap.GetPixelInt(x, y))
                            {
                                return new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (1024 / 2) + x, (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (768 / 2) + y);
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
