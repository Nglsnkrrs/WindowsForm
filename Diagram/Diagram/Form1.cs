using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram {
    public partial class MainForm : Form {
        private List<DataPoint> dataPoints;
        public MainForm() {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaximizeBox = false;
            dataPoints = new List<DataPoint> {
                new DataPoint("Category A", 25),
                new DataPoint("Category B", 50),
                new DataPoint("Category C", 75),
                new DataPoint("Category D", 30),
                new DataPoint("Category E", 60)
            };
        }
        private void MainForm_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            int chartWidth = 400;
            int chartHeight = 300;
            int chartX = (Width - chartWidth) / 2;
            int chartY = (Height - chartHeight) / 2;
            Pen borderPen = new Pen(Color.Black);
            g.DrawRectangle(borderPen, chartX, chartY, chartWidth, chartHeight);
            double totalValue = 0;
            foreach (var point in dataPoints)
                totalValue += point.Value;
            int barWidth = chartWidth / dataPoints.Count;
            int currentX = chartX;
            foreach (var point in dataPoints) {
                int barHeight = (int)((point.Value / totalValue) * chartHeight);
                Brush barBrush = new SolidBrush(Color.Blue);
                g.FillRectangle(barBrush, currentX, chartY + chartHeight - barHeight, barWidth, barHeight);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                g.DrawString(point.Category, Font, Brushes.Black, currentX + barWidth / 2, chartY + chartHeight + 5, format);
                currentX += barWidth;
            }
            g.Dispose();
        }
        private class DataPoint {
            public string Category { get; }
            public double Value { get; }
            public DataPoint(string category, double value) {
                Category = category;
                Value = value;
            }
        }
    }
}

