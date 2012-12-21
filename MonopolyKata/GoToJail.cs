﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MonopolyKata
{
    public class GoToJail : Space
    {
        public GoToJail(String name, Int32 location, Banker banker)
            : base(name, location, banker)
        {
            Name = name;
            Location = location;
            Banker = banker;
        }

        public override void LandOn(Player player)
        {
            player.MovePlayer(10);
        }
    }
}
