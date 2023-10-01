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

        public GameField gameField;

        public Block currentBlock;
        public Block nextBlock;

        public Game()
        {
            InitializeComponent();

            //this.currentBlock = new OBlock(); // READY
            this.currentBlock = new TBlock();
            //this.currentBlock = new SBlock(); // READY
            //this.currentBlock = new ZBlock(); // READY
            //this.currentBlock = new JBlock(); // READY
            //this.currentBlock = new LBlock(); // READY
            //this.currentBlock = new IBlock(); // READY

            //this.Random_Block();
            this.gameField = new GameField();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Game_Start();
        }

        //private void Random_Block()
        //{
        //    switch (this.random.Next(0, 6))
        //    {
        //        case 0: this.currentBlock = new TBlock(); break;
        //        case 1: this.currentBlock = new OBlock(); break;
        //        case 2: this.currentBlock = new SBlock(); break;
        //        case 3: this.currentBlock = new ZBlock(); break;
        //        case 4: this.currentBlock = new JBlock(); break;
        //        case 5: this.currentBlock = new LBlock(); break;
        //        case 6: this.currentBlock = new IBlock(); break;
        //    }

        //    switch (this.random.Next(0, 6))
        //    {
        //        case 0: this.nextBlock = new TBlock(); break;
        //        case 1: this.nextBlock = new OBlock(); break;
        //        case 2: this.nextBlock = new SBlock(); break;
        //        case 3: this.nextBlock = new ZBlock(); break;
        //        case 4: this.nextBlock = new JBlock(); break;
        //        case 5: this.nextBlock = new LBlock(); break;
        //        case 6: this.nextBlock = new IBlock(); break;
        //    }
        //}

        private async void Game_Start()
        {
            for (int i = 0; i < 12; i++)
            {
                while (!this.gameField.IsAtBottom(this.currentBlock) && !this.gameField.IsAtBlock(this.currentBlock))
                {
                    this.gameField.AddCurrentBlockToGameField(this.currentBlock, ref this.label1);

                    await Task.Delay(1000);

                    BlockMover.MoveDown(this.currentBlock);
                }
                this.gameField.SetPreviousBlockStaticToGameField(this.currentBlock);
                this.currentBlock = new TBlock();
            }
        }

        private void Game_UpdateField()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--) // удаление всех PictureBox
            {
                if (this.Controls[i] is PictureBox pictureBox)
                {
                    this.Controls.RemoveAt(i);
                }
            }

            for (byte i = 1; i < gameField.gameField.GetLength(0); i++)
            {
                for (byte j = 0; j < gameField.gameField.GetLength(1); j++)
                {
                    if (gameField.gameField[i, j] == 1)
                    {
                        PictureBox pictureBoxBlock = new PictureBox()
                        {
                            Image = Properties.Resources.Block,
                            Size = new Size(30, 30),
                            Location = new Point(j * 30 + 21, i * 30 - (i == 0 ? 0 : 6)), // тут такая фигня нужна, чтобы первый кубик блока не отрисовывался, так как он типа вне поля
                            BackColor = Color.FromArgb(0, 0, 0, 0) // чтобы фон был прозрачным у pictureBox
                        };

                        this.Controls.Add(pictureBoxBlock);
                        this.Refresh();
                    }
                }
            }
        }
        private void Game_UpdateBlock()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--) // удаление всех PictureBox
            {
                if (this.Controls[i] is PictureBox pictureBox)
                {
                    this.Controls.RemoveAt(i);
                }
            }

            for (byte i = 1; i < gameField.gameField.GetLength(0); i++)
            {
                for (byte j = 0; j < gameField.gameField.GetLength(1); j++)
                {
                    if (gameField.gameField[i, j] == 2)
                    {
                        PictureBox pictureBoxBlock = new PictureBox()
                        {
                            Image = Properties.Resources.Block,
                            Size = new Size(30, 30),
                            Location = new Point(j * 30 + 21, i * 30 - (i == 0 ? 0 : 6)), // тут такая фигня нужна, чтобы первый кубик блока не отрисовывался, так как он типа вне поля
                            BackColor = Color.FromArgb(0, 0, 0, 0) // чтобы фон был прозрачным у pictureBox
                        };

                        this.Controls.Add(pictureBoxBlock);
                        this.Refresh();
                    }
                }
            }
        }


        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: BlockMover.Rotate(this.currentBlock); /*this.Game_UpdateBlock();*/ break;
                case Keys.Down: BlockMover.MoveDown(this.currentBlock); /*this.Game_UpdateBlock();*/ break;
                case Keys.Left: BlockMover.MoveLeft(this.currentBlock); /*this.Game_UpdateBlock();*/ break;
                case Keys.Right: BlockMover.MoveRight(this.currentBlock); /*this.Game_UpdateBlock();*/ break;
            }
        }
    }
}
