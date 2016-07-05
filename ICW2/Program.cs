using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICW2.Maths;

using MPoint = System.Windows.Point;
using DColor = System.Drawing.Color;

namespace ICW2
{
    class Program
    {
        static void Main(string[] args)
        {
            String file = "../../Output/bezier.png";
            Bitmap bm = new Bitmap(1000, 1000);

            MPoint[] testPoints = new[] {
                new MPoint(100, 50),
                new MPoint(50, 200),
                new MPoint(300, 100),
                new MPoint(150, 100),
                new MPoint(60, 400),
                new MPoint(460, 160),
                new MPoint(100, 50),
            };
            drawBezier(bm, testPoints, DColor.White, 250, 350, true);

            bm.Save(file, ImageFormat.Png);
        }

        static void drawBezier(Bitmap bm, MPoint[] points, DColor c, int xOffset = 0, int yOffset = 0, bool drawAnchors = false)
        {
            PolyLineSegment line = Bezier.GetBezierApproximation(points, 1000);

            foreach (MPoint p in line.Points)
            {
                bm.SetPixel((int) p.X + xOffset, (int) p.Y + yOffset, c);
            }

            foreach (MPoint p in points)
            {
                bm.SetPixel((int)p.X + xOffset, (int)p.Y + yOffset, c);
            }
        }


        static void drawRandom(Bitmap bm, DColor c)
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
