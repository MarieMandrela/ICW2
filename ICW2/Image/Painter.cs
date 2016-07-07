using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MPoint = System.Windows.Point;
using DColor = System.Drawing.Color;
using System.Windows.Media;

namespace ICW2.Image
{
    public static class Painter
    {
        /// <summary>
        /// Fills the image <paramref name="bmp"/> with the color <paramref name="c"/>.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="c"></param>
        public static void FillImage(Bitmap bmp, DColor c)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, c);
                }
            }
        }

        /// <summary>
        /// Draws the points <paramref name="points"/> on the image <paramref name="bmp"/> 
        /// using the color <paramref name="c"/> and offsets <paramref name="xOffset"/> and <paramref name="yOffset"/>.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="points"></param>
        /// <param name="c"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public static void DrawPoints(Bitmap bmp, List<MPoint[]> points, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (MPoint[] plist in points)
            {
                DrawPoints(bmp, plist, c, xOffset, xOffset);
            }
        }

        /// <summary>
        /// Draws the points <paramref name="points"/> on the image <paramref name="bmp"/> 
        /// using the color <paramref name="c"/> and offsets <paramref name="xOffset"/> and <paramref name="yOffset"/>.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="points"></param>
        /// <param name="c"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public static void DrawPoints(Bitmap bmp, MPoint[] points, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (MPoint p in points)
            {
                bmp.SetPixel((int)(p.X + xOffset), (int)(p.Y + yOffset), c);
            }
        }

        /// <summary>
        /// Draws the lines <paramref name="lines"/> on the image <paramref name="bmp"/> 
        /// using the color <paramref name="c"/> and offsets <paramref name="xOffset"/> and <paramref name="yOffset"/>.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="lines"></param>
        /// <param name="c"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public static void DrawLines(Bitmap bmp, List<PolyLineSegment> lines, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (PolyLineSegment plist in lines)
            {
                DrawLine(bmp, plist, c, xOffset, xOffset);
            }
        }

        /// <summary>
        /// Draws the line <paramref name="line"/> on the image <paramref name="bmp"/> 
        /// using the color <paramref name="c"/> and offsets <paramref name="xOffset"/> and <paramref name="yOffset"/>.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="line"></param>
        /// <param name="c"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public static void DrawLine(Bitmap bmp, PolyLineSegment line, DColor c, double xOffset = .0, double yOffset = .0)
        {
            foreach (MPoint p in line.Points)
            {
                bmp.SetPixel((int)(p.X + xOffset), (int)(p.Y + yOffset), c);
            }
        }
    }
}
