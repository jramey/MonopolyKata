using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MonopolyKata
{
    public class GoToJail : ISpace
    {
        public void LandOn(Player player)
        {
            player.MovePlayer(-20);
        }

        public void PassBy(Player player)
        {
        }
    }
}
