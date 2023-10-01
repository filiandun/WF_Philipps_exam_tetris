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
            if (block.currentY <= 19)
            {
                //block.previousY = block.currentY;
                block.currentY++;
            }    
        }

        public static void MoveLeft(Block block)
        {
            if (block.currentX > 0)
            {
                //block.previousX = block.currentX;
                block.currentX--;
            }
        }

        public static void MoveRight(Block block)
        {
            if (block.currentX < 10 - block.blockMatrix.GetLength(0))
            {
                //block.previousX = block.currentX;
                block.currentX++;
            }
        }

        //public static void Rotate(Block block)
        //{
        //    if (block.currentOrientation == 5) // костыль (в смысле, не цифра 5 должна быть, нужно придумать, как иначе сделать)
        //                                       // если поставить 0, то тогда при первом нажати фигура не будет поворачиваться
        //    {
        //        block.currentOrientation = 1;
        //    }

        //if (block is OBlock) // какой смысл вращать квадрат?
        //{
        //    return;
        //}

        //if (block is TBlock)
        //{
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

        //    switch (block.currentOrientation) // СТРОЧКИ В CASE НЕ МЕНЯТЬ МЕСТАМИ - СЛОМАЕТСЯ
        //    {
        //        case 0:
        //            block.matrixsBlock[3] = block.matrixsBlock[0];
        //            block.matrixsBlock[0] = block.matrixsBlock[1];
        //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X - 30, block.matrixsBlock[2].Y);

        //            block.currentOrientation = 1;
        //            break;

        //        case 1:
        //            block.matrixsBlock[3] = block.matrixsBlock[0];
        //            block.matrixsBlock[0] = block.matrixsBlock[1];
        //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y + 30);

        //            block.currentOrientation = 2; 
        //            break;

        //        case 2:
        //            block.matrixsBlock[3] = block.matrixsBlock[0];
        //            block.matrixsBlock[0] = block.matrixsBlock[1];
        //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X + 30, block.matrixsBlock[2].Y);

        //            block.currentOrientation = 3;
        //            break;

        //        case 3:
        //            block.matrixsBlock[3] = block.matrixsBlock[0];
        //            block.matrixsBlock[0] = block.matrixsBlock[1];
        //            block.matrixsBlock[1] = new Point(block.matrixsBlock[2].X, block.matrixsBlock[2].Y - 30);

        //            block.currentOrientation = 0;
        //            break;
        //    }
        //}

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
        //    }
        //}
        //}
    }
}
