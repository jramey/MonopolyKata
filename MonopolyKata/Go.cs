using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Go : ISpace
    {
        public void LandOn(Player player)
        {
            player.ModifyPlayerBalance(200);
        }

        public void PassBy(Player player)
        {
            player.ModifyPlayerBalance(200);
        }
    }
}
