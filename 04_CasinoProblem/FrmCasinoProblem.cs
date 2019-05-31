using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_CasinoProblem
{
    public partial class FrmCasinoProblem : Form
    {
        public FrmCasinoProblem()
        {
            InitializeComponent();
        }


        //At a casino, the following game is played between a player and the banker.The player pays the banker
        //$7.5 . The banker then pays the player $1, and spins the wheel again.Suppose the number this time is 24. The
        //banker pays another $1, and the process continues until a number is produced which has already occured.
        //Suppose the sequence of numbers is 17,24,18,31. The banker has paid the player $4.00 . At the next turn of the
        //wheel the number is 18 (a number already produced). At this point the game ends, and the player has lost
        //$3.50. Simulate 200 such games, and display the number of times the
        //player wins or loses, and the players total loss or gain.
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            LstView.Clear();
            int wins = 0;
            int losses = 0;
            double total = 0;

            for (int i = 1; i <= 200; i++)
            {
                int[] numbersPlayed = new int[37];
                PlayTheRoulette(numbersPlayed, ref wins, ref losses, ref total);
            }
            LstView.Items.Add("Wins: "+ wins.ToString() + " Losses: " + losses.ToString() + " Total: " + total.ToString());
        }

        private void PlayTheRoulette(int[] NP, ref int w, ref int l, ref double t)
        {
            Random r = new Random();
            double money = -7.50;
            
            //Check if there`s a previous number at the roulette
            for(int x = 1; x <= 36; x++)
            {
                int spin = r.Next(1, 37);
                NP[spin] += 1; //counter with number of times a number has been played
                if (NP[spin] == 1)
                {
                    money += 1;
                }
                else
                {
                    break;
                }
            }

            t = money;

            //Check if for every game the player has won more money than what he initially played (7.50$).
            if (money > 0)
            {
                w += 1;
            }
            else
            {
                l += 1;
            }
        }
    }
}
