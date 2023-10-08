using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{

    public partial class Game : Form
    {
        Random random = new Random(DateTime.Now.Millisecond);

        public GameField gameField;
        public Score score;

        public Block currentBlock;
        public Block nextBlock;

        public Font scoreFont;

        public Game()
        {
            InitializeComponent();

            this.gameField = new GameField();
            this.score = new Score();

            this.currentBlock = this.GetRandomBlock();
            this.nextBlock = this.GetRandomBlock();

            PrivateFontCollection myfont = new PrivateFontCollection(); // С ЭТОЙ ВСЕЙ РАДОСТЬЮ - КРАШИТ ПРОГРАММУ
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.ScoreFont))
            {
                var data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                myfont.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            this.scoreFont = new Font(myfont.Families[0], 40);

            myfont.Families[0] = null;
            myfont.Dispose();

            this.buttonStart.Enabled = true;
            this.KeyPreview = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.buttonStart.Enabled = false;
            this.KeyDown += this.Game_KeyUp;

            this.Paint += this.Game_Paint;

            this.Game_Start();
        }

        private Block GetRandomBlock()
        {
            Block block;

            switch (this.random.Next(0, 7))
            {
                case 0: block = new TBlock(); break;
                case 1: block = new OBlock(); break;
                case 2: block = new SBlock(); break;
                case 3: block = new ZBlock(); break;
                case 4: block = new JBlock(); break;
                case 5: block = new LBlock(); break;
                case 6: block = new IBlock(); break;

                default: block = new OBlock(); break; // пришлось добавить этот костыль, так как компилятор ругается,
                                                      // ведь в рандоме от 0 до 7 обязательно может выпасть число вне этих рамок.
            }

            return block;
        }

        private async void Game_Start()
        {
            while (this.gameField.CanSpawnBlock())
            {
                while (!GameField.IsAtBottom(this.currentBlock) && !this.gameField.IsAtBlockDown(this.currentBlock))
                {
                    Point[] points = this.GetRectangleBlock();
                    this.Invalidate(new Rectangle((points[0].X - 1) * 30 + 21, (points[0].Y - 1) * 30 - 6, (points[1].X - points[0].X + 3) * 30, (points[1].Y - points[0].Y + 3) * 30));

                    //PictureBox pictureBox = new PictureBox()
                    //{
                    //    Size = new Size((points[1].X - points[0].X + 3) * 30, (points[1].Y - points[0].Y + 3) * 30),
                    //    Location = new Point((points[0].X - 1) * 30 + 21, (points[0].Y - 1) * 30 - 6)
                    //};
                    //this.Controls.Add(pictureBox);
                    //await Task.Delay(500);
                    //this.Controls.Remove(pictureBox);

                    this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1);
                    BlockMover.MoveDown(this.currentBlock); 
                    await Task.Delay(500);
                }
                this.Invalidate();

                this.gameField.SetPreviousBlockStaticToGameField(this.currentBlock);
                
                this.currentBlock = this.nextBlock;
                this.nextBlock = this.GetRandomBlock();

                this.score.GetPointsForBlock(ref this.labelScore);
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: if (!GameField.IsAtBottom(this.currentBlock) && !this.gameField.IsAtBlockDown(this.currentBlock)) { BlockMover.Rotate(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); Point[] points = this.GetRectangleBlock(); this.Invalidate(new Rectangle((points[0].X - 1) * 30 + 21, (points[0].Y - 1) * 30 - 6, (points[1].X - points[0].X + 3) * 30, (points[1].Y - points[0].Y + 3) * 30)); } break;
                case Keys.Down: if (!this.gameField.IsAtBlockDown(this.currentBlock)) { BlockMover.MoveDown(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); Point[] points = this.GetRectangleBlock(); this.Invalidate(new Rectangle((points[0].X - 1) * 30 + 21, (points[0].Y - 1) * 30 - 6, (points[1].X - points[0].X + 3) * 30, (points[1].Y - points[0].Y + 3) * 30)); } break;
                case Keys.Left: if (!this.gameField.IsAtBlockLeft(this.currentBlock)) { BlockMover.MoveLeft(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); Point[] points = this.GetRectangleBlock(); this.Invalidate(new Rectangle((points[0].X - 1) * 30 + 21, (points[0].Y - 1) * 30 - 6, (points[1].X - points[0].X + 3) * 30, (points[1].Y - points[0].Y + 3) * 30)); } break;
                case Keys.Right: if (!this.gameField.IsAtBlockRight(this.currentBlock)) { BlockMover.MoveRight(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); Point[] points = this.GetRectangleBlock(); this.Invalidate(new Rectangle((points[0].X - 1) * 30 + 21, (points[0].Y - 1) * 30 - 6, (points[1].X - points[0].X + 3) * 30, (points[1].Y - points[0].Y + 3) * 30)); } break;
            }
        }





        // *********************************************************************************** //
        // ***        GGGGG   RRRR       AAAA       PPPP    HH  HH   III   CCCCC  SSSSS    *** //
        // ***       GG  GG  RR  RR     AA  AA     PP  PP   HH  HH    I   CC     SS        *** // 
        // ***      GG       RRRRR     AAAAAAAA    PPPPPP   HHHHHH    I   CC       SSS     *** //
        // ***       GG  GG  RR  RR   AA      AA   PP       HH  HH    I   CC         SS    *** //
        // ***        GGGGG  RR   RR AA        AA  PP       HH  HH   III   CCCCC  SSSS     *** //
        // *********************************************************************************** //

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            Image image = Properties.Resources.Block1;

            //this.DrawScore(graphics);
            this.DrawBlock(graphics, image);
            this.DrawField(graphics, image);

            //image = Properties.Resources.BlocksLine;
            //this.DrawGameOverAnimation(graphics, image);

            graphics.Dispose();
        }

        private void DrawBlock(Graphics graphics, Image image)
        {
            foreach (Point point in this.currentBlock.blockPoints)
            {
                if (point.Y > 1) // тут должно быть не 0, а 1
                {
                    graphics.DrawImage(image, (point.X * 30) + 21, (point.Y * 30) - 36); // а тут должно быть не 6, 36
                                                                                        // если сделать сделать как нужно, то игрок будет не успеввать засовывать блоки в труднодосупные места
                                                                                        // и придётся ставить задержку перед зафиксированием блока, а тогда начинаются проблемы с отрисовкой
                                                                                        // (фигура сквозь другую проходит, но потом становится всё нормально)
                }
            }
        }

        private void DrawField(Graphics graphics, Image image)
        {
            for (byte i = 1; i < this.gameField.gameField.GetLength(0); i++)
            {
                for (byte j = 0; j < this.gameField.gameField.GetLength(1); j++)
                {
                    if (this.gameField.gameField[i, j] == 1)
                    {
                        graphics.DrawImage(image, (j * 30) + 21, (i * 30) - 6);
                    }
                }
            }
        }

        private void DrawScore(Graphics graphics)
        {
            graphics.DrawString(this.score.GetScore().ToString(), this.scoreFont, Brushes.Black, 365, 25);
        }

        private Point[] GetRectangleBlock()
        {
            byte maxX = (byte) this.currentBlock.blockPoints[0].X;
            byte maxY = (byte)this.currentBlock.blockPoints[0].Y;

            byte minX = (byte) this.currentBlock.blockPoints[0].X;
            byte minY = (byte)this.currentBlock.blockPoints[0].Y;

            for (byte i = 0; i < 4; i++)
            {
                if (maxX < this.currentBlock.blockPoints[i].X)
                {
                    maxX = (byte) this.currentBlock.blockPoints[i].X;
                }

                if (maxY < this.currentBlock.blockPoints[i].Y)
                {
                    maxY = (byte)this.currentBlock.blockPoints[i].Y;
                }

                if (minX > this.currentBlock.blockPoints[i].X)
                {
                    minY = (byte)this.currentBlock.blockPoints[i].X;
                }

                if (minY > this.currentBlock.blockPoints[i].Y)
                {
                    minY = (byte)this.currentBlock.blockPoints[i].Y;
                }
            }

            //MessageBox.Show($"{minX} : {minY}\n{maxX} : {maxY}");
            return new Point[] { new Point(minX, minY), new Point(maxX, maxY) };
        }

        private byte GetRectangleField()
        {
            for (byte i = 0; i < this.gameField.gameField.GetLength(0); i++)
            {
                for (byte j = 0; j < this.gameField.gameField.GetLength(1); j++)
                {
                    if (this.gameField.gameField[i, j] == 1)
                    {
                        //MessageBox.Show($"FIELD {i}");
                        return i;
                    }
                }
            }
            return 21;
        }

        private void DrawGameOverAnimation(Graphics graphics, Image image)
        {
            for (byte i = (byte)this.gameField.gameField.GetLength(0); i > 1; i--)
            {
                graphics.DrawImage(image, 21, (i * 30) - 36);
                Thread.Sleep(50);
                this.Invalidate();
            }

            Thread.Sleep(500);
        }

    }
}
