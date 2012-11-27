using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Player
    {
        public Int32 Position { get; private set; }

        public Player()
        {
            Position = 0;
        }

        public void MovePlayer(Int32 Spaces)
        {
            Position = Position + Spaces;
            Position = Position % 40;
        }
    }
}
