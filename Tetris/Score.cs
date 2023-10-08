using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Score
    {
        private ushort score;

        public Score() 
        {
            this.score = 0;
        }


        public void GetPointsForBlock(ref Label label)
        {
            this.score += 10;
            this.SetScore(ref label);
        }

        public void GetPointsForLine(ref Label label)
        {
            this.score += 100;
            this.SetScore(ref label);
        }

        private void SetScore(ref Label label)
        {
            label.Text = $"{this.score}";
        }


        public ushort GetScore()
        {
            return this.score;
        }

    }
}
