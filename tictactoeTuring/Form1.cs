using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoeTuring
{
    public partial class Form1 : Form
    {
        bool turn = true;//When true = x, when false = y
        int turnCount = 0; //+1 every turn , if 9 with no winner game ends

        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Code from Chris Merritt, found on youtube:https://www.youtube.com/watch?v=p3gYVcggQOU&list=PLkGLNXkfl8gWpswazjqXLgz9EMYSNuDCh ");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender; //converts sender object as a button, which is stored in b

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn; //change turn
            b.Enabled = false; //Disable button so other player can't change the value
            turnCount++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool thereIsAWinner = false;
            //horizontal victories
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                thereIsAWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereIsAWinner = true;

            //vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsAWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsAWinner = true;

            //Diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                thereIsAWinner = true;



            if (thereIsAWinner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                {
                    winner = "O";
                    oWinCount.Text = (Int32.Parse(oWinCount.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    xWinCount.Text = (Int32.Parse(xWinCount.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " wins!");
            }
            else
            {
                if (turnCount == 9)
                {
                    drawCount.Text = (Int32.Parse(drawCount.Text) + 1).ToString();
                    MessageBox.Show("Draw!");
                }
            }
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls) //For each buton on the form, disable it
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { } //KEEP THIS IN



        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            foreach (Control c in Controls) //For each buton on the form, disable it
                {
                    try
                    {
                        Button b = (Button)c; //convert to button
                        b.Enabled = turn;
                        b.Text = "";
                    }
                    catch { }
                }
            
        }

        private void button_enter(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender; //ref to button
                if (b.Enabled)
                {
                    if (turn)
                        b.Text = "X";
                    else
                        b.Text = "O";
                }

            }
            catch { }
         
        }


        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xWinCount.Text = "0";
            drawCount.Text = "0";
            xWinCount.Text = "0";
        }
    }
}
