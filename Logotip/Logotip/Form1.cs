using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Logotip
{
    public partial class Form1 : Form
    {
        private Bitmap companyLogo;
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(600, 400);
            this.Text = "Динамический логотип компании";
            this.Paint += MainForm_Paint;
            this.DoubleBuffered = true;

            GenerateLogo();
        }

        private void GenerateLogo()
        {
            companyLogo = new Bitmap(400, 200);

            using (Graphics g = Graphics.FromImage(companyLogo))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.Clear(Color.White);

                Rectangle logoRect = new Rectangle(0, 0, companyLogo.Width, companyLogo.Height);
                using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                    logoRect, Color.LightSkyBlue, Color.DeepSkyBlue, 45f))
                {
                    g.FillRectangle(bgBrush, logoRect);
                }

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(20, 20, 160, 160);
                    path.AddEllipse(40, 40, 120, 120);
                    using (SolidBrush shapeBrush = new SolidBrush(Color.FromArgb(150, 255, 255, 255)))
                    {
                        g.FillPath(shapeBrush, path);
                    }
                    using (Pen shapePen = new Pen(Color.White, 3))
                    {
                        g.DrawPath(shapePen, path);
                    }
                }

                string companyName = "Nexus Dynamics";
                Font logoFont = new Font("Arial", 24, FontStyle.Bold);
                PointF textPosition = new PointF(200, 80);

                using (GraphicsPath textPath = new GraphicsPath())
                {
                    textPath.AddString(companyName, logoFont.FontFamily,
                                     (int)logoFont.Style, g.DpiY * logoFont.SizeInPoints / 72,
                                     textPosition, StringFormat.GenericDefault);

                    for (int i = 0; i < 5; i++)
                    {
                        using (Pen outlinePen = new Pen(Color.DarkBlue, 1))
                        {
                            outlinePen.LineJoin = LineJoin.Round;
                            g.DrawPath(outlinePen, textPath);
                        }
                    }

                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        g.FillPath(textBrush, textPath);
                    }
                }

                string slogan = "Innovation Beyond Limits";
                Font sloganFont = new Font("Arial", 12, FontStyle.Italic);
                using (SolidBrush sloganBrush = new SolidBrush(Color.Navy))
                {
                    g.DrawString(slogan, sloganFont, sloganBrush, 200, 130);
                }

                using (Pen decorPen = new Pen(Color.White, 2))
                {
                    decorPen.DashStyle = DashStyle.Dot;
                    g.DrawLine(decorPen, 200, 160, 380, 160);
                }
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (companyLogo != null)
            {
                int x = (this.ClientSize.Width - companyLogo.Width) / 2;
                int y = (this.ClientSize.Height - companyLogo.Height) / 2;
                e.Graphics.DrawImage(companyLogo, x, y);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}