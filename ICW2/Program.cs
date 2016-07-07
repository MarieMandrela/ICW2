using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICW2.Maths;
using ICW2.Image;

using MPoint = System.Windows.Point;
using DColor = System.Drawing.Color;


namespace ICW2
{
    class Program
    {
        static void Main(string[] args)
        {
            String file = Constants.OutPath + "bezier.png";
            Bitmap bmp = new Bitmap(Constants.OutWidth, Constants.OutHeight);
            Painter.FillImage(bmp, DColor.White);

            int thirdWidth = Constants.OutWidth / 3;
            int thirdHeight = Constants.OutHeight / 3;
            double xOffset = thirdWidth * 1.5;
            double yOffset = thirdHeight * 1.5;

            MPoint[] rnd = BezierShapes.GetRandom(-thirdWidth, thirdWidth, -thirdHeight, thirdHeight, 10);
            List<MPoint[]> circle = BezierShapes.GetCircle(Math.Min(thirdHeight, thirdWidth));

            PolyLineSegment rndLine = Bezier.GetBezierApproximation(rnd, 2000);
            List<PolyLineSegment> circleLines = Bezier.GetBezierApproximationSplines(circle, 500);

            Painter.DrawLines(bmp, circleLines, DColor.Red, xOffset, yOffset);
            Painter.DrawLine(bmp, rndLine, DColor.Blue, xOffset, yOffset);

            Painter.DrawPoints(bmp, circle, DColor.Green, xOffset, xOffset);
            Painter.DrawPoints(bmp, rnd, DColor.Orange, xOffset, yOffset);

            bmp.Save(file, ImageFormat.Png);
        }
    }
}
