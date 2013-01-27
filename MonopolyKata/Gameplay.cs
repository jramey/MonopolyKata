using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Gameplay
    {
        private Int32 currentPlayersTurn;
        private Player nextPlayer;
        private Dice dice;
        private Mover mover;
        private List<Player> turns;
        private List<Player> turnOrder;
        private Int32 rollDoublesCounter = 0;

        public Gameplay(Dice dice, Mover mover, List<Player> turnOrder)
        {
            this.dice = dice;
            this.mover = mover;
            currentPlayersTurn = 0;
            turns = new List<Player>();
            this.turnOrder = turnOrder;
        }

        public void TakeTurn()
        {
            GetNextTurn();
            mover.PlayerRolls();
            mover.MovePlayerOnBoard(nextPlayer);
            turns.Add(nextPlayer);

            AssignNextPlayer();
        }

        public Player GetNextTurn()
        {
            nextPlayer = turnOrder.ElementAt(currentPlayersTurn);
            return nextPlayer;
        }

        private void IncrementTurnCounter()
        {
            if (currentPlayersTurn == turnOrder.Count - 1)
                currentPlayersTurn = 0;
            else
                currentPlayersTurn++;
        }

        public void AssignNextPlayer()
        {
            if (dice.IsDoubles == false)
            {
                IncrementTurnCounter();
                rollDoublesCounter = 0;
            }
            else
            {
                rollDoublesCounter++;
                if (rollDoublesCounter == 3)
                    mover.MovePlayerToJail(nextPlayer);
            }
        }

        public List<Player> GetTurnsTaken()
        {
            return turns;
        }

        public IEnumerable<Player> GetTurnOrder()
        {
            return turnOrder;
        }
    }
}
