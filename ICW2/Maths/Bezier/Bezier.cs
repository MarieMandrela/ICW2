using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ICW2.Maths.Bezier
{
    /// <summary>
    /// Provides methods that generate Bezier lines from Bezier points. 
    /// </summary>
    public static class Bezier
    {
        /// <summary>
        /// Creates several lines from the give <paramref name="controlPoints"/>.
        /// Each has <paramref name="controlPoints"/> segments.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="outputSegmentCount"></param>
        /// <returns></returns>
        public static List<PolyLineSegment> GetDeCasteljauApproximations(List<Point[]> controlPoints, int outputSegmentCount)
        {
            List<PolyLineSegment> segments = new List<PolyLineSegment>();

            foreach (Point[] points in controlPoints)
            {
                PolyLineSegment segment = GetDeCasteljauApproximation(points, outputSegmentCount);
                segments.Add(segment);
            }

            return segments;
        }

        /// <summary>
        /// Approximated a Bezier line from the given <paramref name="controlPoints"/>. 
        /// The resulting Bezier line will have <paramref name="outputSegmentCount"/> points.
        /// Uses the DeCasteljau algorithm descibed in http://www.cubic.org/docs/bezier.htm.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="outputSegmentCount"></param>
        /// <returns></returns>
        public static PolyLineSegment GetDeCasteljauApproximation(Point[] controlPoints, int outputSegmentCount)
        {
            Point[] points = new Point[outputSegmentCount + 1];
            for (int i = 0; i <= outputSegmentCount; i++)
            {
                double t = (double)i / outputSegmentCount;
                points[i] = GetDeCasteljauPoint(t, controlPoints, 0, controlPoints.Length);
            }

            return new PolyLineSegment(points, true);
        }

        private static Point GetDeCasteljauPoint(double t, Point[] controlPoints, int index, int count)
        {
            if (count == 1)
            {
                return controlPoints[index];
            }

            var p1 = GetDeCasteljauPoint(t, controlPoints, index, count - 1);
            var p2 = GetDeCasteljauPoint(t, controlPoints, index + 1, count - 1);
            return new Point(p1.X + (p2.X - p1.X) * t, p1.Y + (p2.Y - p1.Y) * t);
        }
    }
}
