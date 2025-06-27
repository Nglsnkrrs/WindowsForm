using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShapesDrawing {
    public partial class MainForm : Form {
        private string selectedShape = "Rectangle";
        private bool isDrawing = false;
        private Point startPoint;
        private Point endPoint;
        private Pen drawingPen = new Pen(Color.Black, 2);
        private Bitmap drawingBitmap;
        string strToolTip = "Щёлкните левой кнопкой мыши по форме и переместите указатель";
        public MainForm() {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink; 
            this.MaximizeBox = false; 
            drawingBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            this.Paint += MainForm_Paint;
            this.MouseDown += MainForm_MouseDown;
            this.MouseMove += MainForm_MouseMove;
            this.MouseUp += MainForm_MouseUp;
        }
        private void MainForm_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(drawingBitmap, new Point(0, 0));
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                isDrawing = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e) {
            if (isDrawing) {
                if (drawingBitmap != null) {
                    using (Graphics g = Graphics.FromImage(drawingBitmap)) {
                        g.Clear(Color.White);
                        switch (selectedShape) {
                            case "Rectangle":
                                endPoint = new Point(e.X, e.Y);
                                g.DrawRectangle(drawingPen, GetRectangle(startPoint, endPoint));
                                break;
                            case "Circle":
                                endPoint = new Point(e.X, e.Y);
                                g.DrawEllipse(drawingPen, GetRectangle(startPoint, endPoint));
                                break;
                        }
                    }
                    this.Invalidate();
                }
            }
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e) {
            isDrawing = false;
        }
        private Rectangle GetRectangle(Point p1, Point p2) {
            Rectangle rect = new Rectangle();
            rect.X = Math.Min(p1.X, p2.X);
            rect.Y = Math.Min(p1.Y, p2.Y);
            rect.Width = Math.Abs(p1.X - p2.X);
            rect.Height = Math.Abs(p1.Y - p2.Y);
            return rect;
        }
        private void rectangleButton_Click(object sender, EventArgs e) {
            selectedShape = "Rectangle";
        }
        private void circleButton_Click(object sender, EventArgs e) {
            selectedShape = "Circle";
        }
        private void clearButton_Click(object sender, EventArgs e) {
            if (drawingBitmap != null) {
                using (Graphics g = Graphics.FromImage(drawingBitmap)) {
                    g.Clear(Color.White);
                    this.Invalidate();
                }
            }
        }
        private void saveButton_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string fileName = saveFileDialog.FileName;
                switch (System.IO.Path.GetExtension(fileName).ToLower()) {
                    case ".bmp":
                        drawingBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case ".jpg":
                        drawingBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    default:
                        MessageBox.Show("Unsupported file format");
                        break;
                }
            }
        }
        private void rectangleButton_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(rectangleButton, strToolTip);
        }
        private void circleButton_MouseHover(object sender, EventArgs e) {
            toolTip1.SetToolTip(circleButton, strToolTip);
        }
    }
}

