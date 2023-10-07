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

    public class OBlock : Block
    {
        public OBlock()
        {
            this.currentOrientation = 0;

            this.blockPoints = new Point[4]
            {
                new Point(4, 0),
                new Point(5, 0),
                new Point(4, 1),
                new Point(5, 1),
            };
        }
    }


    ///****************
    // *     [2][3]  *
    // *  [0][1]     *
    //****************/

    public class SBlock : Block
    {
        public SBlock()
        {
            this.currentOrientation = 0;

            this.blockPoints = new Point[4]
            {
                new Point(3, 1),
                new Point(4, 1),
                new Point(4, 0),
                new Point(5, 0)
            };
        }
    }


    ///****************
    // *  [0][1]     *
    // *     [2][3]  *
    //****************/

    public class ZBlock : Block
    {

        public ZBlock()
        {
        this.currentOrientation = 0;

        this.blockPoints = new Point[4]
        {
                new Point(3, 0),
                new Point(4, 0),
                new Point(4, 1),
                new Point(5, 1)
        };
    }
}


    ///****************
    // *  [0]        *
    // *  [1][2][3]  *
    //****************/

    public class JBlock : Block
    {
        public JBlock()
        {
            this.currentOrientation = 0;

            this.blockPoints = new Point[4]
            {
                new Point(4, 0),
                new Point(4, 1),
                new Point(5, 1),
                new Point(6, 1)
            };
        }
    }

    ///****************
    // *        [3]  *
    // *  [0][1][2]  *
    //****************/

    public class LBlock : Block
    {
        public LBlock()
        {
            this.currentOrientation = 0;

            this.blockPoints = new Point[4]
            {
                new Point(4, 1),
                new Point(5, 1),
                new Point(6, 1),
                new Point(6, 0)
            };
        }
    }


    ///*****************
    // * [0][1][2][3] *
    //*****************/

    public class IBlock : Block
    {
        public IBlock()
        {
            this.currentOrientation = 0;

            this.blockPoints = new Point[4]
            {
                new Point(3, 0),
                new Point(4, 0),
                new Point(5, 0),
                new Point(6, 0)
            };
        }
    }
}
