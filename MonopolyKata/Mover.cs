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
        private int spacesToMove;
        
        public Mover()
        {
            board = new Board();
            dice = new Dice();
        }

        public void MovePlayerOnBoard(Player player)
        {
            ISpace currentSpace = board.GetSpaceAtLocation((player.Position + 1) % 40);
           
            for (int i = 1; i <= spacesToMove; i++)
            {
                currentSpace.PassBy(player);
                currentSpace = board.GetSpaceAtLocation((player.Position + i) % 40);
            }
            currentSpace.LandOn(player);
            AlterPlayersPosition(player);
        }

        private void AlterPlayersPosition(Player player)
        {
            player.MovePlayer(spacesToMove);
        } 

        public void PlayerRolls()
        {
            dice.Roll();
            spacesToMove = dice.GetRoll();
        }

        public Int32 GetCurrentRollForPlayer()
        {
            return spacesToMove;
        }

        public void SetSpacesToMove(Int32 spaces)
        {
            spacesToMove = spaces;
        }
    }
}
