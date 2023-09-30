using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();

            //for (int j = 0; j < 20; j++)
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        PictureBox pictureBoxBlock = new PictureBox()
            //        {
            //            Image = Properties.Resources.Block,
            //            Size = new Size(30, 30),
            //            Location = game.currentBlock.currentPositions[i],
            //            BackColor = Color.FromArgb(0, 0, 0, 0) // чтобы фон был прозрачным у pictureBox
            //        };

            //        game.Controls.Add(pictureBoxBlock);
            //    }

            //    game.Controls.Clear();
            //}
        }
    }
}
