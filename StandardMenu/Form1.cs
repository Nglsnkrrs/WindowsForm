using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandardMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fontToolStripComboBox.SelectedIndex = 0;
            fontSizeToolStripComboBox.SelectedIndex = 2;
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
            try
            {
                richTextBox.LoadFile("Example.rtf");
            }
            catch { }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox.SaveFile("Example.rtf");
            }
            catch { }
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
            string text = ((ToolStripComboBox)sender).SelectedItem.ToString();
            Font newFont;

            if (richTextBox.SelectionFont == null)
            {
                newFont = new Font(text, richTextBox.Font.Size);
            }
            else
            {
                newFont = new Font(text, richTextBox.SelectionFont.Size,
                    richTextBox.SelectionFont.Style);
            }
            richTextBox.SelectionFont = newFont;
            richTextBox.Focus();
        }

        private void fontSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize = Convert.ToSingle(
                ((ToolStripComboBox)sender).SelectedItem.ToString());
            Font newFont;

            if (richTextBox.SelectionFont == null)
            {
                newFont = new Font(richTextBox.Font.FontFamily, fontSize);
            }
            else
            {
                newFont = new Font(richTextBox.SelectionFont.FontFamily, fontSize);
            }

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
    }
}
