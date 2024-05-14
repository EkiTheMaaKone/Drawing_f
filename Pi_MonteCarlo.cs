using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_f
{
    public partial class Pi_MonteCarlo : Form
    {
        public Pi_MonteCarlo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
        }
        //Total number of points
        public double numPoints = 0;
        
        public double inCircle = 0;//Total number of points inside the circle

        
        public int accVar = 50;//The accuracy variable determines how large the
                               //domain is for the randomly generated numbers
                                //Since ints are used the larges the circle, the less likely a random point is to be 
                                //misidentified as being inside the circle.

        Random rnd = new Random(); //Random number engine

        //These button click functions call for a specified number of points to be generated
        private void button1_Click(object sender, EventArgs e)
        {
            generatePoints(1);
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            generatePoints(10);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            generatePoints(100);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            generatePoints(1000);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            generatePoints(Convert.ToInt32(numericUpDown1.Value));
            
        }
        

        //Non form functions-------------------------------------------------------------------------

        //Draws a specified amount of points by calling drawpoint function
        public void generatePoints(int numOfPointsToGen)
        {
            
            for (int i = 0; i < numOfPointsToGen; i++)
            {
                drawPoint(rnd.Next(0, 500 * accVar), rnd.Next(0, 500 * accVar));
            }
            update_labels();
        }


        //Draws a specified point onto the PiBox and updates the running counts of numPoints and inCircle
        public void drawPoint(int x, int y)
        {
            Graphics g = Graphics.FromHwnd(PiBox.Handle);
            SolidBrush brush = new SolidBrush(Color.Black);
            Point dPoint = new Point(x/accVar, y/accVar);
            numPoints++;
            if (x * x + y * y <= 250000*accVar*accVar)
            {
                inCircle++;
                brush.Color = Color.Cyan;
            }
            Rectangle rect = new Rectangle(dPoint, new Size(2, 2));
            g.FillRectangle(brush, rect);
            g.Dispose();
        }

        //updates the labels
        private void update_labels()
        {
            label4.Text = String.Format("{0} out of {1} points are inside the circle",(inCircle).ToString("0"), (numPoints).ToString("0"));
            label1.Text = "Approximation of Pi is Currently:" + ((inCircle / numPoints) * 4).ToString("0.######");
        }

        
    }
}
