using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;
            DateTime now = DateTime.Now;
            g.DrawEllipse(Pens.Black, centerX - 100, centerY - 100, 200, 200);
            DrawHand(g, centerX, centerY, now.Second * 6, 80, Color.Red);
            DrawHand(g, centerX, centerY, now.Minute * 6, 60, Color.Green);
            DrawHand(g, centerX, centerY, Convert.ToInt32((now.Hour % 12) * 30
                + now.Minute * 0.5), 40, Color.Blue);
            g.Dispose();
        }
        private void DrawHand(Graphics g, int centerX, int centerY, int angle, int length, Color color)
        {
            PointF p1 = new PointF(centerX, centerY);
            PointF p2 = new PointF((float)(centerX + length * Math.Sin(angle * Math.PI / 180)),
                                  (float)(centerY - length * Math.Cos(angle * Math.PI / 180)));
            g.DrawLine(new Pen(color, 2), p1, p2);
        }
    }
}
