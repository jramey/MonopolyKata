using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MonopolyKata
{
    public class LuxuryTax : Space
    {
        public LuxuryTax(String name, Int32 location)
            : base(name, location)
        {
            Name = name;
            Location = location;
        }

        public override void LandOn(Player player)
        {
            player.ModifyPlayerBalance(-75);
        }
    }
}
