using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Properties;

namespace Tetris
{
    public abstract class Block
    {
        public Point[] blockPoints;
        public byte currentOrientation;

        public byte currentX;
        public byte currentY;

        //public byte previousX;
        //public byte previousY;

        public Block() { }
    }


    /****************
     *     [0]     *
     *  [1][2][3]  *
    ****************/

    public class TBlock : Block
    {
        public TBlock()
        {
            this.currentX = 4;
            this.currentY = 0;

            //this.previousX = currentX;
            //this.previousY = currentY;

            this.currentOrientation = 0;

            this.blockPoints = new Point[4]
            {
                new Point(5, 0),
                new Point(4, 1),
                new Point(5, 1),
                new Point(6, 1),
            };


        }
    }


    /****************
     *    [0][1]   *
     *    [2][3]   *
    ****************/

    //public class OBlock : Block
    //{
    //    public OBlock()
    //    {
    //        this.currentX = 4;
    //        this.currentY = 0;

    //        //this.previousX = currentX;
    //        //this.previousY = currentY;

    //        this.currentOrientation = 0;

    //        this.blockMatrix = new byte[2, 3];
    //        for (int i = 0; i < 3; i++)
    //        {
    //            this.blockMatrix[1, i] = 2;
    //        }
    //        this.blockMatrix[0, 1] = 2;
    //    }
    //}


    ///****************
    // *     [2][3]  *
    // *  [0][1]     *
    //****************/

    //public class SBlock : Block
    //{
    //    public SBlock()
    //    {
    //        this.currentOrientation = 5;

    //        this.matrixsBlock = new Point[4]
    //        {
    //            new Point(111, 54),
    //            new Point(141, 54),
    //            new Point(141, 24),
    //            new Point(171, 24)
    //        };
    //    }
    //}


    ///****************
    // *  [0][1]     *
    // *     [2][3]  *
    //****************/

    //public class ZBlock : Block
    //{

    //    public ZBlock()
    //    {
    //        this.currentOrientation = 5;

    //        this.matrixsBlock = new Point[4]
    //        {
    //            new Point(111, 24),
    //            new Point(141, 24),
    //            new Point(141, 54),
    //            new Point(171, 54)
    //        };
    //    }
    //}


    ///****************
    // *  [0]        *
    // *  [1][2][3]  *
    //****************/

    //public class JBlock : Block
    //{
    //    public JBlock()
    //    {
    //        this.currentOrientation = 5;

    //        this.matrixsBlock = new Point[4]
    //        {
    //            new Point(111, 24),
    //            new Point(111, 54),
    //            new Point(141, 54),
    //            new Point(171, 54)
    //        };
    //    }
    //}

    ///****************
    // *        [3]  *
    // *  [0][1][2]  *
    //****************/

    //public class LBlock : Block
    //{
    //    public LBlock()
    //    {
    //        this.currentOrientation = 5;

    //        this.matrixsBlock = new Point[4]
    //        {
    //            new Point(111, 54),
    //            new Point(141, 54),
    //            new Point(171, 54),
    //            new Point(171, 24)
    //        };
    //    }
    //}


    ///*****************
    // * [0][1][2][3] *
    //*****************/

    //public class IBlock : Block
    //{
    //    public IBlock()
    //    {
    //        this.currentOrientation = 5;

    //        this.matrixsBlock = new Point[4]
    //        {
    //            new Point(111, 24),
    //            new Point(141, 24),
    //            new Point(171, 24),
    //            new Point(201, 24)
    //        };
    //    }
    //}
}
