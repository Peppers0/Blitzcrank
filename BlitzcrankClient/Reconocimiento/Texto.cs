using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzcrankClient.Reconocimiento
{
    public static class Texto
    {
        private static Bitmap GetCapture()
        {
            return ApplicationCapture.CaptureApplication("RiotClientUx");
        }

        public static Point? Buscar(string texto)
        {
            using (Bitmap bmp = GetCapture())
            {
                var ocr = new tessnet2.Tesseract();
                ocr.Init("tesseract", "spa", false);
                var result = ocr.DoOCR(bmp, Rectangle.Empty);

                foreach(tessnet2.Word word in result)
                {
                    if (word.Text.Equals(texto))
                    {
                        return new Point(word.Right, word.Bottom);
                    }
                }
            }

            return null;
        }
    }
}
