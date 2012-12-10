using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{  
    public class IncomeTax : ISpace
    {
        public void LandOn(Player player)
        {
            int tenPercentOfTotalWorth = (int)System.Math.Round(player.Balance * .1, 0);

            if (tenPercentOfTotalWorth > 200)
                player.ModifyPlayerBalance(-200);
            else
                player.ModifyPlayerBalance(-tenPercentOfTotalWorth);
        }

        public void PassBy(Player player)
        {
        }
    }
}
