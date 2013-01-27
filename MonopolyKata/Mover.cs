using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MonopolyKata
{
    public class Mover
    {
        private Board board;
        private Dice dice;
        private Banker banker;
        private int spacesToMove;

        public Mover(Dice dice, Banker banker, Board board)
        {
            this.banker = banker;
            this.dice = dice;
            this.board = board;
        }

        public void MovePlayerOnBoard(Player player)
        {
            var currentPosition = player.Position;
            var nextPosition = (currentPosition + spacesToMove) % 40;
            
            if (currentPosition > 0 && currentPosition >= nextPosition)
                banker.DebitPlayerAccount(player, 200);

            player.MovePlayer(nextPosition);
            var currentSpace = board.GetSpaceAtLocation(nextPosition);
            currentSpace.LandOn(player);
        }

        public void MovePlayerToJail(Player player)
        {
            player.Position = 10;
        }

        public void PlayerRolls()
        {
            dice.Roll();
            spacesToMove = dice.CurrentRoll;
        }

        public Int32 GetCurrentRollForPlayer()
        {
            return spacesToMove;
        }
    }
}
