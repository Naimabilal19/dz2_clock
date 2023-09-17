using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock_HM
{
    public partial class Form1 : Form
    {
        double Second = 0;
        double Minutes = 0;
        double Hour = 0;

        public Form1()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += timer1_Tick;

            DateTime date = DateTime.Now;
            textBox1.Text += date;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.SandyBrown);
            Pen pen1 = new Pen(Color.Gray);
            Pen second = new Pen(Color.Blue);
            Pen minutes = new Pen(Color.Black);
            Pen hour = new Pen(Color.Red);

            hour.Width = 3.0f;
            minutes.Width = 3.0f;
            second.Width = 3.0f;
            pen1.Width = 3.0f;
            pen.Width = 3.0f;

            int x = 85;
            int y = 80;
            int width = 200;
            int height = 200;

            g.DrawRectangle(pen, x, y, width, height);
            g.DrawEllipse(pen, x, y, width, height);


            int Lines_Ellipse = 12;


            int centr_x = -15;
            int centr_y = 20;

            const int Count_Lines = 12; 

            for (int i = 0; i < Count_Lines; i++)
            {
                double angle = 2 * Math.PI * i / Count_Lines;
                double radiusX = width / 2;
                double radiusY = height / 2;


                int x1 = (int)(x + width / 2 + (radiusX - Lines_Ellipse) * Math.Cos(angle));
                int y1 = (int)(y + height / 2 + (radiusY - Lines_Ellipse) * Math.Sin(angle));

                int x2 = (int)(x + width / 2 + radiusX * Math.Cos(angle));
                int y2 = (int)(y + height / 2 + radiusY * Math.Sin(angle));


                g.DrawLine(pen1, x1, y1, x2, y2);
            }

            SolidBrush brush = new SolidBrush(Color.Red);
            int x_litleEllips, y_litleEllips;
            x_litleEllips = 174; y_litleEllips = 171;

            g.FillEllipse(brush, x_litleEllips, y_litleEllips, 20, 20);

            Matrix matrix = new Matrix(1, 0, 0, -1, 0, 0);
            g.Transform = matrix;
            g.TranslateTransform(200, 200, MatrixOrder.Append);


            double radiusXSecond = width / 2;
            double radiusYSecond = height / 2;
            int xSecond = (int)(centr_x + radiusXSecond * Math.Cos(Second));
            int ySecond = (int)(centr_y + radiusYSecond * Math.Sin(Second));
            g.DrawLine(second, centr_x, centr_y, xSecond, ySecond);

            double radiusXMinute = width / 2;
            double radiusYMinute = height / 2;
            int xMinute = (int)(centr_x + radiusXMinute * Math.Cos(Minutes));
            int yMinute = (int)(centr_y + radiusYMinute * Math.Sin(Minutes));
            g.DrawLine(minutes, centr_x, centr_y, xMinute, yMinute);

            double radiusXHour = width / 2;
            double radiusYHour = height / 2;
            int xHour = (int)(centr_x + radiusXHour * Math.Cos(Hour));
            int yHour = (int)(centr_y + radiusYHour * Math.Cos(Hour));
            g.DrawLine(hour, centr_x, centr_y, xHour, yHour);


            pen.Dispose();
            pen1.Dispose();
            second.Dispose();
            minutes.Dispose();
            hour.Dispose();
            brush.Dispose();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Second = (now.Second * 360.0 / 60.0) - 90;
            Minutes = (now.Minute * 360.0 / 60.0) - 90;
            Hour = (now.Hour * 360.0 / 12.0 + (now.Minute / 60.0) * (360.0 / 12.0)) - 90;

            this.Invalidate();

        }
    }


}
