using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace finalProject
{
    class myLine
    {
        public Point start = new Point();
        public Point end = new Point();
        public float w;
        public Color c;
        public myLine(Point p1, Point p2,float a,Color o)
        {
            start = p1;
            end = p2;
            w = a;
            c = o;
        }
       // void rotateP(int xOld, int yOld, int angle,int xNew , int yNew) {
        //    double angleRad = Math.PI * angle / 180.0;
         //   xNew = Convert.ToInt32(xOld * Math.Cos(angleRad) - yOld * Math.Sin(angleRad));
          //  yNew = Convert.ToInt32(yOld * Math.Cos(angleRad) + xOld * Math.Sin(angleRad));
        
        //}
        public void translate(int x, int y)
        {
            start.X = start.X + x;
            start.Y = start.Y + y;

            end.X = end.X + x;
            end.Y = end.Y + y;

        }

        public void draw(Graphics g, Pen myPen)
        {
            myPen.Width = w;
            myPen.Color = c;
            g.DrawLine(myPen, start, end);
        }
        public void rotate(int angle ) {
            double angleRad = Math.PI * angle / 180.0;
            int xOld = end.X;
            int yOld = end.Y;
            int xNew, yNew;
            xNew = Convert.ToInt32(xOld * Math.Cos(angleRad) - yOld * Math.Sin(angleRad));
            yNew = Convert.ToInt32(yOld * Math.Cos(angleRad) + xOld * Math.Sin(angleRad));
            end.X = xNew;
            end.Y = yNew;
            

        
        }
    }
}
