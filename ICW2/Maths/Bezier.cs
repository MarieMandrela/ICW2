﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ICW2.Maths
{
    static class Bezier
    {
        /// <summary>
        /// Creates several splines from the give points.
        /// Each has <paramref name="controlPoints"/> segments.
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="outputSegmentCount"></param>
        /// <returns></returns>
        public static List<PolyLineSegment> GetBezierApproximationSplines(List<Point[]> controlPoints, int outputSegmentCount)
        {
            List<PolyLineSegment> segments = new List<PolyLineSegment>();

            foreach (Point[] points in controlPoints)
            {
                PolyLineSegment segment = GetBezierApproximation(points, outputSegmentCount);
                segments.Add(segment);
            }

            return segments;
        }

        /// <summary>
        /// http://www.cubic.org/docs/bezier.htmb
        /// </summary>
        /// <param name="controlPoints"></param>
        /// <param name="outputSegmentCount"></param>
        /// <returns></returns>
        public static PolyLineSegment GetBezierApproximation(Point[] controlPoints, int outputSegmentCount)
        {
            Point[] points = new Point[outputSegmentCount + 1];
            for (int i = 0; i <= outputSegmentCount; i++)
            {
                double t = (double)i / outputSegmentCount;
                points[i] = GetBezierPoint(t, controlPoints, 0, controlPoints.Length);
            }

            return new PolyLineSegment(points, true);
        }

        static Point GetBezierPoint(double t, Point[] controlPoints, int index, int count)
        {
            if (count == 1)
            {
                return controlPoints[index];
            }

            var p1 = GetBezierPoint(t, controlPoints, index, count - 1);
            var p2 = GetBezierPoint(t, controlPoints, index + 1, count - 1);
            return new Point(p1.X + (p2.X - p1.X) * t, p1.Y + (p2.Y - p1.Y) * t);
        }
    }
}
