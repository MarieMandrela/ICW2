using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ICW2.Maths.Bezier
{
    /// <summary>
    /// Provides methods that return Bezier shapes as Bezier points.
    /// </summary>
    public static class BShapes
    {
        private const double C = 0.551915024494;

        /// <summary>
        /// Gets the points specified in http://www.cubic.org/docs/bezier.htm.
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

        /// <summary>
        /// Gets <paramref name="num"/> random points between the given min and max.
        /// </summary>
        /// <param name="MinX"></param>
        /// <param name="MaxX"></param>
        /// <param name="MinY"></param>
        /// <param name="MaxY"></param>
        /// <param name="num"></param>
        /// <returns></returns>
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
        /// Gets the points for four lines that approximate a circle with the radius <paramref name="radius"/>.
        /// Taken from here: http://spencermortensen.com/articles/bezier-circle/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static List<Point[]> GetCircle(double radius)
        {
            double c = C * radius;
            List<Point[]> circle = new List<Point[]>();

            Point[] c1 = new Point[] {
                    new Point (0, radius),
                    new Point (c, radius),
                    new Point (radius, c),
                    new Point (radius, 0),
            };
            Point[] c2 = new Point[] {
                    new Point (radius, 0),
                    new Point (radius, -c),
                    new Point (c, -radius),
                    new Point (0, -radius),
            };
            Point[] c3 = new Point[] {
                    new Point (0, -radius),
                    new Point (-c, -radius),
                    new Point (-radius, -c),
                    new Point (-radius, 0),
            };
            Point[] c4 = new Point[] {
                    new Point (-radius, 0),
                    new Point (-radius, c),
                    new Point (-c, radius),
                    new Point (0, radius)
            };

            circle.Add(c1);
            circle.Add(c2);
            circle.Add(c3);
            circle.Add(c4);

            return circle;
        }
    }
}
