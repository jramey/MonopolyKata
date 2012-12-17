﻿using System;
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
            var currentPosition = player.Position;
            var nextPosition = (currentPosition + spacesToMove) % 40;
            
            if (currentPosition > 0 && currentPosition >= nextPosition)
                player.ModifyPlayerBalance(200);
            player.MovePlayer(nextPosition);
            var currentSpace = board.GetSpaceAtLocation(nextPosition);
            currentSpace.LandOn(player);
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
