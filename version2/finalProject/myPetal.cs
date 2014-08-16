using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace finalProject
{
    class myPetal
    {
        public Point start = new Point();
        public Point end = new Point();
        public float w;
        public Color c;

        public myPetal(Point p1, Point p2, float a, Color o)
        {
            start = p1;
            end = p2;
            w = a;
            c = o;
        }
        public void translate(int x, int y)
        {
            start.X = start.X + x;
            start.Y = start.Y + y;

            end.X = end.X + x;
            end.Y = end.Y + y;

        }
        public void draw(Graphics graphics, Pen myPen)
        {
            double petal1 = (end.X - start.X) / 2;
            double petal2 = (end.Y - start.Y) / 2;
            //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
            for (int i = 1; i <= 60; i++)
            {
                Point p1 = new Point();
                Point p2 = new Point();
                p1.X = Convert.ToInt32(petal1 * (Math.Cos((((2 * Math.PI * (i)) / 60))) * Math.Cos((((6 * Math.PI * (i)) / 60)))) + start.X);
                p1.Y = Convert.ToInt32(petal1 * (Math.Sin((((2 * Math.PI * (i)) / 60))) * Math.Cos((((6 * Math.PI * (i)) / 60)))) + start.Y);
                p2.X = Convert.ToInt32(petal1 * (Math.Cos((((2 * Math.PI * (i - 1)) / 60))) * Math.Cos((((6 * Math.PI * (i - 1)) / 60)))) + start.X);
                p2.Y = Convert.ToInt32(petal1 * (Math.Sin((((2 * Math.PI * (i - 1)) / 60))) * Math.Cos((((6 * Math.PI * (i - 1)) / 60)))) + start.Y);
                myPen.Width = w;
                myPen.Color = c;
                graphics.DrawLine(myPen, p1, p2); // Draw line from i to i+1

            }
        }
    }
}
