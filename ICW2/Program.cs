using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Drawing.Imaging;
using System.Drawing;
using ICW2.Maths.Tridiagonal;
using ICW2.Image;
using ICW2.Maths.Bezier;

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

            MPoint[] rnd = BShapes.GetRandom(-thirdWidth, thirdWidth, -thirdHeight, thirdHeight, 10);
            MPoint[] rndSpline = TShapes.GetRandom(-thirdWidth, thirdWidth, -thirdHeight, thirdHeight, 10, 2000);
            List<MPoint[]> circle = BShapes.GetCircle(Math.Min(thirdHeight, thirdWidth));

            PolyLineSegment rndLine = Bezier.GetDeCasteljauApproximation(rnd, 2000);
            List<PolyLineSegment> circleLines = Bezier.GetDeCasteljauApproximations(circle, 500);

            Painter.DrawLines(bmp, circleLines, DColor.Red, xOffset, yOffset);
            Painter.DrawLine(bmp, rndLine, DColor.Blue, xOffset, yOffset);

            Painter.DrawPoints(bmp, circle, DColor.Green, xOffset, xOffset);
            Painter.DrawPoints(bmp, rnd, DColor.Orange, xOffset, yOffset);

            Painter.FillImage(bmp, DColor.White);
            Painter.DrawPoints(bmp, rndSpline, DColor.Black, xOffset, yOffset);

            bmp.Save(file, ImageFormat.Png);
        }
    }
}
