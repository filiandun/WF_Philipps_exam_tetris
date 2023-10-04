﻿using System;
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
            if (!GameField.IsAtLeftWall(block))
            {
                for (int i = 0; i < 4; i++)
                {
                    block.blockPoints[i].X--;
                }
            }
        }

        public static void MoveRight(Block block)
        {
            if (!GameField.IsAtRightWall(block))
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

            if (block is TBlock)
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


                /* ТЕРЯЕТСЯ blockPoints[1] после одного круга прокручивания фигуры
                 * 
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
                        if (!GameField.IsAtRightWall(block))
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
                        block.blockPoints[1] = new Point(block.blockPoints[2].X + 1, block.blockPoints[2].Y);

                        block.currentOrientation = 3;
                        break;

                    case 3:
                        if (!GameField.IsAtLeftWall(block))
                        {
                            block.blockPoints[2] = block.blockPoints[2];
                            block.blockPoints[3] = block.blockPoints[0];
                            block.blockPoints[0] = block.blockPoints[1];
                            block.blockPoints[1] = new Point(block.blockPoints[2].X, block.blockPoints[2].Y - 1);

                            block.currentOrientation = 0;
                        }
                        break;
                }
            }

            //else if (block is SBlock)
            //{
            //    /* ПОЛОЖЕНИЕ 0:
            //     *    [2][3]
            //     * [0][1]
            //     * 
            //     * ПОЛОЖЕНИЕ 1:
            //     *    [3]
            //     *    [2][1]
            //     *       [0]
            //    */

            //    switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
            //    {
            //        case 0:
            //            block.matrixsBlock[1] = block.matrixsBlock[2];
            //            block.matrixsBlock[2] = block.matrixsBlock[3];
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X - 30, block.matrixsBlock[1].Y);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);

            //            block.currentOrientation = 1;
            //            break;

            //        case 1:
            //            block.matrixsBlock[3] = block.matrixsBlock[2];
            //            block.matrixsBlock[2] = block.matrixsBlock[1];
            //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y + 30);

            //            block.currentOrientation = 0;
            //            break;
            //    }

            //}

            //else if (block is ZBlock)
            //{
            //    /* ПОЛОЖЕНИЕ 0:
            //     * [0][1]
            //     *    [2][3]
            //     * 
            //     * ПОЛОЖЕНИЕ 1:
            //     *    [3]
            //     * [1][2]
            //     * [0]
            //    */

            //    switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
            //    {
            //        case 0:
            //            block.matrixsBlock[1] = block.matrixsBlock[3];
            //            block.matrixsBlock[2] = block.matrixsBlock[2];
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X - 30, block.matrixsBlock[1].Y);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);

            //            block.currentOrientation = 1;
            //            break;

            //        case 1:
            //            block.matrixsBlock[3] = block.matrixsBlock[1];
            //            block.matrixsBlock[2] = block.matrixsBlock[2];
            //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X - 30, block.matrixsBlock[2].Y);
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y + 30);

            //            block.currentOrientation = 0;
            //            break;
            //    }

            //}

            //else if (block is JBlock)
            //{
            //    /* ПОЛОЖЕНИЕ 0:
            //     * [0]
            //     * [1][2][3]
            //     * 
            //     * ПОЛОЖЕНИЕ 1:
            //     *    [3]
            //     *    [2]
            //     * [0][1]
            //     * 
            //     * ПОЛОЖЕНИЕ 2:   
            //     * [3][2][1]
            //     *       [0]
            //     * 
            //     * ПОЛОЖЕНИЕ 3:
            //     * [1][0]
            //     * [2]
            //     * [3]
            //    */

            //    switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
            //    {
            //        case 0:
            //            block.matrixsBlock[0] = block.matrixsBlock[1];
            //            block.matrixsBlock[1] = block.matrixsBlock[2];
            //            block.matrixsBlock[2] = new Point(block.matrixsBlock[1].X + 30, block.matrixsBlock[1].Y);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);

            //            block.currentOrientation = 1;
            //            break;

            //        case 1:
            //            block.matrixsBlock[2] = block.matrixsBlock[2];
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y - 30);
            //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y + 30);
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X - 30, block.matrixsBlock[1].Y);

            //            block.currentOrientation = 2;
            //            break;

            //        case 2:
            //            block.matrixsBlock[2] = block.matrixsBlock[3];
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X - 30, block.matrixsBlock[2].Y);
            //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y + 30);

            //            block.currentOrientation = 3;
            //            break;

            //        case 3:
            //            block.matrixsBlock[0] = block.matrixsBlock[2];
            //            block.matrixsBlock[1] = block.matrixsBlock[3];
            //            block.matrixsBlock[2] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y + 30);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y + 30);

            //            block.currentOrientation = 0;
            //            break;
            //    }

            //}

            //else if (block is LBlock)
            //{
            //    /* ПОЛОЖЕНИЕ 0:
            //     *        [3]
            //     *  [0][1][2]
            //     * 
            //     * ПОЛОЖЕНИЕ 1:
            //     * [3][2]
            //     *    [1]
            //     *    [0]
            //     * 
            //     * ПОЛОЖЕНИЕ 2:   
            //     * [2][1][0]
            //     * [3]
            //     * 
            //     * ПОЛОЖЕНИЕ 3:
            //     * [0]
            //     * [1]
            //     * [2][3]
            //    */

            //    switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
            //    {
            //        case 0:
            //            block.matrixsBlock[0] = block.matrixsBlock[1];
            //            block.matrixsBlock[1] = new Point(block.matrixsBlock[0].X + 30, block.matrixsBlock[0].Y);
            //            block.matrixsBlock[2] = new Point(block.matrixsBlock[1].X + 30, block.matrixsBlock[1].Y);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y - 30);

            //            block.currentOrientation = 1;
            //            break;

            //        case 1:
            //            block.matrixsBlock[1] = block.matrixsBlock[1];
            //            block.matrixsBlock[2] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y - 30);
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y + 30);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X - 30, block.matrixsBlock[2].Y);

            //            block.currentOrientation = 2;
            //            break;

            //        case 2:
            //            block.matrixsBlock[1] = block.matrixsBlock[2];
            //            block.matrixsBlock[2] = block.matrixsBlock[3];
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X + 30, block.matrixsBlock[1].Y);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y + 30);

            //            block.currentOrientation = 3;
            //            break;

            //        case 3:
            //            block.matrixsBlock[0] = block.matrixsBlock[2];
            //            block.matrixsBlock[1] = block.matrixsBlock[3];
            //            block.matrixsBlock[2] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y + 30);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);

            //            block.currentOrientation = 0;
            //            break;
            //    }

            //}

            //else if (block is IBlock)
            //{
            //    /* ПОЛОЖЕНИЕ 0:
            //     * 
            //     * [0][1][2][3]
            //     * 
            //     * ПОЛОЖЕНИЕ 1:
            //     *    [0]
            //     *    [1]
            //     *    [2]
            //     *    [3]
            //    */

            //    switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
            //    {
            //        case 0:
            //            block.matrixsBlock[1] = block.matrixsBlock[1];
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X - 30, block.matrixsBlock[1].Y);
            //            block.matrixsBlock[2] = new Point(block.matrixsBlock[1].X + 30, block.matrixsBlock[1].Y);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);

            //            block.currentOrientation = 1;
            //            break;

            //        case 1:
            //            block.matrixsBlock[1] = block.matrixsBlock[1];
            //            block.matrixsBlock[0] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y - 30);
            //            block.matrixsBlock[2] = new Point(block.matrixsBlock[1].X, block.matrixsBlock[1].Y + 30);
            //            block.matrixsBlock[3] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y + 30);

            //            block.currentOrientation = 0;
            //            break;
            //      }
            //}
        }
    }
}
