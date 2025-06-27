using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChessBoard
{
    public partial class Form1 : Form
    {
        private const int CELL_SIZE = 50;
        private bool isWhiteCell = true;
        private Point selectedCell = new Point(-1, -1);
        private Bitmap chessPiecesImage;

        private Dictionary<string, Rectangle> pieceRects = new Dictionary<string, Rectangle>()
        {
            {"white_king", new Rectangle(0, 0, 50, 50)},
            {"white_queen", new Rectangle(50, 0, 50, 50)},
            {"white_bishop", new Rectangle(100, 0, 50, 50)},
            {"white_knight", new Rectangle(150, 0, 50, 50)},
            {"white_rook", new Rectangle(200, 0, 50, 50)},
            {"white_pawn", new Rectangle(250, 0, 50, 50)},
            {"black_king", new Rectangle(0, 50, 50, 50)},
            {"black_queen", new Rectangle(50, 50, 50, 50)},
            {"black_bishop", new Rectangle(100, 50, 50, 50)},
            {"black_knight", new Rectangle(150, 50, 50, 50)},
            {"black_rook", new Rectangle(200, 50, 50, 50)},
            {"black_pawn", new Rectangle(250, 50, 50, 50)}
        };

        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(8 * CELL_SIZE, 8 * CELL_SIZE);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MaximizeBox = false;
            this.Paint += ChessForm_Paint;
            this.MouseClick += ChessForm_MouseClick;

            try
            {
                chessPiecesImage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"\Chessmen.png");
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить изображение фигур!");
            }
        }

        private void ChessForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            DrawChessBoard(g);
            DrawChessPieces(g);
        }

        private void DrawChessBoard(Graphics g)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Brush brush = isWhiteCell ? Brushes.White : Brushes.Black;
                    g.FillRectangle(brush, j * CELL_SIZE, i * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                    isWhiteCell = !isWhiteCell;
                }
                isWhiteCell = !isWhiteCell;
            }
        }

        private void DrawChessPieces(Graphics g)
        {
            if (chessPiecesImage == null) return;

            void DrawPiece(string piece, int x, int y)
            {
                Rectangle destRect = new Rectangle(x * CELL_SIZE, y * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                g.DrawImage(chessPiecesImage, destRect, pieceRects[piece], GraphicsUnit.Pixel);
            }

            DrawPiece("white_rook", 0, 7);
            DrawPiece("white_knight", 1, 7);
            DrawPiece("white_bishop", 2, 7);
            DrawPiece("white_queen", 3, 7);
            DrawPiece("white_king", 4, 7);
            DrawPiece("white_bishop", 5, 7);
            DrawPiece("white_knight", 6, 7);
            DrawPiece("white_rook", 7, 7);

            for (int i = 0; i < 8; i++)
            {
                DrawPiece("white_pawn", i, 6);
            }

            DrawPiece("black_rook", 0, 0);
            DrawPiece("black_knight", 1, 0);
            DrawPiece("black_bishop", 2, 0);
            DrawPiece("black_queen", 3, 0);
            DrawPiece("black_king", 4, 0);
            DrawPiece("black_bishop", 5, 0);
            DrawPiece("black_knight", 6, 0);
            DrawPiece("black_rook", 7, 0);

            for (int i = 0; i < 8; i++)
            {
                DrawPiece("black_pawn", i, 1);
            }
        }

        private void ChessForm_MouseClick(object sender, MouseEventArgs e)
        {
            selectedCell = new Point(e.X / CELL_SIZE, e.Y / CELL_SIZE);
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                string pieceName = GetPieceAt(selectedCell.X, selectedCell.Y);

                if (!string.IsNullOrEmpty(pieceName))
                {
                    contextMenuStrip.Items.Add(pieceName);
                }
                else
                {
                    contextMenuStrip.Items.Add("Свободная клетка");
                }

                contextMenuStrip.Show(this, e.Location);
            }
        }

        private string GetPieceAt(int x, int y)
        {
            if (y == 7)
            {
                switch (x)
                {
                    case 0: case 7: return "Белая ладья";
                    case 1: case 6: return "Белый конь";
                    case 2: case 5: return "Белый слон";
                    case 3: return "Белая ферзь";
                    case 4: return "Белый король";
                }
            }
            if (y == 6) return "Белая пешка";

            if (y == 0)
            {
                switch (x)
                {
                    case 0: case 7: return "Черная ладья";
                    case 1: case 6: return "Черный конь";
                    case 2: case 5: return "Черный слон";
                    case 3: return "Черная ферзь";
                    case 4: return "Черный король";
                }
            }
            if (y == 1) return "Черная пешка";

            return "";
        }
    }
}