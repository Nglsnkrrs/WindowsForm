using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DollarRate {
    public partial class Form1 : Form {
        private List<double> rates;
        public Form1() {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink; // запрет изменения размера
            this.MaximizeBox = false; // запрет развёртывания на весь экран
            // список с курсом доллара (пример данных)
            rates = new List<double> { 71.5, 70.8, 72.3, 73.1, 74.2, 75.1, 76.5, 76.2, 77.5, 76.8, 75.3, 74.9 };
        }
        private void Form1_Paint(object sender, PaintEventArgs e) {
            DrawChart(e.Graphics);
        }
        private void DrawChart(Graphics g) { // определение размеров графика
            int width = ClientSize.Width - 50;
            int height = ClientSize.Height - 50;
            int offsetX = 20;
            int offsetY = 20;
            // рисование осей
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, offsetX, offsetY, offsetX, height);
            g.DrawLine(axisPen, offsetX, height, width, height);
            // прорисовка вертикальной шкалы
            int interval = height / 10;
            for (int i = 0; i <= 10; i++)
                g.DrawString((i * 10).ToString(), Font, Brushes.Black, 0, height - i * interval);
            // прорисовка горизонтальной шкалы
            int xInterval = width / rates.Count;
            for (int i = 0; i < rates.Count; i++)
                g.DrawString((i + 1).ToString(), Font, Brushes.Black, offsetX + i * xInterval, height + 5);
            // рисование графика
            Pen graphPen = new Pen(Color.Blue, 2);
            for (int i = 0; i < rates.Count - 1; i++)
                g.DrawLine(graphPen, offsetX + i * xInterval, height - (int)(rates[i] * 4), offsetX + (i + 1) * xInterval, height - (int)(rates[i + 1] * 4));
            g.Dispose();
        }
    }
}

/*Задание 5. Создайте приложение Windows Forms, которое будет рисовать график на клиентской 
области формы. Этот график должен отображать колебания курса доллара за последний год. 
Колебания курса определите сами. График должен иметь две шкалы.*/