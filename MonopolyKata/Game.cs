using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Game
    {
        private List<Player> players;
        private List<Player> turnOrder;
        private List<Player> dummyPlayerList;
        private List<Player> turns;
        private Int32 currentPlayersTurn;
        private Player nextPlayer;
        private Int32 spacesToMove;
        private static Random random;
        Dice dice;

        public Game()
        {
            players = new List<Player>();
            turnOrder = new List<Player>();
            dummyPlayerList = new List<Player>();
            turns = new List<Player>();
            currentPlayersTurn = 0;
            random = new Random(1);
            dice = new Dice();
        }

        public void PlayGame()
        {
            CheckValidNumberOfPlayers();
            CreateTurnOrder();
            TakeTurn();
        }

        public void TakeTurn()
        {
            GetNextTurn();
            dice.Roll();
            spacesToMove = dice.GetRoll();
            nextPlayer.MovePlayer(spacesToMove);
            turns.Add(nextPlayer);
        }

        public void AddPlayer(Player piece)
        {
            players.Add(piece);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return players;
        }

        private void CheckValidNumberOfPlayers()
        {
            if (players.Count < 2 || players.Count > 8)
                throw new InvalidOperationException();
        }

        private void CreateTurnOrder()
        {
            CreateDummyPlayerList();
            
            foreach (Player player in players)
            {
                Player nextPievesToAdd = dummyPlayerList.ElementAt(random.Next(0, players.Count));
                turnOrder.Add(nextPievesToAdd);
                dummyPlayerList.Remove(nextPievesToAdd);
            }
        }

        private void CreateDummyPlayerList()
        {
            dummyPlayerList =  players.ToList();
        }

        public IEnumerable<Player> GetTurnOrder()
        {
            return turnOrder;
        }

        public Player GetNextTurn()
        {
            nextPlayer = turnOrder.ElementAt(currentPlayersTurn);
            IncrementTurnCounter();
            return nextPlayer;
        }

        private void IncrementTurnCounter()
        {
            if(currentPlayersTurn == players.Count - 1)
                currentPlayersTurn = 0;
            else
            currentPlayersTurn++;
        }

        public List<Player> GetTurnsTaken()
        {
            return turns;
        }

        public int GetSpaceToMove()
        {
            return spacesToMove;
        }
    }
}
