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
            for (int i = 0; i < block.blockMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < block.blockMatrix.GetLength(0); j++)
                {
                    if (block.blockMatrix[i, j] == 2)
                    {
                        this.gameField[block.currentY + i, block.currentX + j] = 2;
                    }
                }
            }
            label.Text = ShowMessageBox();
            DeletePreviousBlockFromGameField();
        }

        public bool IsAtBlock(Block block)
        {
            for (int i = 0; i < block.blockMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < block.blockMatrix.GetLength(0); j++)
                {
                    if (block.blockMatrix[i, j] == 2)
                    {
                        if (this.gameField[block.currentY + i, block.currentX + j] == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsAtBottom(Block block)
        {
            if (block.currentY > 19)
            {
                return true;
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
                byte previousX = this.previousBlock.currentX;
                byte previousY = this.previousBlock.currentY;

                for (int i = previousY; i < previousY + this.previousBlock.blockMatrix.GetLength(0); i++)
                {
                    for (int j = previousX; j < previousX + this.previousBlock.blockMatrix.GetLength(0); j++)
                    {
                        if (this.previousBlock.blockMatrix[i - previousY, j - previousX] == 2)
                        {
                            this.gameField[i, j] = 0;
                        }
                    }
                }
            }
        }

        public void SetPreviousBlockStaticToGameField(Block block)
        {
            byte currentX = block.currentX;
            byte currentY = block.currentY;

            for (int i = currentY; i < currentY + block.blockMatrix.GetLength(0); i++)
            {
                for (int j = currentX; j < currentX + block.blockMatrix.GetLength(0); j++)
                {
                    if (block.blockMatrix[i - currentY, j - currentX] == 2)
                    {
                        this.gameField[i - 1, j] = 1;
                    }
                }
            }
        }

    }
}
