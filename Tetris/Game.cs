using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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
                    this.Invalidate();
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
                case Keys.Up: if (!GameField.IsAtBottom(this.currentBlock) && !this.gameField.IsAtBlockDown(this.currentBlock)) { BlockMover.Rotate(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); this.Refresh(); } break;
                case Keys.Down: if (!this.gameField.IsAtBlockDown(this.currentBlock)) { BlockMover.MoveDown(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); this.Refresh(); } break;
                case Keys.Left: if (!this.gameField.IsAtBlockLeft(this.currentBlock)) { BlockMover.MoveLeft(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); this.Refresh(); } break;
                case Keys.Right: if (!this.gameField.IsAtBlockRight(this.currentBlock)) { BlockMover.MoveRight(this.currentBlock); this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1); this.Refresh(); } break;
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
                if (point.Y > 0) // первый ряд блоков не рисуется
                {
                    graphics.DrawImage(image, (point.X * 30) + 21, (point.Y * 30) - 6);
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

        private Point GetRectangleBlock()
        {
            for (byte i = 0; i < this.gameField.gameField.GetLength(0); i++)
            {
                for (byte j = 0; j < this.gameField.gameField.GetLength(1); j++)
                {
                    if (this.gameField.gameField[i, j] == 1)
                    {
                        //MessageBox.Show($"FIELD {i} : {j}");
                        return new Point(j, i);
                    }
                }
            }
            return new Point(10, 20);
        }

        private Point GetRectangleField()
        {
            for (byte i = 0; i < this.gameField.gameField.GetLength(0); i++)
            {
                for (byte j = 0; j < this.gameField.gameField.GetLength(1); j++)
                {
                    if (this.gameField.gameField[i, j] == 1)
                    {
                        //MessageBox.Show($"FIELD {i} : {j}");
                        return new Point(j, i);
                    }
                }
            }
            return new Point(10, 20);
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
