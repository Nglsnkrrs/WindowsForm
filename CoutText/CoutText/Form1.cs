using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CoutText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetProgress_Click(object sender, EventArgs e)
        {
            string fileName = textBox_FileName.Text + ".txt";

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int countLines = (File.ReadAllLines(fileName)).Length;

                progressBar.Minimum = 0;
                progressBar.Maximum = countLines;
                progressBar.Step = 1;
                using (var reader = new StreamReader(fileName))
                {
                    int linesRead = 0;
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        linesRead++;
                        progressBar.Value = linesRead;

                        label_Progress.Text = $"{linesRead} / {countLines}";

                        Task.Delay(10);
                    }
                }

                MessageBox.Show("Чтение файла завершено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonGetProgress.Enabled = true;
            }

        }
    }
}

