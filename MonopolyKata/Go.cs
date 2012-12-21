using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Go : Space
    {
        public Go(String name, Int32 location, Banker banker)
            : base(name, location, banker)
        {
            Name = name;
            Location = location;
            Banker = banker;
        }

        public override void LandOn(Player player)
        {
            Banker.DebitPlayerAccount(player, 200);
        }
    }
}
