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

        enum enPlayer { X, O }

        enPlayer CurrentPlayer = enPlayer.X;

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTurnLabel();
            UpdateWinnerLabel();
        }

        void UpdateTurn()
        {
            CurrentPlayer = (CurrentPlayer == enPlayer.X ? enPlayer.O : enPlayer.X);
        }

        void UpdateTurnLabel()
        {
            lblTurn.Text = (CurrentPlayer == enPlayer.X ? "Player 1" : "Player 2");
        }

        void UpdateWinnerLabel()
        {
            lblWinner.Text = "In Progress";
        }

        void HandleClick(PictureBox pb)
        {
            if (pb.Tag != null)
                return;

            pb.Image = (CurrentPlayer == enPlayer.X ? Resources.X : Resources.O);
            pb.Tag = CurrentPlayer;

            UpdateGame();
        }

        bool CheckDraw()
        {
            PictureBox[] Board =
            {
                pbIndex1, pbIndex2, pbIndex3,
                pbIndex4, pbIndex5, pbIndex6,
                pbIndex7, pbIndex8, pbIndex9
            };

            foreach (PictureBox pb in Board)
            {
                if (pb.Tag == null)
                    return false;
            }

            return true;
        }

        void UpdateGame()
        {
            if (CheckWinner())
            {
                lblTurn.Text = "Game Over";
                lblWinner.Text = (CurrentPlayer == enPlayer.X ? "Player 1" : "Player 2");
                DisableBoard();
                return;
            }

            if (CheckDraw())
            {
                lblTurn.Text = "Game Over";
                lblWinner.Text = "Tie";
                DisableBoard();
                return;
            }

            UpdateTurn();
            UpdateTurnLabel();
        }

        void DisableBoard()
        {
            pbIndex1.Enabled = false;
            pbIndex2.Enabled = false;
            pbIndex3.Enabled = false;
            pbIndex4.Enabled = false;
            pbIndex5.Enabled = false;
            pbIndex6.Enabled = false;
            pbIndex7.Enabled = false;
            pbIndex8.Enabled = false;
            pbIndex9.Enabled = false;
        }

        void EnableBoard()
        {
            pbIndex1.Enabled = true;
            pbIndex2.Enabled = true;
            pbIndex3.Enabled = true;
            pbIndex4.Enabled = true;
            pbIndex5.Enabled = true;
            pbIndex6.Enabled = true;
            pbIndex7.Enabled = true;
            pbIndex8.Enabled = true;
            pbIndex9.Enabled = true;
        }

        private void pbIndex1_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex1);
        }

        private void pbIndex2_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex2);
        }

        private void pbIndex3_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex3);
        }

        private void pbIndex4_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex4);
        }

        private void pbIndex5_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex5);
        }

        private void pbIndex6_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex6);
        }

        private void pbIndex7_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex7);
        }

        private void pbIndex8_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex8);
        }

        private void pbIndex9_Click(object sender, EventArgs e)
        {
            HandleClick(pbIndex9);
        }

        void ResetPictureBox(PictureBox pb)
        {
            pb.Image = Resources.question_mark_96;
            pb.Tag = null;
            pb.BackColor = Color.Black;
        }

        void RestartGame()
        {
            CurrentPlayer = enPlayer.X;

            EnableBoard();

            UpdateTurnLabel();
            UpdateWinnerLabel();

            ResetPictureBox(pbIndex1);
            ResetPictureBox(pbIndex2);
            ResetPictureBox(pbIndex3);
            ResetPictureBox(pbIndex4);
            ResetPictureBox(pbIndex5);
            ResetPictureBox(pbIndex6);
            ResetPictureBox(pbIndex7);
            ResetPictureBox(pbIndex8);
            ResetPictureBox(pbIndex9);
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        bool CheckWin(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            if (pb1.Tag == null ||
                pb2.Tag == null ||
                pb3.Tag == null)
                return false;

            if ((enPlayer)pb1.Tag == (enPlayer)pb2.Tag &&
                (enPlayer)pb2.Tag == (enPlayer)pb3.Tag)
            {
                pb1.BackColor = Color.Green;
                pb2.BackColor = Color.Green;
                pb3.BackColor = Color.Green;

                return true;
            }

            return false;
        }

        bool CheckWinner()
        {
            return
                (
                    CheckWin(pbIndex1, pbIndex2, pbIndex3) ||
                    CheckWin(pbIndex4, pbIndex5, pbIndex6) ||
                    CheckWin(pbIndex7, pbIndex8, pbIndex9) ||
                    CheckWin(pbIndex1, pbIndex4, pbIndex7) ||
                    CheckWin(pbIndex2, pbIndex5, pbIndex8) ||
                    CheckWin(pbIndex3, pbIndex6, pbIndex9) ||
                    CheckWin(pbIndex1, pbIndex5, pbIndex9) ||
                    CheckWin(pbIndex3, pbIndex5, pbIndex7)
                );
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
    }
}