using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen Pen = new Pen(White);
            Pen.Width = 10;

            e.Graphics.DrawLine(Pen, 290, 250, 730, 250);
            e.Graphics.DrawLine(Pen, 290, 390, 730, 390);
            e.Graphics.DrawLine(Pen, 425, 130, 425, 520);
            e.Graphics.DrawLine(Pen, 593, 130, 593, 520);
        }

        private void pbIndex1_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex2_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex3_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex4_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex5_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex6_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex7_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex8_Click(object sender, EventArgs e)
        {

        }

        private void pbIndex9_Click(object sender, EventArgs e)
        {

        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {

        }

    }
}
