using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace finalProject
{
    class myHeptagon
    {
        public Point start = new Point();
        public Point end = new Point();
        public float w;
        public Color c;

        public myHeptagon(Point p1, Point p2, float a, Color o)
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
            double x1 = start.X;
            double y1 = start.Y;
            double x2 = end.X;
            double y2 = end.Y;
            double h7 = (x2 - x1) / 2;

            for (int i = 1; i <= 7; i++)
            {
                Point p = new Point();
                Point pn = new Point();
                p.X = Convert.ToInt32(h7 * Math.Cos((((2 * Math.PI * (i)) / 7))) + x1);
                p.Y = Convert.ToInt32(h7 * Math.Sin((((2 * Math.PI * (i)) / 7))) + y1);
                pn.X = Convert.ToInt32(h7 * Math.Cos((((2 * Math.PI * (i - 1)) / 7))) + x1);
                pn.Y = Convert.ToInt32(h7 * Math.Sin((((2 * Math.PI * (i - 1)) / 7))) + y1);
                myPen.Width = w;
                myPen.Color = c;
                graphics.DrawLine(myPen, p, pn);
            }
        }
    }
}
