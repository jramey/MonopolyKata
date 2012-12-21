using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class IncomeTax : Space
    {
        public IncomeTax(String name, Int32 location, Banker banker)
            : base(name, location, banker)
        {
            Name = name;
            Location = location;
            Banker = banker;
        }

        public override void LandOn(Player player)
        {
            int tenPercentOfTotalWorth = (int)System.Math.Round(player.Balance * .1, 0);

            if (tenPercentOfTotalWorth > 200)
                Banker.CreditPlayerAccount(player, 200);
            else
                Banker.CreditPlayerAccount(player, tenPercentOfTotalWorth);
        }
    }
}
