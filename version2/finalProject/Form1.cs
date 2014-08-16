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
using System.Drawing.Imaging;

namespace finalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Img = pictureBox1.Image;
            //initialize a blank image for your PictureBox
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        Graphics g;
        Pen myPen = new Pen(Color.Red);
        Point p = new Point();
        Point p2 = new Point();
        bool flag = false;
        string shape = "";
        private Image Img;
        public int a = 0;
        public int b = 0;
        public float width = 0;
        public Color color = Color.Black;
        //////////////////////////////////////////////////////////////////////////////////////
        List<myLine> listOfLines = new List<myLine>();
        List<myCircle> listOfCircles = new List<myCircle>();
        List<myTriangle> listOfTriangles = new List<myTriangle>();
        List<mySquare> listOfSquares = new List<mySquare>();
        List<myRectangle> listOfRectangles = new List<myRectangle>();
        List<myPentagon> listOfPentagons = new List<myPentagon>();
        List<myOctagon> listOfOctagons = new List<myOctagon>();
        List<myHexagon> listOfHexagons = new List<myHexagon>();
        List<myHeptagon> listOfHeptagons = new List<myHeptagon>();
        List<myEllipse> listOfEllipses = new List<myEllipse>();
        List<myPetal> listOfPetals = new List<myPetal>();
        //////////////////////////////////////////////////////////////////////
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            p = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

                       flag = false;

                       switch (shape)
                       {
                           case "line":
                               listOfLines.Add(new myLine(p, p2,width,color));
                               comboBox1.Items.Add("line " + listOfLines.Count);
                               break;
                           case "circle":
                               listOfCircles.Add(new myCircle(p, p2,width,color));
                               comboBox1.Items.Add("circle " + listOfCircles.Count);
                               break;
                           case "triangle":
                               listOfTriangles.Add(new myTriangle(p, p2,width,color));
                               comboBox1.Items.Add("triangle " + listOfTriangles.Count);
                               break;
                           case "square":
                               listOfSquares.Add(new mySquare(p, p2,width,color));
                               comboBox1.Items.Add("square " + listOfSquares.Count);
                               break;
                           case "rectangle":
                               listOfRectangles.Add(new myRectangle(p, p2,width,color));
                               comboBox1.Items.Add("rectangle " + listOfRectangles.Count);
                               break;
                           case "pentagon":
                               listOfPentagons.Add(new myPentagon(p, p2,width,color));
                               comboBox1.Items.Add("pentagon " + listOfPentagons.Count);
                               break;
                           case "octagon":
                               listOfOctagons.Add(new myOctagon(p, p2,width,color));
                               comboBox1.Items.Add("octagon " + listOfOctagons.Count);
                               break;
                           case "hexagon":
                               listOfHexagons.Add(new myHexagon(p, p2,width,color));
                               comboBox1.Items.Add("hexagon " + listOfHexagons.Count);
                               break;
                           case "heptagon":
                               listOfHeptagons.Add(new myHeptagon(p, p2,width,color));
                               comboBox1.Items.Add("heptagon " + listOfHeptagons.Count);
                               break;
                           case "ellipse":
                               listOfEllipses.Add(new myEllipse(p, p2,width,color));
                               comboBox1.Items.Add("ellipse " + listOfEllipses.Count);
                               break;
                           case "petal":
                               listOfPetals.Add(new myPetal(p, p2, width, color));
                               comboBox1.Items.Add("petal " + listOfPetals.Count);
                               break;
                           
                         /*  case "Nonagon":
                               listOfNonagons.Add(new myNonagon(p, p2,width,color));
                               break;
                               */
                       }         
                     }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                p2 = e.Location;

                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //myPen.Width = 3;

            if (flag)
            {
                switch (shape)
                {
                    case "line":
                        myLine line = new myLine(p, p2,width,color);
                        line.draw(g, myPen);
                        break;
                    case "circle":
                        myCircle circle = new myCircle(p, p2,width,color);
                        circle.draw(g, myPen);
                        break;
                    case "triangle":
                        myTriangle triangle = new myTriangle(p, p2,width,color);
                        triangle.draw(g, myPen);
                        break;
                    case "square":
                        mySquare square = new mySquare(p, p2,width,color);
                        square.draw(g, myPen);
                        break;
                    case "rectangle":
                        myRectangle rectangle = new myRectangle(p, p2,width,color);
                        rectangle.draw(g, myPen);
                        break;
                    case "pentagon":
                        myPentagon pentagon = new myPentagon(p, p2,width,color);
                        pentagon.draw(g, myPen);
                        break;
                    case "octagon":
                        myOctagon octagon = new myOctagon(p, p2,width,color);
                        octagon.draw(g, myPen);
                        break;
                    case "hexagon":
                        myHexagon hexagon = new myHexagon(p, p2,width,color);
                        hexagon.draw(g, myPen);
                        break;
                    case "heptagon":
                        myHeptagon heptagon = new myHeptagon(p, p2,width,color);
                        heptagon.draw(g, myPen);
                        break;
                    case "ellipse":
                        myEllipse ellipse = new myEllipse(p, p2,width,color);
                        ellipse.draw(g, myPen);
                        break;
                    case "petal":
                        myPetal petal = new myPetal(p, p2, width, color);
                        petal.draw(g, myPen);
                        break;
                    
                    /*case "nonagon":
                        myNonagon nonagon = new myNonagon(p, p2,width,color);
                        nonagon.draw(g, myPen);
                        break; 
                        */
                }
            }
            /////// for each
            foreach (myLine line in listOfLines)
            {
                line.draw(g, myPen);
            }

            foreach (myCircle circle in listOfCircles)
            {
                circle.draw(g, myPen);
            }
            foreach (myTriangle triangle in listOfTriangles)
            {
                triangle.draw(g, myPen);
            }
            foreach (mySquare square in listOfSquares)
            {
                square.draw(g, myPen);
            }
            foreach (myRectangle rectangle in listOfRectangles)
            {
                rectangle.draw(g, myPen);
            }
            foreach (myPentagon pentagon in listOfPentagons)
            {
                pentagon.draw(g, myPen);
            }
            foreach (myOctagon octagon in listOfOctagons)
            {
                octagon.draw(g, myPen);
            }
            foreach (myHexagon hexagon in listOfHexagons)
                hexagon.draw(g, myPen);

            foreach (myHeptagon heptagon in listOfHeptagons)
            {
                heptagon.draw(g, myPen);
            }

            foreach (myEllipse ellipse in listOfEllipses)
            {
                ellipse.draw(g, myPen);
            }
            foreach (myPetal petal in listOfPetals)
            {
                petal.draw(g, myPen);
            }
 /*           foreach (myNonagon nonagon in listOfNonagon)
            {
                nonagon.draw(g, myPen);
            }
*/
        }
        ///////button
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            shape = "line";
        }         
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            shape = "circle";
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            shape = "triangle";
       }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            shape = "square";
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            shape = "rectangle";
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            shape = "pentagon";
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            shape = "octagon";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            shape = "heptagon";
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            shape = "hexagon";
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            shape = "ellipse";
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            shape = "petal";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listOfLines.Clear();
            listOfCircles.Clear();
            listOfOctagons.Clear();
            listOfPentagons.Clear();
            listOfRectangles.Clear();
            listOfSquares.Clear();
            listOfTriangles.Clear();
            listOfEllipses.Clear();
            listOfHeptagons.Clear();
            listOfHexagons.Clear();
            listOfPetals.Clear();
            pictureBox1.Invalidate();
            comboBox1.Items.Clear();
        }
        private void LoadImage()
        {
            //we set the picturebox size according to image, we can get image width and height with the help of Image.Width and Image.height properties.
            int imgWidth = Img.Width;
            int imghieght = Img.Height;
            pictureBox1.Width = imgWidth;
            pictureBox1.Height = imghieght;
            pictureBox1.Image = Img;


        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdlg = new SaveFileDialog();
            {
                sfdlg.Title = "Save Dialog";
                sfdlg.Filter = "Images|*.png;*.bmp;*.jpg";
                //ImageFormat format = ImageFormat.Jpeg;
                //  sfdlg.Filter = "Bitmap Images (*.bmp)|*.bmp|All files(*.*)|*.*";
                if (sfdlg.ShowDialog(this) == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    {
                        pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        // pictureBox1.Image.Save("c://cc.Jpg");
                        bmp.Save(sfdlg.FileName, ImageFormat.Png);
                        MessageBox.Show("Saved Successfully.....");

                    }
                }

            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog Dlg = new OpenFileDialog();
            Dlg.FileName = "";
            Dlg.Filter = "All Images|*.jpg; *.bmp; *.png";
            Dlg.Title = "Select image";
            if (Dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Img = Image.FromFile(Dlg.FileName);
                //Image.FromFile(String) method creates an image from the specifed file, here dlg.Filename contains the name of the file from which to create the image
                LoadImage();
                Img = (Bitmap)pictureBox1.Image;
            }
        }

        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            width = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string z = textBox2.Text;
            a = Convert.ToInt32(s);
            b = Convert.ToInt32(z);
            string selected = comboBox1.SelectedItem.ToString();

            if (selected[0] == 'l')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myLine line = listOfLines[index];
                line.translate(a, -1 *b);

                listOfLines[index] = line;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'c')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myCircle circle = listOfCircles[index];
                circle.translate(a, -1 * b);

                listOfCircles[index] = circle;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 't')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myTriangle triangle = listOfTriangles[index];
                triangle.translate(a, -1 * b);

                listOfTriangles[index] = triangle;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 's')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                mySquare square = listOfSquares[index];
                square.translate(a, -1 * b);

                listOfSquares[index] = square;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'r')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myRectangle rectangle = listOfRectangles[index];
                rectangle.translate(a, -1 * b);

                listOfRectangles[index] = rectangle;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'h' && selected[2] == 'p')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myHeptagon heptagon = listOfHeptagons[index];
                heptagon.translate(a, -1 * b);

                listOfHeptagons[index] = heptagon;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'h' && selected[2] == 'x')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myHexagon hexagon = listOfHexagons[index];
                hexagon.translate(a, -1 * b);

                listOfHexagons[index] = hexagon;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'e')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myEllipse ellipse = listOfEllipses[index];
                ellipse.translate(a, -1 * b);

                listOfEllipses[index] = ellipse;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'o')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myOctagon octagon = listOfOctagons[index];
                octagon.translate(a, -1 * b);

                listOfOctagons[index] = octagon;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'p' && selected[2] == 'n')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myPentagon pentagon = listOfPentagons[index];
                pentagon.translate(a, -1 * b);

                listOfPentagons[index] = pentagon;
                pictureBox1.Invalidate();
            }
            else if (selected[0] == 'p' && selected[2] == 't')
            {
                char last = selected[selected.Length - 1];
                int index = (int)Char.GetNumericValue(last);
                index--;

                myPetal petal = listOfPetals[index];
                petal.translate(a, -1 * b);

                listOfPetals[index] = petal;
                pictureBox1.Invalidate();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                color = colorDialog1.Color;
                button2.BackColor = color;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int angle = Convert.ToInt32(this.textBox3.Text);
            angle = -1 * angle;
            //double angleRad = Math.PI * angle / 180.0;
            string[] words = this.comboBox1.SelectedItem.ToString().Split(' ');
            if (words[0] == "line") {
                int i = Convert.ToInt32(words[1]);
                i=i-1;
                    // X & Y before transformation . 
                    myLine line1 = this.listOfLines.ElementAt(i);
                    line1.rotate(angle);
                    listOfLines[i] = line1;
                    pictureBox1.Invalidate();
                }

            if (words[0] == "triangle") {
                int i = Convert.ToInt32(words[1]);
                i=i-1;
                myTriangle tri = this.listOfTriangles.ElementAt(i);
                tri.rotate(angle);
                listOfTriangles[i] = tri;
                pictureBox1.Invalidate();
                
            
            }
            { 
            
            } 
 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            listOfLines.Clear();
            listOfCircles.Clear();
            listOfOctagons.Clear();
            listOfPentagons.Clear();
            listOfRectangles.Clear();
            listOfSquares.Clear();
            listOfTriangles.Clear();
            listOfEllipses.Clear();
            listOfHeptagons.Clear();
            listOfHexagons.Clear();
            pictureBox1.Invalidate();
            listOfPetals.Clear();
            comboBox1.Items.Clear();
        }

    }
}