using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
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
            //this.DeleteLine();

            foreach (Point partPoint in block.blockPoints)
            {
                this.gameField[partPoint.Y, partPoint.X] = 2;
            }

            this.previousBlock = block;
            label.Text = ShowMessageBox();

            this.DeletePreviousBlockFromGameField();
        }

        public bool IsAtBlockDown(Block block)
        {
            foreach (Point partPoint in block.blockPoints)
            {
                if (partPoint.Y < 20) // нужно сделать иную проверку, так как, если фигура, например, линия - то она не проходит это условие и проходит сквозь фигуру
                {
                    if (this.gameField[partPoint.Y + 1, partPoint.X] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsAtBlockLeft(Block block)
        {
            foreach (Point partPoint in block.blockPoints)
            {
                if (partPoint.X > 0)
                {
                    if (this.gameField[partPoint.Y, partPoint.X - 1] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsAtBlockRight(Block block)
        {
            foreach (Point partPoint in block.blockPoints)
            {
                if (partPoint.X < 9)
                {
                    if (this.gameField[partPoint.Y, partPoint.X + 1] == 1)
                    {
                        return true;
                    }
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

        public static bool IsAtWallLeft(Block block)
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

        public static bool IsAtWallRight(Block block)
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

        public void CheckCompletedLine()
        {
            byte num = 0;

            foreach (Point point in this.previousBlock.blockPoints)
            {
                for (byte j = 0; j < this.gameField.GetLength(1); j++)
                {
                    if (this.gameField[point.Y, j] == 1)
                    {
                        num++;
                    }
                }

                if (num == 10)
                {
                    this.DeleteCompletedLine((byte) point.Y);
                }
                num = 0;
            }
        }

        private void DeleteCompletedLine(byte currentRow)
        {
            for (byte i = currentRow; i > 2; i--)
            {
                for (byte j = 0; j < this.gameField.GetLength(1); j++)
                {
                    this.gameField[i, j] = this.gameField[i - 1, j];
                }
            }
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
                foreach (Point partPoint in this.previousBlock.blockPoints)
                {
                    this.gameField[partPoint.Y, partPoint.X] = 0;
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


        public bool CanSpawnBlock()
        {
            for (byte j = 0; j < this.gameField.GetLength(1); j++)
            {
                if (this.gameField[1, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
