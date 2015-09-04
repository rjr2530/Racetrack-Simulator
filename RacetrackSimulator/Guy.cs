using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSimulator
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has " + Cash + " dollars";
            MyLabel.Text = MyBet.GetDescription(); 
        }

        public void ClearBet()
        {
            PlaceBet(0, 0);
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.Payout(Winner);
            ClearBet();
            UpdateLabels();
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            MyBet = new Bet() { Bettor = this, Amount = BetAmount, Dog = DogToWin };

            if (Cash > MyBet.Amount)
            {
                return true;
            }
            else
            {
                MessageBox.Show(this.Name + " " + "doesn't have enough money to place this bet.");
                return false;
            }
        }
    }
}
