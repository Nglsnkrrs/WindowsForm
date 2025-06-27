using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandardMenu
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null; 
        public Form1()
        {
            InitializeComponent();
            fontToolStripComboBox.SelectedIndex = 0;
            fontSizeToolStripComboBox.SelectedIndex = 2;
            saveAs.Filter = "Text File(*.rtf)|*.rtf|StandartMenu File (*.tnf)|*.tnf";
        }

        private void showMenuHelpToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            helpToolStripMenuItem.Visible = item.Checked;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox.Text = fileText;

            MessageBox.Show("Файл открыт");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            currentFilePath = openFileDialog.FileName; 
            try
            {
                if (currentFilePath.EndsWith(".rtf"))
                    richTextBox.LoadFile(currentFilePath);
                else
                    richTextBox.Text = File.ReadAllText(currentFilePath);

                MessageBox.Show("Файл открыт");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия файла: {ex.Message}");
            }
        }

        private void boldToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            Font oldFont, newFont;
            oldFont = richTextBox.SelectionFont;
            bool stateChecked = ((ToolStripButton)sender).Checked;

            if (stateChecked) 
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            }

            richTextBox.SelectionFont = newFont;
            richTextBox.Focus();

            boldToolStripMenuItem.CheckedChanged -= 
                new EventHandler(boldToolStripMenuItem_CheckedChanged);
            boldToolStripMenuItem.Checked = stateChecked;
            boldToolStripMenuItem.CheckedChanged +=
               new EventHandler(boldToolStripMenuItem_CheckedChanged);
        }

        private void italicToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            Font oldFont, newFont;
            oldFont = richTextBox.SelectionFont;
            bool stateChecked = ((ToolStripButton)sender).Checked;

            if (stateChecked)
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            }

            richTextBox.SelectionFont = newFont;
            richTextBox.Focus();

            italicToolStripMenuItem.CheckedChanged -=
                new EventHandler(italicToolStripMenuItem_CheckedChanged);
            italicToolStripMenuItem.Checked = stateChecked;
            italicToolStripMenuItem.CheckedChanged +=
               new EventHandler(italicToolStripMenuItem_CheckedChanged);
        }

        private void underlineToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            Font oldFont, newFont;
            oldFont = richTextBox.SelectionFont;
            bool stateChecked = ((ToolStripButton)sender).Checked;

            if (stateChecked)
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
            }
            else
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            }

            richTextBox.SelectionFont = newFont;
            richTextBox.Focus();

            undelineToolStripMenuItem.CheckedChanged -=
                new EventHandler(undelineToolStripMenuItem_CheckedChanged);
            undelineToolStripMenuItem.Checked = stateChecked;
            undelineToolStripMenuItem.CheckedChanged +=
               new EventHandler(undelineToolStripMenuItem_CheckedChanged);
        }

        private void boldToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            boldToolStripButton.Checked = boldToolStripMenuItem.Checked;
        }

        private void italicToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            italicToolStripButton.Checked = italicToolStripMenuItem.Checked;
        }

        private void undelineToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            underlineToolStripButton.Checked = undelineToolStripMenuItem.Checked;
        }

        private void fontToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontToolStripComboBox.SelectedItem == null) return;

            string fontName = fontToolStripComboBox.SelectedItem.ToString();
            float fontSize;

            if (fontSizeToolStripComboBox.SelectedItem != null)
            {
                fontSize = float.Parse(fontSizeToolStripComboBox.SelectedItem.ToString());
            }
            else
            {
                fontSize = richTextBox.Font.Size;
            }

            FontStyle style = richTextBox.SelectionFont?.Style ?? FontStyle.Regular;
            Font newFont = new Font(fontName, fontSize, style);

            richTextBox.SelectionFont = newFont;
            richTextBox.Focus();
        }

        private void fontSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontSizeToolStripComboBox.SelectedItem == null) return;

            float fontSize = float.Parse(fontSizeToolStripComboBox.SelectedItem.ToString());
            string fontName;

            if (fontToolStripComboBox.SelectedItem != null)
            {
                fontName = fontToolStripComboBox.SelectedItem.ToString();
            }
            else
            {
                fontName = richTextBox.Font.FontFamily.Name;
            }

            FontStyle style = richTextBox.SelectionFont?.Style ?? FontStyle.Regular;
            Font newFont = new Font(fontName, fontSize, style);

            richTextBox.SelectionFont = newFont;
            richTextBox.Focus();
        }

        private void leftToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (leftToolStripMenuItem.Checked)
            {
                centreToolStripMenuItem.Checked = false;
                rightToolStripMenuItem.Checked = false;

                lefttoolStripButton.Checked = true;
                centreStripButton.Checked = false;
                righttoolStripButton.Checked = false;

                richTextBox.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void centreToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (centreToolStripMenuItem.Checked)
            {
                leftToolStripMenuItem.Checked = false;
                rightToolStripMenuItem.Checked = false;

                lefttoolStripButton.Checked = false;
                centreStripButton.Checked = true;
                righttoolStripButton.Checked = false;

                richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void rightToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (rightToolStripMenuItem.Checked)
            {
                leftToolStripMenuItem.Checked = false;
                centreToolStripMenuItem.Checked = false;

                lefttoolStripButton.Checked = false;
                centreStripButton.Checked = false;
                righttoolStripButton.Checked = true;

                richTextBox.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void lefttoolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lefttoolStripButton.Checked)
            {
                richTextBox.SelectionAlignment = HorizontalAlignment.Left;

                centreStripButton.Checked = false;
                righttoolStripButton.Checked = false;

                leftToolStripMenuItem.Checked = true;
                centreToolStripMenuItem.Checked = false;
                rightToolStripMenuItem.Checked = false;
            }
            richTextBox.Focus();
        }

        private void centreStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (centreStripButton.Checked)
            {
                richTextBox.SelectionAlignment = HorizontalAlignment.Center;

                lefttoolStripButton.Checked = false;
                righttoolStripButton.Checked = false;

                leftToolStripMenuItem.Checked = false;
                centreToolStripMenuItem.Checked = true;
                rightToolStripMenuItem.Checked = false;
            }
            richTextBox.Focus();
        }

        private void righttoolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            if (righttoolStripButton.Checked)
            {
                richTextBox.SelectionAlignment = HorizontalAlignment.Right;

                lefttoolStripButton.Checked = false;
                centreStripButton.Checked = false;

                leftToolStripMenuItem.Checked = false;
                centreToolStripMenuItem.Checked = false;
                rightToolStripMenuItem.Checked = true;
            }
            richTextBox.Focus();
        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тернавская Валерия Романовна 27.06.2025","Информация");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveAs.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = saveAs.FileName;
            File.WriteAllText(fileName, richTextBox.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionLength > 0)
            {
                richTextBox.Copy();
                richTextBox.Focus();

            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox.Paste();
                richTextBox.Focus();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.TextLength > 0)
            {
                richTextBox.Cut();
                richTextBox.Focus();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.TextLength > 0)
            {
                richTextBox.SelectAll();
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            richTextBox.BackColor = colorDialog.Color;
        }

        private void colorFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = colorDialog.Color;
                richTextBox.Focus();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                if (fontToolStripComboBox.SelectedItem != null && fontSizeToolStripComboBox.SelectedItem != null)
                {
                    fontDialog.Font = new Font(
                        fontToolStripComboBox.SelectedItem.ToString(),
                        float.Parse(fontSizeToolStripComboBox.SelectedItem.ToString()),
                        richTextBox.SelectionFont?.Style ?? FontStyle.Regular);
                }
                else
                {
                    fontDialog.Font = richTextBox.SelectionFont ?? richTextBox.Font;
                }

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionFont = fontDialog.Font;

                    UpdateFontComboBoxes(fontDialog.Font);

                    richTextBox.Focus();
                }
            }
        }
        private void UpdateFontComboBoxes(Font font)
        {
            string fontName = font.Name;
            int fontIndex = fontToolStripComboBox.Items.IndexOf(fontName);
            if (fontIndex >= 0)
            {
                fontToolStripComboBox.SelectedIndex = fontIndex;
            }
            else
            {
                fontToolStripComboBox.Items.Add(fontName);
                fontToolStripComboBox.SelectedIndex = fontToolStripComboBox.Items.Count - 1;
            }

            string fontSize = font.SizeInPoints.ToString("0.##");
            int sizeIndex = fontSizeToolStripComboBox.Items.IndexOf(fontSize);
            if (sizeIndex >= 0)
            {
                fontSizeToolStripComboBox.SelectedIndex = sizeIndex;
            }
            else
            {
                fontSizeToolStripComboBox.Items.Add(fontSize);
                fontSizeToolStripComboBox.SelectedIndex = fontSizeToolStripComboBox.Items.Count - 1;
            }
        }

        private void CopytoolStripButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }
        private void CuttoolStripButton_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }
        private void PastetoolStripButton3_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void UndotoolStripButton4_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.CanUndo)
            {
                richTextBox.Undo();
            }
        }

        private void UpdateUndoRedoButtons()
        {
            undoToolStripMenuItem.Enabled = richTextBox.CanUndo;
            UndotoolStripButton4.Enabled = richTextBox.CanUndo;
            cutToolStripMenuItem.Enabled = richTextBox.SelectionLength > 0;
            copyToolStripMenuItem.Enabled = richTextBox.SelectionLength > 0;
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();

        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateUndoRedoButtons();
        }

        
    }
}
