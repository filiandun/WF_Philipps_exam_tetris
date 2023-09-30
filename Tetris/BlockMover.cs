using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Tetris
{
    static class BlockMover
    {
        public static void MoveDown(Block block)
        {   
            Block BlockCopy = block;
            for (int i = 0; i < 4; i++)
            {
                block.currentPositions[i].Y += 30;
            }
        }

        public static void MoveLeft(Block block)
        {
            for (int i = 0; i < 4; i++)
            {
                block.currentPositions[i].X -= 30;
            }
        }

        public static void MoveRight(Block block)
        {
            for (int i = 0; i < 4; i++)
            {
                block.currentPositions[i].X += 30;
            }
        }

        public static void Rotate(Block block)
        {
            if (block.currentOrientation == 5) // костыль (в смысле, не цифра 5 должна быть, нужно придумать, как иначе сделать)
                                               // если поставить 0, то тогда при первом нажати фигура не будет поворачиваться
            {
                block.currentOrientation = 1;
            }

            if (block is OBlock) // какой смысл вращать квадрат?
            {
                return;
            }

            else if (block is TBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    [0]
                 * [1][2][3]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    [3]
                 * [0][2]
                 *    [1]
                 *    
                 * ПОЛОЖЕНИЕ 2:
                 * [3][2][1]
                 *    [0]
                 *     
                 * ПОЛОЖЕНИЕ 3:
                 *    [1]
                 *    [2][0]
                 *    [3]
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.currentPositions[3] = block.currentPositions[0];
                        block.currentPositions[0] = block.currentPositions[1];
                        block.currentPositions[1] = new Point(block.currentPositions[2].X - 30, block.currentPositions[2].Y);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        block.currentPositions[3] = block.currentPositions[0];
                        block.currentPositions[0] = block.currentPositions[1];
                        block.currentPositions[1] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y + 30);

                        block.currentOrientation = 2; 
                        break;

                    case 2:
                        block.currentPositions[3] = block.currentPositions[0];
                        block.currentPositions[0] = block.currentPositions[1];
                        block.currentPositions[1] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);

                        block.currentOrientation = 3;
                        break;

                    case 3:
                        block.currentPositions[3] = block.currentPositions[0];
                        block.currentPositions[0] = block.currentPositions[1];
                        block.currentPositions[1] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y - 30);

                        block.currentOrientation = 0;
                        break;
                }
            }
            
            else if (block is SBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *    [2][3]
                 * [0][1]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    [3]
                 *    [2][1]
                 *       [0]
                */
                
                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.currentPositions[1] = block.currentPositions[2];
                        block.currentPositions[2] = block.currentPositions[3];
                        block.currentPositions[0] = new Point(block.currentPositions[1].X - 30, block.currentPositions[1].Y);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        block.currentPositions[3] = block.currentPositions[2];
                        block.currentPositions[2] = block.currentPositions[1];
                        block.currentPositions[1] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);
                        block.currentPositions[0] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y + 30);

                        block.currentOrientation = 0;
                        break;
                }

            }

            else if (block is ZBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 * [0][1]
                 *    [2][3]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    [3]
                 * [1][2]
                 * [0]
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.currentPositions[1] = block.currentPositions[3];
                        block.currentPositions[2] = block.currentPositions[2];
                        block.currentPositions[0] = new Point(block.currentPositions[1].X - 30, block.currentPositions[1].Y);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        block.currentPositions[3] = block.currentPositions[1];
                        block.currentPositions[2] = block.currentPositions[2];
                        block.currentPositions[1] = new Point(block.currentPositions[2].X - 30, block.currentPositions[2].Y);
                        block.currentPositions[0] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y + 30);

                        block.currentOrientation = 0;
                        break;
                }

            }

            else if (block is JBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 * [0]
                 * [1][2][3]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    [3]
                 *    [2]
                 * [0][1]
                 * 
                 * ПОЛОЖЕНИЕ 2:   
                 * [3][2][1]
                 *       [0]
                 * 
                 * ПОЛОЖЕНИЕ 3:
                 * [1][0]
                 * [2]
                 * [3]
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.currentPositions[0] = block.currentPositions[1];
                        block.currentPositions[1] = block.currentPositions[2];
                        block.currentPositions[2] = new Point(block.currentPositions[1].X + 30, block.currentPositions[1].Y);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        block.currentPositions[2] = block.currentPositions[2];
                        block.currentPositions[3] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y - 30);
                        block.currentPositions[1] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y + 30);
                        block.currentPositions[0] = new Point(block.currentPositions[1].X - 30, block.currentPositions[1].Y);

                        block.currentOrientation = 2;
                        break;

                    case 2:
                        block.currentPositions[2] = block.currentPositions[3];
                        block.currentPositions[3] = new Point(block.currentPositions[2].X - 30, block.currentPositions[2].Y);
                        block.currentPositions[1] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);
                        block.currentPositions[0] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y + 30);

                        block.currentOrientation = 3;
                        break;

                    case 3:
                        block.currentPositions[0] = block.currentPositions[2];
                        block.currentPositions[1] = block.currentPositions[3];
                        block.currentPositions[2] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y + 30);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y + 30);

                        block.currentOrientation = 0;
                        break;
                }

            }

            else if (block is LBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 *        [3]
                 *  [0][1][2]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 * [3][2]
                 *    [1]
                 *    [0]
                 * 
                 * ПОЛОЖЕНИЕ 2:   
                 * [2][1][0]
                 * [3]
                 * 
                 * ПОЛОЖЕНИЕ 3:
                 * [0]
                 * [1]
                 * [2][3]
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.currentPositions[0] = block.currentPositions[1];
                        block.currentPositions[1] = new Point(block.currentPositions[0].X + 30, block.currentPositions[0].Y);
                        block.currentPositions[2] = new Point(block.currentPositions[1].X + 30, block.currentPositions[1].Y);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y - 30);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        block.currentPositions[1] = block.currentPositions[1];
                        block.currentPositions[2] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y - 30);
                        block.currentPositions[0] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y + 30);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X - 30, block.currentPositions[2].Y);

                        block.currentOrientation = 2;
                        break;

                    case 2:
                        block.currentPositions[1] = block.currentPositions[2];
                        block.currentPositions[2] = block.currentPositions[3];
                        block.currentPositions[0] = new Point(block.currentPositions[1].X + 30, block.currentPositions[1].Y);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y + 30);

                        block.currentOrientation = 3;
                        break;

                    case 3:
                        block.currentPositions[0] = block.currentPositions[2];
                        block.currentPositions[1] = block.currentPositions[3];
                        block.currentPositions[2] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y + 30);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);

                        block.currentOrientation = 0;
                        break;
                }

            }

            else if (block is IBlock)
            {
                /* ПОЛОЖЕНИЕ 0:
                 * 
                 * [0][1][2][3]
                 * 
                 * ПОЛОЖЕНИЕ 1:
                 *    [0]
                 *    [1]
                 *    [2]
                 *    [3]
                */

                switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
                {
                    case 0:
                        block.currentPositions[1] = block.currentPositions[1];
                        block.currentPositions[0] = new Point(block.currentPositions[1].X - 30, block.currentPositions[1].Y);
                        block.currentPositions[2] = new Point(block.currentPositions[1].X + 30, block.currentPositions[1].Y);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X + 30, block.currentPositions[2].Y);

                        block.currentOrientation = 1;
                        break;

                    case 1:
                        block.currentPositions[1] = block.currentPositions[1];
                        block.currentPositions[0] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y - 30);
                        block.currentPositions[2] = new Point(block.currentPositions[1].X, block.currentPositions[1].Y + 30);
                        block.currentPositions[3] = new Point(block.currentPositions[2].X, block.currentPositions[2].Y + 30);

                        block.currentOrientation = 0;
                        break;
                }

            }
        }
    }
}
