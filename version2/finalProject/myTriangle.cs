using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace finalProject
{
    class myTriangle
    {
        public Point start = new Point();
        public Point end = new Point();
        public float w;
        public Color c;

        public myTriangle(Point p1, Point p2, float a, Color o)
        {
            start=p1;
            end=p2;
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
        private void dr(Point[] p,Pen myPen, Graphics graphics) { 
           
        
        }
        public void draw(Graphics graphics, Pen myPen)
        {
            double x1 = start.X;
            double y1 = start.Y;
            double x2 = end.X;
            double y2 = end.Y;
            double t1 = (x2 - x1) / 2;
            //double t2 = (y2 - y1) / 2;
            //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
            for (int i = 1; i <= 3; i++)
            {
                Point p = new Point();
                Point pn = new Point();
                p.X = Convert.ToInt32(t1 * Math.Cos((((2 * Math.PI * (i)) / 3) + Math.PI / 2)) + x1);
                p.Y = Convert.ToInt32(t1 * Math.Sin((((2 * Math.PI * (i)) / 3) + Math.PI / 2)) + y1);
                pn.X = Convert.ToInt32(t1 * Math.Cos((((2 * Math.PI * (i - 1)) / 3) + Math.PI / 2)) + x1);
                pn.Y = Convert.ToInt32(t1 * Math.Sin((((2 * Math.PI * (i - 1)) / 3) + Math.PI / 2)) + y1);
                myPen.Width = w;
                myPen.Color = c;
                 graphics.DrawLine(myPen, p ,pn);
            }
            
        }

        public void rotate(int angle)
        {
            double angleRad = Math.PI * angle / 180.0;
            int xOld = end.X;
            int yOld = end.Y;
            int xNew, yNew;
            xNew = Convert.ToInt32(xOld * Math.Cos(angleRad) - yOld * Math.Sin(angleRad));
            yNew = Convert.ToInt32(yOld * Math.Cos(angleRad) + xOld * Math.Sin(angleRad));
            end.X = xNew;
            end.Y = yNew;
            xOld = start.X;
            yOld = start.Y;
            xNew = Convert.ToInt32(xOld * Math.Cos(-1*angleRad) - yOld * Math.Sin(-1*angleRad));
            yNew = Convert.ToInt32(yOld * Math.Cos(-1*angleRad) + xOld * Math.Sin(-1*angleRad));
            start.X = xNew;
            start.Y = yNew;


        }
}
}
