using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MonopolyKata
{
    public class GoToJail : Space
    {
        public GoToJail(String name, Int32 location)
            : base(name, location)
        {
            Name = name;
            Location = location;
        }

        public override void LandOn(Player player)
        {
            player.MovePlayer(-20);
        }
    }
}
