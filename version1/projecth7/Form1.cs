using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security;
using System.Windows.Media.Media3D;
namespace projecth7
{

    public partial class Form1 : Form
    {
        int rotate = 0;
        int rot = 0;
        int angle;
        string shape = "";
        Color color = Color.Black;
        int width = 3;
        bool start = false;
        Point startPoint = new Point();
        Point endPoint = new Point();
        int y = 0;
        int x = 0;
        int z = 0;
        Pen pen = new Pen(Color.Black, 2);
        Point pt1 = new Point();
        Point pt2 = new Point();
        Point pt3 = new Point();
        point p1 = new point();
        point p2 = new point();
        point X = new point();
        point Y = new point();
        point XX = new point();
        point YY = new point();
        point XXX = new point();
        point YYY = new point();
        string[] infor={null};
        List<string> list = new List<string>();
        int v;
        int numberOfShapes = 0;
        string shapeInfo = "";
        double xCenter, yCenter;
        public Form1()
        {
            InitializeComponent();

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            shape = "square";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            shape = "rectangle";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            shape = "pentagon";
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            shape = "octagon";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            shape = "hexagon";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            shape = "heptagon";
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            shape = "nonagon";
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            shape = "ellipse";
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            shape = "circle";
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            shape = "triangle";
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            shape = "freeline";
        }
        private void Polylines_Click(object sender, EventArgs e)
        {
            shape = "polyline";
        }

