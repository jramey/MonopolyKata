using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Game
    {
        private List<Player> listOfPlayers;
        private List<Player> turnOrder;
        private List<Player> dummyPlayerList;
        private List<Player> turnStack;
        private Int32 currentPlayersTurn;
        private Player nextPlayer;
        private static Random random;

        public Game()
        {
            listOfPlayers = new List<Player>();
            turnOrder = new List<Player>();
            dummyPlayerList = new List<Player>();
            turnStack = new List<Player>();
            currentPlayersTurn = 0;
            random = new Random(1);
        }

        public void AddPlayer(Player piece)
        {
            listOfPlayers.Add(piece);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return listOfPlayers;
        }

        public void CheckValidNumberOfPlayers()
        {
            if (listOfPlayers.Count < 2 || listOfPlayers.Count > 8)
                throw new InvalidOperationException();
        }

        public void CreateTurnOrder()
        {
            CreateDummyPlayerList();
            
            foreach (Player player in listOfPlayers)
            {
                Player nextPievesToAdd = dummyPlayerList.ElementAt(random.Next(0, listOfPlayers.Count));
                turnOrder.Add(nextPievesToAdd);
                dummyPlayerList.Remove(nextPievesToAdd);
            }
        }

        private void CreateDummyPlayerList()
        {
            dummyPlayerList =  listOfPlayers.ToList();
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
            if(currentPlayersTurn == listOfPlayers.Count - 1)
                currentPlayersTurn = 0;
            else
            currentPlayersTurn++;
        }

        public void TakeTurn()
        {
            GetNextTurn();
            turnStack.Add(nextPlayer);
        }

        public List<Player> GetTurnsTaken()
        {
            return turnStack;
        }
    }
}
