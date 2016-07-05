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
            Bitmap bm = new Bitmap(1500, 1500);

            MPoint[] rnd = GetRandomBezierPoints(0, 500, 0, 500, 10);
            DrawBezier(bm, rnd, DColor.White, 500, 500, true);

            bm.Save(file, ImageFormat.Png);
        }

        static MPoint[] GetRandomBezierPoints(int MinX, int MaxX, int MinY, int MaxY, int num)
        {
            MPoint[] points = new MPoint[num];
            Random rnd = new Random();
            int x;
            int y;

            for (int i = 0; i < num; i++)
            {
                x = (int)(rnd.NextDouble() * (MaxX - MinX) + MinX);
                y = (int)(rnd.NextDouble() * (MaxY - MinY) + MinY);
                points[i] = new MPoint(x, y);
            }

            return points;
        }

        static void DrawBezier(Bitmap bm, MPoint[] points, DColor c, int xOffset = 0, int yOffset = 0, bool drawAnchors = false)
        {
            PolyLineSegment line = Bezier.GetBezierApproximation(points, 50000);

            foreach (MPoint p in line.Points)
            {
                bm.SetPixel((int) p.X + xOffset, (int) p.Y + yOffset, c);
            }

            foreach (MPoint p in points)
            {
                bm.SetPixel((int)p.X + xOffset, (int)p.Y + yOffset, c);
            }
        }


        static void DrawRandom(Bitmap bm, DColor c)
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
