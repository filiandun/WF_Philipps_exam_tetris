using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{

    public partial class Game : Form
    {
        Random random = new Random(DateTime.Now.Millisecond);

        const byte WIDTH = 20;
        const byte HEIGHT = 20;

        public bool[,] gameField;

        public Block currentBlock;
        public Block nextBlock;

        public Game()
        {
            InitializeComponent();

            this.gameField = new bool[WIDTH, HEIGHT]; // заполнение поля
            for (int i = 0; i < WIDTH; i++) 
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    this.gameField[i, j] = true;
                }
            }

            this.Paint += new PaintEventHandler(DrawColoredSquare);

            //this.currentBlock = new OBlock(); // READY
            //this.currentBlock = new TBlock(); // READY
            //this.currentBlock = new SBlock(); // READY
            //this.currentBlock = new ZBlock(); // READY
            //this.currentBlock = new JBlock(); // READY
            //this.currentBlock = new LBlock(); // READY
            //this.currentBlock = new IBlock(); // READY

            //this.Random_Block();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Game_Start();
        }

        private void DrawColoredSquare(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.Black, 40, 40, 32, 32);
            g.FillRectangle(Brushes.DarkKhaki, 43, 43, 26, 26);
            g.FillRectangle(Brushes.Black, 46, 46, 20, 20);
        }

            private void Random_Block()
        {
            switch (this.random.Next(0, 6))
            {
                case 0: this.currentBlock = new TBlock(); break;
                case 1: this.currentBlock = new OBlock(); break;
                case 2: this.currentBlock = new SBlock(); break;
                case 3: this.currentBlock = new ZBlock(); break;
                case 4: this.currentBlock = new JBlock(); break;
                case 5: this.currentBlock = new LBlock(); break;
                case 6: this.currentBlock = new IBlock(); break;
            }

            switch (this.random.Next(0, 6))
            {
                case 0: this.nextBlock = new TBlock(); break;
                case 1: this.nextBlock = new OBlock(); break;
                case 2: this.nextBlock = new SBlock(); break;
                case 3: this.nextBlock = new ZBlock(); break;
                case 4: this.nextBlock = new JBlock(); break;
                case 5: this.nextBlock = new LBlock(); break;
                case 6: this.nextBlock = new IBlock(); break;
            }
        }

        private async void Game_Start()
        {
            for (int j = 0; j < 8; j++)
            {
                this.Game_UpdateBlock();
                await Task.Delay(500);

                BlockMover.MoveDown(this.currentBlock);
                AddToMatrix();
            }
        }

        private bool AddToMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.gameField[this.currentBlock.currentPositions[i].X / 30, this.currentBlock.currentPositions[i].Y / 30] = false;
                    //MessageBox.Show($"{this.currentBlock.currentPositions[i].X / 30} | {this.currentBlock.currentPositions[i].Y / 30}");
                }
            }

            return true;
        }

        private async void Game_UpdateBlock()
        {
            this.Controls.Clear();

            for (int i = 0; i < 4; i++)
            {
                PictureBox pictureBoxBlock = new PictureBox()
                {
                    Image = Properties.Resources.Block,
                    Size = new Size(30, 30),
                    Location = this.currentBlock.currentPositions[i],
                    BackColor = Color.FromArgb(0, 0, 0, 0) // чтобы фон был прозрачным у pictureBox
                };

                //MessageBox.Show($"{this.currentBlock.currentPositions[i]}");

                this.Controls.Add(pictureBoxBlock);
                this.Refresh();
            }
        }

        private async void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: BlockMover.Rotate(this.currentBlock); this.Game_UpdateBlock(); break;
                case Keys.Down: BlockMover.MoveDown(this.currentBlock); this.Game_UpdateBlock(); break;
                case Keys.Left: BlockMover.MoveLeft(this.currentBlock); this.Game_UpdateBlock(); break;
                case Keys.Right: BlockMover.MoveRight(this.currentBlock); this.Game_UpdateBlock(); break;
            }
   
            //await Task.Delay(1000);

        }
    }
}
