using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze {
    public partial class Form1 : Form {
        private int playerX = 10;
        private int playerY = 67;
        private const int playerSize = 20;
        private bool isKeyDown = false;
        private bool exit1Reached = false;
        private bool exit2Reached = false;
        public Form1() {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaximizeBox = false;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.DoubleBuffered = true;
        }
        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            try {
                Bitmap im = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"\Labyrinth.png");
                g.DrawImage(im, 2, 57, 405, 405);
                im.Dispose();
            }
            catch { };
            g.FillRectangle(Brushes.Red, playerX, playerY, playerSize, playerSize);
            Rectangle exit1 = new Rectangle(175, 62, 20, 20);
            Rectangle exit2 = new Rectangle(215, 437, 20, 20);
            g.FillRectangle(Brushes.Green, exit1);
            g.FillRectangle(Brushes.Blue, exit2);
            if (exit1Reached && exit2Reached) {
                g.DrawString("You Win!", Font, Brushes.Black, ClientSize.Width / 2, ClientSize.Height / 2);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up)
                playerY -= 5;
            else if (e.KeyCode == Keys.Down)
                playerY += 5;
            else if (e.KeyCode == Keys.Left)
                playerX -= 5;
            else if (e.KeyCode == Keys.Right)
                playerX += 5;
            if (playerX >= 155 && playerX <= 195 && playerY <= 80)
                exit1Reached = true;
            if (playerX >= 195 && playerX <= 235 && playerY >= 415)
                exit2Reached = true;
            Invalidate();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            isKeyDown = false;
        }
    }
}

