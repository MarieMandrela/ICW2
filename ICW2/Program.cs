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
            List<MPoint[]> circle = BezierShapes.GetCircle(height / 3);

            double xOffset = width / 3 * 1.5;
            double yOffset = height / 3 * 1.5;

            PolyLineSegment rndLine = Bezier.GetBezierApproximation(rnd, 2000);
            List<PolyLineSegment> circleLine = Bezier.GetBezierApproximationSplines(circle, 500);

            DrawLines(bmp, circleLine, DColor.Red, xOffset, yOffset);
            DrawLine(bmp, rndLine, DColor.Blue, xOffset, yOffset);

            DrawPoints(bmp, circle, DColor.Green, xOffset, xOffset);
            DrawPoints(bmp, rnd, DColor.Orange, xOffset, yOffset);

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

        static void DrawPoints(Bitmap bmp, List<MPoint[]> points, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (MPoint[] plist in points)
            {
                DrawPoints(bmp, plist, c, xOffset, xOffset);
            }
        }

        static void DrawPoints(Bitmap bmp, MPoint[] points, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (MPoint p in points)
            {
                bmp.SetPixel((int)(p.X + xOffset), (int)(p.Y + yOffset), c);
            }
        }

        static void DrawLines(Bitmap bmp, List<PolyLineSegment> lines, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (PolyLineSegment plist in lines)
            {
                DrawLine(bmp, plist, c, xOffset, xOffset);
            }
        }

        static void DrawLine(Bitmap bmp, PolyLineSegment line, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (MPoint p in line.Points)
            {
                bmp.SetPixel((int)(p.X + xOffset), (int)(p.Y + yOffset), c);
            }
        }
    }
}
