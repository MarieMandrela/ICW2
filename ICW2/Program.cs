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
            int width = 600;
            int height = 600;
            Bitmap bmp = new Bitmap(width, height);
            FillImage(bmp, DColor.White);

            MPoint[] rnd = BezierShapes.GetRandom(-width / 3, width / 3, -height / 3, height / 3, 10);
            MPoint[] test = BezierShapes.GetTestDeCasteljau();
            MPoint[] circle = BezierShapes.GetCircle(height / 3);

            double xOffset = width / 3 * 1.5;
            double yOffset = height / 3 * 1.5;
            MPoint[] border = new MPoint[] {
                new MPoint (-width / 3, -height / 3),
                new MPoint (-width / 3, height / 3),
                new MPoint (width / 3, -height / 3),
                new MPoint (width / 3, height / 3)
            };

            PolyLineSegment line = Bezier.GetBezierApproximation(circle, 2000);

            DrawPoints(bmp, line.Points.ToArray(), DColor.Black, xOffset, yOffset);
            DrawPoints(bmp, circle, DColor.Red, xOffset, yOffset);
            DrawPoints(bmp, border, DColor.Blue, xOffset, yOffset);

            bmp.Save(file, ImageFormat.Png);
        }

        static void FillImage(Bitmap bmp, DColor c)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, c);
                }
            }
        }

        static void DrawPoints(Bitmap bmp, MPoint[] points, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (MPoint p in points)
            {
                bmp.SetPixel((int)(p.X + xOffset), (int)(p.Y + yOffset), c);
            }
        }
    }
}
