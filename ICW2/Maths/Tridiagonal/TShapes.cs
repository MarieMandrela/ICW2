using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ICW2.Maths.Tridiagonal
{
    /// <summary>
    /// Provides methods that return tridiagonl splines.
    /// </summary>
    public static class TShapes
    {
        public static Point[] GetRandom(int MinX, int MaxX, int MinY, int MaxY, int num, int pointCount)
        {
            float[] x = new float[num];
            float[] y = new float[num];
            Random rnd = new Random();

            for (int i = 0; i < num; i++)
            {
                x[i] = (int)(rnd.NextDouble() * (MaxX - MinX) + MinX);
                y[i] = (int)(rnd.NextDouble() * (MaxY - MinY) + MinY);
            }

            float[] xs, ys;
            CubicSpline.FitParametric(x, y, pointCount, out xs, out ys);

            Point[] points = new Point[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                points[i] = new Point(xs[i], ys[i]);
            }

            return points;
        }

        public static Point[] GetCircle(float radius, int pointCount)
        {
            float[] x = new float[5] {
                0, radius, 0, -radius, 0
            };
            float[] y = new float[5] {
                radius, 0, -radius, 0, radius
            };

            float[] xs, ys;
            CubicSpline.FitParametric(x, y, pointCount, out xs, out ys);

            Point[] points = new Point[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                points[i] = new Point(xs[i], ys[i]);
            }

            return points;
        }
    }
}
