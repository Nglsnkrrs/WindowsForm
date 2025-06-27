using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphFunction {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaximizeBox = false;
        }
        private void MainForm_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Pen penSin = new Pen(Color.Red);
            Pen penExp = new Pen(Color.Green);
            Pen penLog = new Pen(Color.Blue);
            
            double xMin = -20; 
            double xMax = 20;
            double step = 0.1; 

            Func<double, double> funcSin = x => Math.Sin(x);
            Func<double, double> funcExp = x => Math.Exp(x);
            Func<double, double> funcLog = x => Math.Log(x);
            for (double x = xMin; x <= xMax; x += step) { 
                float screenX = (float)(x * 20 + Width / 2);
                float screenY = (float)(-x * 20 + Height / 2);
                float screenYSin = (float)(-funcSin(x) * 20 + Height / 2);
                float screenYExp = (float)(-funcExp(x) * 20 + Height / 2);
                float screenYLog = (float)(-funcLog(x) * 20 + Height / 2);
                try {
                    g.DrawEllipse(pen, screenX, Height / 2, 1, 1);
                    g.DrawEllipse(pen, Width / 2, screenY, 1, 1);
                    g.DrawEllipse(penSin, screenX, screenYSin, 1, 1);
                    g.DrawEllipse(penExp, screenX, screenYExp, 1, 1);
                    g.DrawEllipse(penLog, screenX, screenYLog, 1, 1);
                }
                catch { };
            }
            g.Dispose();
        }
    }
}

