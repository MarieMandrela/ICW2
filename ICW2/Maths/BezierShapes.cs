using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ICW2.Maths
{
    static class BezierShapes
    {
        public static double C = 0.551915024494;

        /// <summary>
        /// http://www.cubic.org/docs/bezier.htm
        /// </summary>
        /// <returns></returns>
        public static Point[] GetTestDeCasteljau()
        {
            Point[] test = new Point[] {
                new Point (40, 100),
                new Point (80, 20),
                new Point (140, 180),
                new Point (260, 100),
            };

            return test;
        }

        public static Point[] GetRandom(int MinX, int MaxX, int MinY, int MaxY, int num)
        {
            Point[] points = new Point[num];
            Random rnd = new Random();
            int x;
            int y;

            for (int i = 0; i < num; i++)
            {
                x = (int)(rnd.NextDouble() * (MaxX - MinX) + MinX);
                y = (int)(rnd.NextDouble() * (MaxY - MinY) + MinY);
                points[i] = new Point(x, y);
            }

            return points;
        }

        /// <summary>
        /// http://spencermortensen.com/articles/bezier-circle/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static Point[] GetCircle(double radius)
        {
            double c = C * radius;
            Point[] circle = new Point[] {
                    new Point (0, radius),
                    new Point (c, radius),
                    new Point (radius, c),
                    new Point (radius, 0),
                    new Point (radius, 0),
                    new Point (radius, -c),
                    new Point (c, -radius),
                    new Point (0, -radius),
                    new Point (0, -radius),
                    new Point (-c, -radius),
                    new Point (-radius, -c),
                    new Point (-radius, 0),
                    new Point (-radius, 0),
                    new Point (-radius, c),
                    new Point (-c, radius),
                    new Point (0, radius)
            };

            return circle;
        }
    }
}
