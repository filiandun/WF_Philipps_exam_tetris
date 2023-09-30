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
        public Point[] currentPositions;
        public byte currentOrientation;

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
            this.currentOrientation = 5;

            this.currentPositions = new Point[4]
            {
                new Point(171, 24),
                new Point(141, 54),
                new Point(171, 54),
                new Point(201, 54)
            };
        }
    }


    /****************
     *    [0][1]   *
     *    [2][3]   *
    ****************/

    public class OBlock : Block
    {
        public OBlock()
        {
            this.currentPositions = new Point[4]
            {
                new Point(141, 24),
                new Point(171, 24),
                new Point(141, 54),
                new Point(171, 54)
            };
        }
    }


    /****************
     *     [2][3]  *
     *  [0][1]     *
    ****************/

    public class SBlock : Block
    {
        public SBlock()
        {
            this.currentOrientation = 5;

            this.currentPositions = new Point[4]
            {
                new Point(111, 54),
                new Point(141, 54),
                new Point(141, 24),
                new Point(171, 24)
            };
        }
    }


    /****************
     *  [0][1]     *
     *     [2][3]  *
    ****************/

    public class ZBlock : Block
    {

        public ZBlock()
        {
            this.currentOrientation = 5;

            this.currentPositions = new Point[4]
            {
                new Point(111, 24),
                new Point(141, 24),
                new Point(141, 54),
                new Point(171, 54)
            };
        }
    }


    /****************
     *  [0]        *
     *  [1][2][3]  *
    ****************/

    public class JBlock : Block
    {
        public JBlock()
        {
            this.currentOrientation = 5;

            this.currentPositions = new Point[4]
            {
                new Point(111, 24),
                new Point(111, 54),
                new Point(141, 54),
                new Point(171, 54)
            };
        }
    }

    /****************
     *        [3]  *
     *  [0][1][2]  *
    ****************/

    public class LBlock : Block
    {
        public LBlock()
        {
            this.currentOrientation = 5;

            this.currentPositions = new Point[4]
            {
                new Point(111, 54),
                new Point(141, 54),
                new Point(171, 54),
                new Point(171, 24)
            };
        }
    }


    /*****************
     * [0][1][2][3] *
    *****************/

    public class IBlock : Block
    {
        public IBlock()
        {
            this.currentOrientation = 5;

            this.currentPositions = new Point[4]
            {
                new Point(111, 24),
                new Point(141, 24),
                new Point(171, 24),
                new Point(201, 24)
            };
        }
    }
}
