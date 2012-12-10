using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MonopolyKata
{
    public class LuxuryTax : ISpace
    {
        public void LandOn(Player player)
        {
            player.ModifyPlayerBalance(-75);
        }

        public void PassBy(Player player)
        {
        }
    }
}
