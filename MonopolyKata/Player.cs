using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Player
    {
        public String Name { get; private set; }
        public Int32 Position { get; private set; }
        public Int32 Balance { get; private set; }

        public Player(String Name)
        {
            this.Name = Name;
            SetupPlayer();
        }

        private void SetupPlayer()
        {
            Position = 0;
            Balance = 1500;
        }

        public void MovePlayer(Int32 Spaces)
        {
            Position = Position + Spaces;
            Position = Position % 40;
        }

        public override Int32 GetHashCode()
        {
            return Name.GetHashCode() ^ Position.GetHashCode();
        }

        public override Boolean Equals(Object obj)
        {
            if (obj is Player == false)
                return false;

            var otherPlayer = obj as Player;

            if (this.GetHashCode() != otherPlayer.GetHashCode())
                return false;

            if (this.Name != otherPlayer.Name || this.Position != otherPlayer.Position || this.Balance != otherPlayer.Balance)
                return false;

            return true;
        }

        public override String ToString()
        {
            return String.Format("({0}, {1}, {2})", Name, Position, Balance);
        }
    }
}
