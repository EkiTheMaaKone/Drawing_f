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
        public double numPoints = 0;
        public double inCircle = 0;
        public Point originPoint = new Point(0, 0);
        

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            drawPoint(rnd.Next(0,500 * accVar), rnd.Next(0, 500 * accVar));
            update_labels();
            drawFirstCircle();
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            drawFirstCircle();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                drawPoint(rnd.Next(0, 500 * accVar), rnd.Next(0, 500 * accVar));
            }
            update_labels();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            drawFirstCircle();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                drawPoint(rnd.Next(0, 500 * accVar), rnd.Next(0, 500 * accVar));
            }
            update_labels();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            drawFirstCircle();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                drawPoint(rnd.Next(0, 500 * accVar), rnd.Next(0, 500 * accVar));
            }
            update_labels();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            drawFirstCircle();
            Random rnd = new Random();
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                drawPoint(rnd.Next(0, 500*accVar), rnd.Next(0, 500*accVar));
            }
            update_labels();
        }
        public int accVar=50;

        //Non form functions-------------------------------------------------------------------------
        private void drawFirstCircle()
        {
            Graphics g = Graphics.FromHwnd(PiBox.Handle);
            Pen penOn = new Pen(Color.Red);
            //g.DrawEllipse(penOn, -500, -500, 1000, 1000);
            g.Dispose();
        }
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

        private void update_labels()
        {
            label4.Text = String.Format("{0} out of {1} points are inside the circle",(inCircle).ToString("0"), (numPoints).ToString("0"));
            //label2.Text = (numPoints).ToString("0.");
            label1.Text = "Approximation of Pi is Currently:" + ((inCircle / numPoints) * 4).ToString("0.######");
        }

        
    }
}