        private void Polygon_Click(object sender, EventArgs e)
        {
            shape = "polygon";

        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            shape = "line";
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            shape = "cardioid";
        }
        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            shape = "petal";
        }
        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            shape = "spiral";
        }
        //--------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------//
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = true;
            startPoint.X = e.X;
            startPoint.Y = e.Y;
            if (shape == "freeline")
            {
                listBox1.Items.Add("freeline," + (numberOfShapes + 1).ToString());
            }

            if (shape == "polyline" && y == 1)
            {
                startPoint = pt2;
            }
            else if (shape == "polygon" && z == 1)
            {
                startPoint = pt2;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel2.Text = shape.ToString();
            toolStripStatusLabel8.Text = width.ToString();

            // set the current x and the current y
            toolStripStatusLabel4.Text = e.X.ToString();
            toolStripStatusLabel6.Text = e.Y.ToString();
            Graphics g = pictureBox1.CreateGraphics();
            if (start == true)
            {
                endPoint = e.Location;
                if (shape == "freeline")
                {
                    if (startPoint.X == 0 && startPoint.Y == 0)
                    {
                        startPoint = endPoint;
                    }
                    //freeLine
                    pen.Color = color;
                    pen.Width = width;
                    shapeInfo = startPoint.X.ToString() + "," + startPoint.Y.ToString() + "," + endPoint.X.ToString() + "," + endPoint.Y.ToString() + "," + pen.Color.ToArgb() + "," + pen.Width.ToString();
                    list.Add("freeline," + shapeInfo + "," + numberOfShapes);
                    g.DrawLine(pen, endPoint, startPoint);
                    startPoint = endPoint;

                }
                else
                    pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            start = false;
            numberOfShapes++;
            Graphics g = pictureBox1.CreateGraphics();
            switch (shape)
            {
                #region Draw_Spiral
                case "spiral":
                    double sp1 = (endPoint.X - startPoint.X) / 2;
                    double sp2 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 60; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(sp1 * (Math.Cos((((2 * Math.PI * (i)) / 60))) * Math.PI * i / 4) + startPoint.X);
                        p1.Y = Convert.ToInt32(sp1 * (Math.Sin((((2 * Math.PI * (i)) / 60))) * Math.PI * i / 4) + startPoint.Y);
                        p2.X = Convert.ToInt32(sp1 * (Math.Cos((((2 * Math.PI * (i - 1)) / 60))) * Math.PI * (i - 1) / 4) + startPoint.X);
                        p2.Y = Convert.ToInt32(sp1 * (Math.Sin((((2 * Math.PI * (i - 1)) / 60))) * Math.PI * (i - 1) / 4) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("spiral," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("spiral," + numberOfShapes.ToString());
                    break;
                #endregion

                #region Draw_Petal
                case "petal":
                    double petal1 = (endPoint.X - startPoint.X) / 2;
                    double petal2 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 60; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(petal1 * (Math.Cos((((2 * Math.PI * (i)) / 60))) * Math.Cos((((6 * Math.PI * (i)) / 60)))) + startPoint.X);
                        p1.Y = Convert.ToInt32(petal1 * (Math.Sin((((2 * Math.PI * (i)) / 60))) * Math.Cos((((6 * Math.PI * (i)) / 60)))) + startPoint.Y);
                        p2.X = Convert.ToInt32(petal1 * (Math.Cos((((2 * Math.PI * (i - 1)) / 60))) * Math.Cos((((6 * Math.PI * (i - 1)) / 60)))) + startPoint.X);
                        p2.Y = Convert.ToInt32(petal1 * (Math.Sin((((2 * Math.PI * (i - 1)) / 60))) * Math.Cos((((6 * Math.PI * (i - 1)) / 60)))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("petal," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("petal," + numberOfShapes.ToString());
                    break;
                #endregion

                #region Draw_cardioid
                case "cardioid":
                    double c1 = (endPoint.X - startPoint.X) / 2;
                    double c2 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 60; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(c1 * (2 * Math.Cos((((2 * Math.PI * (i)) / 60))) - Math.Cos((((4 * Math.PI * (i)) / 60)))) + startPoint.X);
                        p1.Y = Convert.ToInt32(c2 * (2 * Math.Sin((((2 * Math.PI * (i)) / 60))) - Math.Sin((((4 * Math.PI * (i)) / 60)))) + startPoint.Y);
                        p2.X = Convert.ToInt32(c1 * (2 * Math.Cos((((2 * Math.PI * (i - 1)) / 60))) - Math.Cos((((4 * Math.PI * (i - 1)) / 60)))) + startPoint.X);
                        p2.Y = Convert.ToInt32(c2 * (2 * Math.Sin((((2 * Math.PI * (i - 1)) / 60))) - Math.Sin((((4 * Math.PI * (i - 1)) / 60)))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("cardioid," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("cardioid," + numberOfShapes.ToString());
                    break;
                #endregion

                #region Draw_Line
                case "line":

                    shapeInfo = startPoint.X.ToString() + "," + startPoint.Y.ToString() + "," + endPoint.X.ToString() + "," + endPoint.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                    list.Add("line," + shapeInfo + "," + numberOfShapes.ToString()); // add line information to the list      
                    listBox1.Items.Add("line," + numberOfShapes.ToString());
                    break;
                #endregion

                #region Draw_triangle
                case "triangle":

                    double t1 = (endPoint.X - startPoint.X) / 2;
                    double t2 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 3; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(t1 * Math.Cos((((2 * Math.PI * (i)) / 3) + Math.PI / 2)) + startPoint.X);
                        p1.Y = Convert.ToInt32(t1 * Math.Sin((((2 * Math.PI * (i)) / 3) + Math.PI / 2)) + startPoint.Y);
                        p2.X = Convert.ToInt32(t1 * Math.Cos((((2 * Math.PI * (i - 1)) / 3) + Math.PI / 2)) + startPoint.X);
                        p2.Y = Convert.ToInt32(t1 * Math.Sin((((2 * Math.PI * (i - 1)) / 3) + Math.PI / 2)) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("triangle," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("triangle," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_square
                case "square":
                    double W1 = (endPoint.X - startPoint.X) / 2;
                    double H1 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 4; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(W1 * Math.Cos((((2 * Math.PI * (i)) / 4) + (Math.PI / 4))) + startPoint.X);
                        p1.Y = Convert.ToInt32(W1 * Math.Sin((((2 * Math.PI * (i)) / 4) + (Math.PI / 4))) + startPoint.Y);
                        p2.X = Convert.ToInt32(W1 * Math.Cos((((2 * Math.PI * (i - 1)) / 4) + (Math.PI / 4))) + startPoint.X);
                        p2.Y = Convert.ToInt32(W1 * Math.Sin((((2 * Math.PI * (i - 1)) / 4) + (Math.PI / 4))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("square," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("square," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_pentagon
                case "pentagon":
                    double w1 = (endPoint.X - startPoint.X) / 2;
                    //double  p1 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 5; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(w1 * Math.Cos((((2 * Math.PI * (i)) / 5) + Math.PI / 5)) + startPoint.X);
                        p1.Y = Convert.ToInt32(w1 * Math.Sin((((2 * Math.PI * (i)) / 5) + Math.PI / 5)) + startPoint.Y);
                        p2.X = Convert.ToInt32(w1 * Math.Cos((((2 * Math.PI * (i - 1)) / 5) + Math.PI / 5)) + startPoint.X);
                        p2.Y = Convert.ToInt32(w1 * Math.Sin((((2 * Math.PI * (i - 1)) / 5) + Math.PI / 5)) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("pentagon," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("pentagon," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_Rectangle
                case "rectangle":

                    //                  listBox1.Items.Add("ellipse" + numberOfShapes.ToString());
                    double W = (endPoint.X - startPoint.X) / 2;
                    double H = (endPoint.Y - startPoint.Y) / 2;
                    double theta = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 4; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(W * Math.Cos((((2 * Math.PI * (i)) / 4) + (Math.PI / 4))) + startPoint.X);
                        p1.Y = Convert.ToInt32(H * Math.Sin((((2 * Math.PI * (i)) / 4) + (Math.PI / 4))) + startPoint.Y);
                        p2.X = Convert.ToInt32(W * Math.Cos((((2 * Math.PI * (i - 1)) / 4) + (Math.PI / 4))) + startPoint.X);
                        p2.Y = Convert.ToInt32(H * Math.Sin((((2 * Math.PI * (i - 1)) / 4) + (Math.PI / 4))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("rectangle," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("rectangle," + numberOfShapes.ToString());

                    //  listBox1.Items.Add("ellipse" + numberOfShapes.ToString()+shapeInfo);
                    break;
                #endregion

                #region Draw_hexagon
                case "hexagon":
                    double d = (endPoint.X - startPoint.X) / 2;
                    // double p3 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 6; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(d * Math.Cos((((2 * Math.PI * (i)) / 6))) + startPoint.X);
                        p1.Y = Convert.ToInt32(d * Math.Sin((((2 * Math.PI * (i)) / 6))) + startPoint.Y);
                        p2.X = Convert.ToInt32(d * Math.Cos((((2 * Math.PI * (i - 1)) / 6))) + startPoint.X);
                        p2.Y = Convert.ToInt32(d * Math.Sin((((2 * Math.PI * (i - 1)) / 6))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("hexagon," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("hexagon," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_heptagon
                case "heptagon":
                    double hep = (endPoint.X - startPoint.X) / 2;
                    //p3 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 7; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(hep * Math.Cos((((2 * Math.PI * (i)) / 7))) + startPoint.X);
                        p1.Y = Convert.ToInt32(hep * Math.Sin((((2 * Math.PI * (i)) / 7))) + startPoint.Y);
                        p2.X = Convert.ToInt32(hep * Math.Cos((((2 * Math.PI * (i - 1)) / 7))) + startPoint.X);
                        p2.Y = Convert.ToInt32(hep * Math.Sin((((2 * Math.PI * (i - 1)) / 7))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("heptagon," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("heptagon," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_octagon
                case "octagon":
                    double oct = (endPoint.X - startPoint.X) / 2;
                    // p3 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 8; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(oct * Math.Cos((((2 * Math.PI * (i)) / 8))) + startPoint.X);
                        p1.Y = Convert.ToInt32(oct * Math.Sin((((2 * Math.PI * (i)) / 8))) + startPoint.Y);
                        p2.X = Convert.ToInt32(oct * Math.Cos((((2 * Math.PI * (i - 1)) / 8))) + startPoint.X);
                        p2.Y = Convert.ToInt32(oct * Math.Sin((((2 * Math.PI * (i - 1)) / 8))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("octagon," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("octagon," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_nonagon
                case "nonagon":
                    double non = (endPoint.X - startPoint.X) / 2;
                    //  p3 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 9; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(non * Math.Cos((((2 * Math.PI * (i)) / 9))) + startPoint.X);
                        p1.Y = Convert.ToInt32(non * Math.Sin((((2 * Math.PI * (i)) / 9))) + startPoint.Y);
                        p2.X = Convert.ToInt32(non * Math.Cos((((2 * Math.PI * (i - 1)) / 9))) + startPoint.X);
                        p2.Y = Convert.ToInt32(non * Math.Sin((((2 * Math.PI * (i - 1)) / 9))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("nonagon," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("nonagon," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_ellipse
                case "ellipse":
                    double e1 = (endPoint.X - startPoint.X);
                    double e2 = (endPoint.Y - startPoint.Y);
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 60; i++)
                    {
                        Point p1 = new Point();
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(e1 * Math.Cos((((2 * Math.PI * (i)) / 60))) + startPoint.X);
                        p1.Y = Convert.ToInt32(e2 * Math.Sin((((2 * Math.PI * (i)) / 60))) + startPoint.Y);
                        p2.X = Convert.ToInt32(e1 * Math.Cos((((2 * Math.PI * (i - 1)) / 60))) + startPoint.X);
                        p2.Y = Convert.ToInt32(e2 * Math.Sin((((2 * Math.PI * (i - 1)) / 60))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("ellipse," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("ellipse," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_circle
                case "circle":
                    double cir1 = (endPoint.X - startPoint.X);
                    //   double cir2 = (endPoint.Y - startPoint.Y) / 2;
                    //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                    for (int i = 1; i <= 60; i++)
                    {
                        Point p1 = new Point(); ;
                        Point p2 = new Point();
                        p1.X = Convert.ToInt32(cir1 * Math.Cos((((2 * Math.PI * (i)) / 60))) + startPoint.X);
                        p1.Y = Convert.ToInt32(cir1 * Math.Sin((((2 * Math.PI * (i)) / 60))) + startPoint.Y);
                        p2.X = Convert.ToInt32(cir1 * Math.Cos((((2 * Math.PI * (i - 1)) / 60))) + startPoint.X);
                        p2.Y = Convert.ToInt32(cir1 * Math.Sin((((2 * Math.PI * (i - 1)) / 60))) + startPoint.Y);
                        shapeInfo = p1.X.ToString() + "," + p1.Y.ToString() + "," + p2.X.ToString() + "," + p2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                        list.Add("circle," + shapeInfo + "," + numberOfShapes);
                    }
                    listBox1.Items.Add("circle," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_polyline
                case "polyline":
                    shapeInfo = pt1.X.ToString() + "," + pt1.Y.ToString() + "," + pt2.X.ToString() + "," + pt2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString(); ;
                    list.Add("polyline," + shapeInfo + "," + numberOfShapes);
                    listBox1.Items.Add("polyline," + numberOfShapes.ToString());

                    break;
                #endregion

                #region Draw_polygon  irrigular
                case "polygon":

                    //      listBox.Items.Add("polygon" + numberOfShapes.ToString());
                    shapeInfo = pt1.X.ToString() + "," + pt1.Y.ToString() + "," + pt2.X.ToString() + "," + pt2.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                    list.Add("polygon," + shapeInfo + "," + numberOfShapes);
                    listBox1.Items.Add("polygon," + numberOfShapes.ToString());

                    break;
                #endregion


            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            if (start == true)
            {
                switch (shape)
                {
                    #region Draw_Spiral
                    case "spiral":
                        double sp1 = (endPoint.X - startPoint.X) / 2;
                        double sp2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 60; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(sp1 * (Math.Cos((((2 * Math.PI * (i)) / 60))) * Math.PI * i / 4) + startPoint.X);
                            p1.Y = Convert.ToInt32(sp1 * (Math.Sin((((2 * Math.PI * (i)) / 60))) * Math.PI * i / 4) + startPoint.Y);
                            p2.X = Convert.ToInt32(sp1 * (Math.Cos((((2 * Math.PI * (i - 1)) / 60))) * Math.PI * (i - 1) / 4) + startPoint.X);
                            p2.Y = Convert.ToInt32(sp1 * (Math.Sin((((2 * Math.PI * (i - 1)) / 60))) * Math.PI * (i - 1) / 4) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }

                        break;
                    #endregion

                    #region Draw_Petal
                    case "petal":
                        double petal1 = (endPoint.X - startPoint.X) / 2;
                        double petal2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 60; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(petal1 * (Math.Cos((((2 * Math.PI * (i)) / 60))) * Math.Cos((((6 * Math.PI * (i)) / 60)))) + startPoint.X);
                            p1.Y = Convert.ToInt32(petal1 * (Math.Sin((((2 * Math.PI * (i)) / 60))) * Math.Cos((((6 * Math.PI * (i)) / 60)))) + startPoint.Y);
                            p2.X = Convert.ToInt32(petal1 * (Math.Cos((((2 * Math.PI * (i - 1)) / 60))) * Math.Cos((((6 * Math.PI * (i - 1)) / 60)))) + startPoint.X);
                            p2.Y = Convert.ToInt32(petal1 * (Math.Sin((((2 * Math.PI * (i - 1)) / 60))) * Math.Cos((((6 * Math.PI * (i - 1)) / 60)))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }

                        break;
                    #endregion

                    #region Draw_cardioid
                    case "cardioid":
                        double c1 = (endPoint.X - startPoint.X) / 2;
                        double c2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 60; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(c1 * (2 * Math.Cos((((2 * Math.PI * (i)) / 60))) - Math.Cos((((4 * Math.PI * (i)) / 60)))) + startPoint.X);
                            p1.Y = Convert.ToInt32(c2 * (2 * Math.Sin((((2 * Math.PI * (i)) / 60))) - Math.Sin((((4 * Math.PI * (i)) / 60)))) + startPoint.Y);
                            p2.X = Convert.ToInt32(c1 * (2 * Math.Cos((((2 * Math.PI * (i - 1)) / 60))) - Math.Cos((((4 * Math.PI * (i - 1)) / 60)))) + startPoint.X);
                            p2.Y = Convert.ToInt32(c2 * (2 * Math.Sin((((2 * Math.PI * (i - 1)) / 60))) - Math.Sin((((4 * Math.PI * (i - 1)) / 60)))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }

                        break;
                    #endregion

                    #region Draw_Line
                    case "line":
                        pen.Color = color;
                        pen.Width = width;
                        e.Graphics.DrawLine(pen, startPoint, endPoint);
                        break;
                    #endregion

                    #region Draw_Triangle
                    case "triangle":
                        double t1 = (endPoint.X - startPoint.X) / 2;
                        double t2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 3; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(t1 * Math.Cos((((2 * Math.PI * (i)) / 3) + Math.PI / 2)) + startPoint.X);
                            p1.Y = Convert.ToInt32(t1 * Math.Sin((((2 * Math.PI * (i)) / 3) + Math.PI / 2)) + startPoint.Y);
                            p2.X = Convert.ToInt32(t1 * Math.Cos((((2 * Math.PI * (i - 1)) / 3) + Math.PI / 2)) + startPoint.X);
                            p2.Y = Convert.ToInt32(t1 * Math.Sin((((2 * Math.PI * (i - 1)) / 3) + Math.PI / 2)) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Square
                    case "square":
                        double W1 = (endPoint.X - startPoint.X) / 2;
                        double H1 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 4; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(W1 * Math.Cos((((2 * Math.PI * (i)) / 4) + (Math.PI / 4))) + startPoint.X);
                            p1.Y = Convert.ToInt32(W1 * Math.Sin((((2 * Math.PI * (i)) / 4) + (Math.PI / 4))) + startPoint.Y);
                            p2.X = Convert.ToInt32(W1 * Math.Cos((((2 * Math.PI * (i - 1)) / 4) + (Math.PI / 4))) + startPoint.X);
                            p2.Y = Convert.ToInt32(W1 * Math.Sin((((2 * Math.PI * (i - 1)) / 4) + (Math.PI / 4))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Rectangle
                    case "rectangle":
                        double W = (endPoint.X - startPoint.X) / 2;
                        double H = (endPoint.Y - startPoint.Y) / 2;
                        double theta = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 4; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(W * Math.Cos((((2 * Math.PI * (i)) / 4 + (Math.PI / 4)))) + startPoint.X);
                            p1.Y = Convert.ToInt32(H * Math.Sin((((2 * Math.PI * (i)) / 4 + (Math.PI / 4)))) + startPoint.Y);
                            p2.X = Convert.ToInt32(W * Math.Cos((((2 * Math.PI * (i - 1)) / 4 + (Math.PI / 4)))) + startPoint.X);
                            p2.Y = Convert.ToInt32(H * Math.Sin((((2 * Math.PI * (i - 1)) / 4 + (Math.PI / 4)))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Pentagon
                    case "pentagon":
                        double pen1 = (endPoint.X - startPoint.X) / 2;
                        //  double pen2 = (endPoint.Y - startPoint.Y) / 2;
                        double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 5; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(pen1 * Math.Cos((((2 * Math.PI * (i)) / 5) + Math.PI)) + startPoint.X);
                            p1.Y = Convert.ToInt32(pen1 * Math.Sin((((2 * Math.PI * (i)) / 5) + Math.PI)) + startPoint.Y);
                            p2.X = Convert.ToInt32(pen1 * Math.Cos((((2 * Math.PI * (i - 1)) / 5) + Math.PI)) + startPoint.X);
                            p2.Y = Convert.ToInt32(pen1 * Math.Sin((((2 * Math.PI * (i - 1)) / 5) + Math.PI)) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Hexagon
                    case "hexagon":
                        double h6 = (endPoint.X - startPoint.X) / 2;
                        //  pen2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 6; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(h6 * Math.Cos((((2 * Math.PI * (i)) / 6))) + startPoint.X);
                            p1.Y = Convert.ToInt32(h6 * Math.Sin((((2 * Math.PI * (i)) / 6))) + startPoint.Y);
                            p2.X = Convert.ToInt32(h6 * Math.Cos((((2 * Math.PI * (i - 1)) / 6))) + startPoint.X);
                            p2.Y = Convert.ToInt32(h6 * Math.Sin((((2 * Math.PI * (i - 1)) / 6))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Heptagon
                    case "heptagon":
                        double h7 = (endPoint.X - startPoint.X) / 2;
                        // double  h7 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 7; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(h7 * Math.Cos((((2 * Math.PI * (i)) / 7))) + startPoint.X);
                            p1.Y = Convert.ToInt32(h7 * Math.Sin((((2 * Math.PI * (i)) / 7))) + startPoint.Y);
                            p2.X = Convert.ToInt32(h7 * Math.Cos((((2 * Math.PI * (i - 1)) / 7))) + startPoint.X);
                            p2.Y = Convert.ToInt32(h7 * Math.Sin((((2 * Math.PI * (i - 1)) / 7))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Octagon
                    case "octagon":
                        double oct = (endPoint.X - startPoint.X) / 2;
                        // pen2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 8; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(oct * Math.Cos((((2 * Math.PI * (i)) / 8))) + startPoint.X);
                            p1.Y = Convert.ToInt32(oct * Math.Sin((((2 * Math.PI * (i)) / 8))) + startPoint.Y);
                            p2.X = Convert.ToInt32(oct * Math.Cos((((2 * Math.PI * (i - 1)) / 8))) + startPoint.X);
                            p2.Y = Convert.ToInt32(oct * Math.Sin((((2 * Math.PI * (i - 1)) / 8))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Nonagon
                    case "nonagon":
                        double non = (endPoint.X - startPoint.X) / 2;
                        //  pen2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 9; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(non * Math.Cos((((2 * Math.PI * (i)) / 9))) + startPoint.X);
                            p1.Y = Convert.ToInt32(non * Math.Sin((((2 * Math.PI * (i)) / 9))) + startPoint.Y);
                            p2.X = Convert.ToInt32(non * Math.Cos((((2 * Math.PI * (i - 1)) / 9))) + startPoint.X);
                            p2.Y = Convert.ToInt32(non * Math.Sin((((2 * Math.PI * (i - 1)) / 9))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Circle
                    case "circle":
                        double cir = (endPoint.X - startPoint.X);
                        //   pen2 = (endPoint.Y - startPoint.Y) / 2;
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 60; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(cir * Math.Cos((((2 * Math.PI * (i)) / 60))) + startPoint.X);
                            p1.Y = Convert.ToInt32(cir * Math.Sin((((2 * Math.PI * (i)) / 60))) + startPoint.Y);
                            p2.X = Convert.ToInt32(cir * Math.Cos((((2 * Math.PI * (i - 1)) / 60))) + startPoint.X);
                            p2.Y = Convert.ToInt32(cir * Math.Sin((((2 * Math.PI * (i - 1)) / 60))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    #region Draw_Ellipse
                    case "ellipse":
                        double e1 = (endPoint.X - startPoint.X);
                        double e2 = (endPoint.Y - startPoint.Y);
                        //  double theta1 = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
                        for (int i = 1; i <= 60; i++)
                        {
                            Point p1 = new Point();
                            Point p2 = new Point();
                            p1.X = Convert.ToInt32(e1 * Math.Cos((((2 * Math.PI * (i)) / 60))) + startPoint.X);
                            p1.Y = Convert.ToInt32(e2 * Math.Sin((((2 * Math.PI * (i)) / 60))) + startPoint.Y);
                            p2.X = Convert.ToInt32(e1 * Math.Cos((((2 * Math.PI * (i - 1)) / 60))) + startPoint.X);
                            p2.Y = Convert.ToInt32(e2 * Math.Sin((((2 * Math.PI * (i - 1)) / 60))) + startPoint.Y);
                            pen.Color = color;
                            pen.Width = width;
                            e.Graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                        }
                        break;
                    #endregion

                    ///////////////////new declarations////////////////////////////
                    #region Draw_polyline
                    case "polyline":

                        pt1 = startPoint;
                        pt2 = endPoint;
                        pen.Color = color;
                        pen.Width = width;
                        e.Graphics.DrawLine(pen, pt1, pt2);

                        y = 1;

                        break;
                    #endregion

                    #region Draw_polygon irregular
                    case "polygon":
                        if (x == 0)
                        {
                            pt3 = startPoint;
                        }
                        pt1 = startPoint;
                        pt2 = endPoint;
                        pen.Color = color;
                        pen.Width = width;
                        e.Graphics.DrawLine(pen, pt1, pt2);

                        z = 1;
                        y = 0;
                        x = 1;
                        break;
                    #endregion


                }
            }


            //pen.Color = color;
            //pen.Width = width;


            for (int k = 0; k < list.Count; k++)
            {
                string currentShape = list.ElementAt(k);
                string[] information = currentShape.Split(',');


                if (information[0].Equals("square"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }

                else if (information[0].Equals("rectangle"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));

                }
                else if (information[0].Equals("pentagon"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("hexagon"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("heptagon"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("octagon"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("nonagon"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("ellipse"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("circle"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("freeline"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("triangle"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("polyline"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("polygon"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("line"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("cardioid"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("petal"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }
                else if (information[0].Equals("spiral"))
                {
                    pen.Color = Color.FromArgb(int.Parse(information[5]));
                    pen.Width = int.Parse(information[6]);
                    e.Graphics.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (files == "")
            {
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    files = saveFileDialog1.FileName;
                    FileStream FilePtr = new FileStream(files, FileMode.Create);
                    StreamWriter writer = new StreamWriter(FilePtr);

                    for (int i = 0; i < list.Count; i++)
                    {
                        string str = list.ElementAt(i);
                        writer.WriteLine(str);

                    }
                    writer.Close();
                    FilePtr.Close();
                }
            }
            else
            {
                FileStream FilePtr = new FileStream(files, FileMode.Create);
                StreamWriter writer = new StreamWriter(FilePtr);

                for (int i = 0; i < list.Count; i++)
                {
                    string str = list.ElementAt(i);
                    writer.WriteLine(str);

                }
                writer.Close();
                FilePtr.Close();
            }

        }

        string files = "";

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list.Clear();
            listBox1.Items.Clear();
            pictureBox1.Invalidate();
            Graphics obj;
            obj = pictureBox1.CreateGraphics();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                files = openFileDialog1.FileName;
                FileStream FilePtr = new FileStream(files, FileMode.Open);
                StreamReader reader = new StreamReader(FilePtr);
                // list.RemoveRange(0, list.Count);
                for (int k = 0; !reader.EndOfStream; k++)
                {

                    string currentShape = reader.ReadLine();
                    string[] information = currentShape.Split(',');

                    if (information[0].Equals("square"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        list.Add(currentShape);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("rectangle"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));

                    }
                    else if (information[0].Equals("pentagon"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("hexagon"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("heptagon"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("octagon"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("nonagon"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("ellipse"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("circle"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("freeline"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("triangle"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("polyline"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("polygon"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("line"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        list.Add(currentShape);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("cardioid"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("petal"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        list.Add(currentShape);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    else if (information[0].Equals("spiral"))
                    {
                        listBox1.Items.Add(information[0] + "," + information[7]);
                        pen.Color = Color.FromArgb(int.Parse(information[5]));
                        list.Add(currentShape);
                        pen.Width = int.Parse(information[6]);
                        obj.DrawLine(pen, int.Parse(information[1]), int.Parse(information[2]), int.Parse(information[3]), int.Parse(information[4]));
                    }
                    numberOfShapes = int.Parse(information[7]);
                }


                reader.Close();
                FilePtr.Close();
            }
        }

        //Set_Colors
        //private void toolStripButton12_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = colorDialog1.ShowDialog();

        //    if (result == DialogResult.OK) // Test result.
        //    {
        //        color = colorDialog1.Color;
        //        toolStripButton12.BackColor = color;
        //        toolStripStatusLabel10.Text = color.Name.ToString();

        //    }
        //}

        //set thickness
        //private void toolStripLabel1_Click(object sender, EventArgs e)
        //{
        //    width = int.Parse(toolStripButton13.Text);
        //}

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            y = 0;
            if (z == 1) //polygon
            {
                pen.Width = width;
                pen.Color = color;
                Graphics w = pictureBox1.CreateGraphics();
                w.DrawLine(pen, pt2, pt3);
                shapeInfo = pt2.X.ToString() + "," + pt2.Y.ToString() + "," + pt3.X.ToString() + "," + pt3.Y.ToString() + "," + color.ToArgb() + "," + width.ToString();
                list.Add("polygon," + shapeInfo + "," + numberOfShapes);
            }
            z = 0;
            x = 0;
        }

        List<string> select = new List<string>();
        //SELECT

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics graph = pictureBox1.CreateGraphics();
            if (dlt != 1||rot!=1)
            {
                string sel = listBox1.SelectedItem.ToString();
                string[] information = sel.Split(',');

               //  MessageBox.Show("selected");
                for (int i = 0; i < list.Count; i++)
                {

                    string inf = list.ElementAt(i);
                    string[] info = inf.Split(',');
                    if ((info[0] == information[0]) && (info[7] == information[1]))
                    {
                        //if (rotate == 1)
                        //{
                        //    p1.X = int.Parse(info[1]);
                        //    p1.Y = int.Parse(info[2]);
                        //    p2.X = int.Parse(info[3]);
                        //    p2.Y = int.Parse(info[4]);
                        //}
                        ////info[5] = Color.Gold.ToString();
                        // shapeInfo = info[0].ToString() + "," + info[1].ToString() + "," + info[2].ToString() + "," + info[3].ToString() + "," + info[4].ToString() + "," + info[5].ToString() + "," + info[6].ToString() + "," + info[7].ToString();
                        //select.Add(shapeInfo);
                        //toolStripStatusLabel12.Text = info[0].ToString() + "," + info[7].ToString();

                    }
                }
                pictureBox1.Invalidate();

            }
        }


        private void toolStripButton13_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            v = trackBar1.Value;
            width = v;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                color = colorDialog1.Color;
                button1.BackColor = color;
                toolStripStatusLabel10.Text = color.Name.ToString();

            }
        }

        //shift
        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            string CurrentLine = "";
            if (listBox1.SelectedIndex >= 0)
            {
                if (int.TryParse(textBox1.Text, out x) && int.TryParse(textBox2.Text, out y))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        CurrentLine = list[i];
                        string[] information = CurrentLine.Split(',');
                        if (int.Parse(information[7]) - 1 == listBox1.SelectedIndex)
                        {
                            list[i] = information[0] + "," + (int.Parse(information[1]) + x).ToString() + "," + (int.Parse(information[2]) + y).ToString() + "," + (int.Parse(information[3]) + x).ToString() + "," + (int.Parse(information[4]) + y).ToString() + "," + information[5] + "," + information[6] + "," + information[7];
                        }
                    }
                }
                start = true;
                pictureBox1.Invalidate();
                start = false;
            }
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save?", "Some Title", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    files = saveFileDialog1.FileName;
                    FileStream FilePtr = new FileStream(files, FileMode.Create);
                    StreamWriter writer = new StreamWriter(FilePtr);

                    for (int i = 0; i < list.Count; i++)
                    {
                        string str = list.ElementAt(i);
                        writer.WriteLine(str);

                    }
                    writer.Close();
                    FilePtr.Close();
                }
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                Application.Exit();
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                files = saveFileDialog1.FileName;
                FileStream FilePtr = new FileStream(files, FileMode.Create);
                StreamWriter writer = new StreamWriter(FilePtr);

                for (int i = 0; i < list.Count; i++)
                {
                    string str = list.ElementAt(i);
                    writer.WriteLine(str);

                }
                writer.Close();
                FilePtr.Close();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list.Clear();
            listBox1.Items.Clear();
            pictureBox1.Invalidate();
            numberOfShapes = 0;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list.Clear();
            listBox1.Items.Clear();
            pictureBox1.Invalidate();
            numberOfShapes = 0;
            files = "";
        }
        int dlt = 0;
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlt = 1;
            if (dlt == 1)
            {
                int n = listBox1.SelectedIndex;
                string del = listBox1.SelectedItem.ToString();
                string[] information = del.Split(',');
                int k = 0;
                listBox1.Items.RemoveAt(n);
                for (int i = 0; i < list.Count; i++)
                {

                    string inf = list.ElementAt(i);
                    string[] info = inf.Split(',');
                    if ((info[0] == information[0]) && (info[7] == information[1]))
                    {
                        list.RemoveAt(i);
                        i--;
                        k++;

                    }
                }
                pictureBox1.Invalidate();
            }
            dlt = 0;
            // MessageBox.Show(k.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {

            {
                int Angle = 0;
                double  xNew1, yNew1, xNew2, yNew2, xNew3, yNew3, xNew4, yNew4;
                int x1, y1, x2, y2,m=0;
                string CurrentLine = "";
                if (listBox1.SelectedIndex >= 0)
                {
                    if (int.TryParse(textBox3.Text, out Angle))
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            CurrentLine = list[i];
                            string[] information = CurrentLine.Split(',');
                            if (int.Parse(information[7]) - 1 == listBox1.SelectedIndex)
                            {
                                if (m == 0)
                                {
                                    xCenter = float.Parse(information[1]);
                                    yCenter = float.Parse(information[2]);
                                    m = 1;
                                }
                                //xCenter = (double.Parse(information[1]) + double.Parse(information[3])) / 2;
                                //yCenter = (double.Parse(information[2]) + double.Parse(information[4])) / 2;
                                xNew1 = double.Parse(information[1]) - xCenter;
                                yNew1 = double.Parse(information[2]) - yCenter;
                                xNew2 = double.Parse(information[3]) - xCenter;
                                yNew2 = double.Parse(information[4]) - yCenter;//shifting to the orgin
                                xNew3 = (xNew1 * Math.Cos(Angle)) - (yNew1 * Math.Sin(Angle));
                                yNew3 = (xNew1 * Math.Sin(Angle)) + (yNew1 * Math.Cos(Angle));
                                xNew4 = (xNew2 * Math.Cos(Angle)) - (yNew2 * Math.Sin(Angle));
                                yNew4 = (xNew2 * Math.Sin(Angle)) + (yNew2 * Math.Cos(Angle));
                                x1 = (int)(xNew3 + xCenter);
                                y1 = (int)(yNew3 + yCenter);
                                x2 = (int)(xNew4 + xCenter);
                                y2 = (int)(yNew4 + yCenter);
                                list[i] = information[0] + "," + x1.ToString() + "," + y1.ToString() + "," + x2.ToString() + "," + y2.ToString() + "," + information[5] + "," + information[6]+ "," + information[7];
                            }
                        }
                        m = 0;
                    }
                    start = true;
                    pictureBox1.Invalidate();
                    start = false;
                }
            }





            
            }
        }
    }
