using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Tetris
{
    static class BlockMover
    {
        public static void MoveDown(Block block)
        {
            if (!GameField.IsAtBottom(block)) // ещё нужна проверка, чтобы впереди не было блока
            {
                for (int i = 0; i < 4; i++)
                {
                    block.blockPoints[i].Y++;
                }    
            }
        }

        public static void MoveLeft(Block block)
        {
            if (!GameField.IsAtWallLeft(block))
            {
                for (int i = 0; i < 4; i++)
                {
                    block.blockPoints[i].X--;
                }
            }
        }

        public static void MoveRight(Block block)
        {
            if (!GameField.IsAtWallRight(block))
            {
                for (int i = 0; i < 4; i++)
                {
                    block.blockPoints[i].X++;
                }
            }
        }

        public static void Rotate(Block block)
        {
            // ПРОБЛЕМА В ТОМ, ЧТО МОЖЕТ ЛИ БЛОК ВСТАВИТЬ - ПРОВЕРЯЕТСЯ ПРИ ПОМОЩИ ГРАНИЦ ЕГО МАТРИЦЫ (blockMatrix),
            // А ВЕДЬ НИКАКАЯ ФИГУРА НЕ ЗАПОЛНЯЕТ ЭТУ МАТРИЦУ ПОЛНОСТЬЮ, ПОЭТОМУ ПРОИСХОДЯТ ОШИБКИ:
            // 1. В дефолтном положении (3) - всё отлично, ведь под него всё и подстраивалось.
            // 2. В положениях 0 и 2 - крайний кусок будет выходить за пределы дна матрицы поля (fieldMatrix), поэтому будет кинуто исключение.
            // 3. В положения 0 и 2 - при прижатии к стенке, прижатие происходит не полностью.
            // 4. В положении 1 - всё нормально

            // ЕДИНСТВЕННЫЙ ВАРИАНТ ДЛЯ ФИКСА, ЭТО УЧИТЫВАТЬ НЕ РАЗМЕРЫ МАТРИЦЫ БЛОКА, А КОНКРЕТНОЕ ЗНАЧЕНИЕ В НЕЙ
            if (block is OBlock)
            {
                return;
            }

            else if (block is TBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    0  1  2
                 * 0    [3]
                 * 1 [0][2]
                 * 2    [1]
                 *    
                 * ПОЛОЖЕНИЕ 1:
                 *    0  1  2
                 * 0 
                 * 1 [3][2][1]
                 * 2    [0]
                 * 
                 * ПОЛОЖЕНИЕ 2:
                 *    0  1  2
                 * 0    [1]
                 * 1    [2][0]
                 * 2    [3]
                 * 
                 * ПОЛОЖЕНИЕ 3:
                 *    0  1  2
                 * 0    [0]
                 * 1 [1][2][3]
                 * 2
                 * 
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.blockPoints[2] = block.blockPoints[2];
                        block.blockPoints[3] = block.blockPoints[0];
                        block.blockPoints[0] = block.blockPoints[1];
                        block.blockPoints[1] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y + 1);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        if (!GameField.IsAtWallRight(block))
                        {
                            block.blockPoints[2] = block.blockPoints[2];
                            block.blockPoints[3] = block.blockPoints[0];
                            block.blockPoints[0] = block.blockPoints[1];
                            block.blockPoints[1] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);

                            block.currentOrientation = 2;
                        }
                        break;

                    case 2:
                        block.blockPoints[2] = block.blockPoints[2];
                        block.blockPoints[3] = block.blockPoints[0];
                        block.blockPoints[0] = block.blockPoints[1];
                        block.blockPoints[1] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y - 1);

                        block.currentOrientation = 3;
                        break;

                    case 3:
                        if (!GameField.IsAtWallLeft(block))
                        {
                            block.blockPoints[2] = block.blockPoints[2];
                            block.blockPoints[3] = block.blockPoints[0];
                            block.blockPoints[0] = block.blockPoints[1];
                            block.blockPoints[1] = new Point(block.blockPoints[2].X - 1, block.blockPoints[2].Y);

                            block.currentOrientation = 0;
                        }
                        break;
                }
            }

            else if (block is SBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    0  1  2
                 * 0 [3]
                 * 1 [2][1]
                 * 2    [0]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    0  1  2
                 * 0    [2][3]
                 * 1 [0][1]
                 * 2
                 * 
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.blockPoints[1] = block.blockPoints[1];
                        block.blockPoints[2] = block.blockPoints[0];
                        block.blockPoints[3] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y - 1);
                        block.blockPoints[0] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y + 1);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        if (!GameField.IsAtWallRight(block))
                        {
                            block.blockPoints[1] = block.blockPoints[1];
                            block.blockPoints[0] = block.blockPoints[2];
                            block.blockPoints[2] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y - 1);
                            block.blockPoints[3] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);

                            block.currentOrientation = 0;
                        }
                        break;
                }
            }

            else if (block is ZBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    0  1  2
                 * 0    [3]
                 * 1 [1][2]
                 * 2 [0]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    0  1  2
                 * 0 [0][1]
                 * 1    [2][3]
                 * 2
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.blockPoints[2] = block.blockPoints[2];
                        block.blockPoints[3] = block.blockPoints[1];
                        block.blockPoints[1] = new Point(block.blockPoints[2].X - 1, block.blockPoints[2].Y);
                        block.blockPoints[0] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y + 1);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        if (!GameField.IsAtWallRight(block))
                        {
                            block.blockPoints[2] = block.blockPoints[2];
                            block.blockPoints[1] = block.blockPoints[3];
                            block.blockPoints[0] = new Point(block.blockPoints[1].X - 1, block.blockPoints[1].Y);
                            block.blockPoints[3] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);

                            block.currentOrientation = 0;
                        }
                        break;
                }
            }

            else if (block is JBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    0  1  2
                 * 0    [3]
                 * 1    [2]
                 * 2 [0][1]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    0  1  2
                 * 0 [3][2][1]
                 * 1       [0]
                 * 2
                 * 
                 * ПОЛОЖЕНИЕ 2:
                 *    0  1  2
                 * 0 [1][0]
                 * 1 [2]
                 * 2 [3]
                 * 
                 * ПОЛОЖЕНИЕ 3:
                 *    0  1  2
                 * 0 [0]
                 * 1 [1][2][3]
                 * 2
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.blockPoints[2] = block.blockPoints[2];
                        block.blockPoints[3] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y - 1);
                        block.blockPoints[1] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y + 1);
                        block.blockPoints[0] = new Point(block.blockPoints[1].X - 1, block.blockPoints[1].Y);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        if (!GameField.IsAtWallRight(block))
                        {
                            block.blockPoints[2] = block.blockPoints[3];
                            block.blockPoints[3] = new Point(block.blockPoints[2].X - 1, block.blockPoints[2].Y);
                            block.blockPoints[1] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);
                            block.blockPoints[0] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y + 1);

                            block.currentOrientation = 2;
                        }
                        break;

                    case 2:
                        block.blockPoints[0] = block.blockPoints[2];
                        block.blockPoints[1] = block.blockPoints[3];
                        block.blockPoints[2] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y + 1);
                        block.blockPoints[3] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y + 1);

                        block.currentOrientation = 3;
                        break;

                    case 3:
                        if (!GameField.IsAtWallRight(block))
                        {
                            block.blockPoints[0] = block.blockPoints[1];
                            block.blockPoints[1] = block.blockPoints[2];
                            block.blockPoints[2] = new Point(block.blockPoints[1].X + 1, block.blockPoints[1].Y);
                            block.blockPoints[3] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);

                            block.currentOrientation = 0;
                        }
                        break;
                }
            }

            else if (block is LBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    0  1  2
                 * 0 [3][2]
                 * 1    [1]
                 * 2    [0]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    0  1  2
                 * 0 [2][1][0]
                 * 1 [3]
                 * 2
                 *  
                 * ПОЛОЖЕНИЕ 2:  
                 *    0  1  2
                 * 0 [0]
                 * 1 [1]
                 * 2 [2][3]
                 * 
                 * ПОЛОЖЕНИЕ 3:
                 *    0  1  2
                 * 0       [3]
                 * 1 [0][1][2]
                 * 2
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.blockPoints[1] = block.blockPoints[1];
                        block.blockPoints[2] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y - 1);
                        block.blockPoints[3] = new Point(block.blockPoints[2].X - 1, block.blockPoints[2].Y);
                        block.blockPoints[0] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y + 1);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        if (!GameField.IsAtWallRight(block))
                        {
                            block.blockPoints[1] = block.blockPoints[2];
                            block.blockPoints[2] = block.blockPoints[3];
                            block.blockPoints[3] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y + 1);
                            block.blockPoints[0] = new Point(block.blockPoints[1].X + 1, block.blockPoints[1].Y);

                            block.currentOrientation = 2;
                        }
                        break;

                    case 2:
                        block.blockPoints[0] = block.blockPoints[2];
                        block.blockPoints[1] = block.blockPoints[3];
                        block.blockPoints[2] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y + 1);
                        block.blockPoints[3] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);

                        block.currentOrientation = 3;
                        break;

                    case 3:
                        if (!GameField.IsAtWallRight(block))
                        {
                            block.blockPoints[0] = block.blockPoints[1];
                            block.blockPoints[1] = new Point(block.blockPoints[0].X + 1, block.blockPoints[0].Y);
                            block.blockPoints[2] = new Point(block.blockPoints[1].X + 1, block.blockPoints[1].Y);
                            block.blockPoints[3] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y - 1);

                            block.currentOrientation = 0;
                        }
                        break;
                }
            }

            else if (block is IBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    0  1  2  3
                 * 0    [0]
                 * 1    [1]
                 * 2    [2]
                 * 3    [3]
                 *    
                 * ПОЛОЖЕНИЕ 1:
                 *    0  1  2  3
                 * 0
                 * 1 [0][1][2][3]
                 * 2
                 * 3
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        if (block.blockPoints[3].Y < 18)
                        {
                            block.blockPoints[1] = block.blockPoints[1];
                            block.blockPoints[0] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y - 1);
                            block.blockPoints[2] = new Point(block.blockPoints[1].X, block.blockPoints[1].Y + 1);
                            block.blockPoints[3] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y + 1);

                            block.currentOrientation = 1;
                        }
                        break;

                    case 1:
                        if (block.blockPoints[1].X < 8 && !GameField.IsAtWallLeft(block)) // тут метод isWallLeft использовать не получится, так как линия при повороте смещается на две единицы по X, а не на одну
                        {
                            block.blockPoints[1] = block.blockPoints[1];
                            block.blockPoints[0] = new Point(block.blockPoints[1].X - 1, block.blockPoints[1].Y);
                            block.blockPoints[2] = new Point(block.blockPoints[1].X + 1, block.blockPoints[1].Y);
                            block.blockPoints[3] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);

                            block.currentOrientation = 0;
                        }
                        break;
                }
            }
        }
    }
}
