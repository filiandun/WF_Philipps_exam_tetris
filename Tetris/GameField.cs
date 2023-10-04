using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public class GameField
    {
        private const byte ROW = 21; // координата Y
        private const byte COLUMN = 10; // координата X

        public byte[,] gameField; // 0 - пусто
                                  // 1 - занято
                                  // 2 - текущий блок

        private Block previousBlock;

        public GameField()
        {
            this.gameField = new byte[ROW, COLUMN]; // заполнение поля
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COLUMN; j++)
                {
                    this.gameField[i, j] = 0;
                }
            }
        }

        public void AddCurrentBlockToGameField(Block block, ref Label label)
        {
            this.previousBlock = block;
            foreach (Point partPoint in block.blockPoints)
            {
                this.gameField[partPoint.Y, partPoint.X] = 2;
            }

            label.Text = ShowMessageBox();
            DeletePreviousBlockFromGameField();
        }

        public bool IsAtBlock(Block block)
        {
            foreach (Point partPoint in block.blockPoints)
            {
                if (this.gameField[partPoint.Y, partPoint.X] == 1)
                {
                    block = this.previousBlock;
                    return true;
                }
            }
            return false;
        }

        public static bool IsAtBottom(Block block)
        {
            foreach(Point partPoint in block.blockPoints)
            {
                if (partPoint.Y > 19)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAtLeftWall(Block block)
        {
            foreach (Point partPoint in block.blockPoints)
            {
                if (partPoint.X <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAtRightWall(Block block)
        {
            foreach (Point partPoint in block.blockPoints)
            {
                if (partPoint.X >= 9)
                {
                    return true;
                }
            }
            return false;
        }

        public string ShowMessageBox()
        {
            string text = "";

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COLUMN; j++)
                {
                    text += this.gameField[i, j];
                }
                text += "\n";
            }

            //MessageBox.Show(text);
            return text;
        }

        public void DeletePreviousBlockFromGameField()
        {
            if (this.previousBlock != null)
            {
                //foreach (Point partPoint in this.previousBlock.blockPoints)
                //{
                //    this.gameField[partPoint.Y, partPoint.X] = 0;
                //}

                for (int i = 0; i < this.gameField.GetLength(0); i++)
                {
                    for (int j = 0; j < this.gameField.GetLength(1); j++)
                    {
                        this.gameField[i, j] = 0;
                    }
                }

            }
        }

        public void SetPreviousBlockStaticToGameField(Block block)
        {
            foreach (Point partPoint in block.blockPoints)
            {
                this.gameField[partPoint.Y, partPoint.X] = 1;
            }
        }

    }
}
