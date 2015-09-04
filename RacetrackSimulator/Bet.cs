using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacetrackSimulator
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount > 0)
            {
                return Bettor.Name + " bets " + Amount + " bucks on dog " + Dog;
            }
            else
            {
                return Bettor.Name + " hasn't placed a bet";
            }
        }

        public int Payout(int Winner)
        {
            if (Dog == Winner + 1)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
            
        }
    }
}
