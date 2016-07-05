using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICW2
{
    class Program
    {
        static void Main(string[] args)
        {
            String file = "../../Output/test.png";
            Bitmap bm = new Bitmap(500, 500);

            fillRandom(bm, Color.Turquoise);

            bm.Save(file, ImageFormat.Png);
        }

        static void fillRandom(Bitmap bm, Color c)
        {
            Random rnd = new Random();

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    if (rnd.NextDouble() > 0.5)
                    {
                        bm.SetPixel(i, j, c);
                    }
                }
            }
        }
    }
}
