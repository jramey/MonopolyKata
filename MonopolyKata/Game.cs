using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Game
    {
        private List<String> listOfPlayers;
        private List<String> turnOrder;
        private List<String> dummyPlayerList;
        private List<String> turnStack;
        private Int32 currentPlayersTurn;
        private String nextPlayer;
        private static Random random;

        public Game()
        {
            listOfPlayers = new List<String>();
            turnOrder = new List<string>();
            dummyPlayerList = new List<String>();
            turnStack = new List<String>();
            currentPlayersTurn = 0;
            random = new Random(1);
        }

        public void AddPlayer(string Piece)
        {
            listOfPlayers.Add(Piece);
        }

        public IEnumerable<String> GetPlayers()
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
            
            foreach (String player in listOfPlayers)
            {
                string nextPievesToAdd = dummyPlayerList.ElementAt(random.Next(0, listOfPlayers.Count));
                turnOrder.Add(nextPievesToAdd);
                dummyPlayerList.Remove(nextPievesToAdd);
            }
        }

        private void CreateDummyPlayerList()
        {
            dummyPlayerList =  listOfPlayers.ToList();
        }

        public IEnumerable<String> GetTurnOrder()
        {
            return turnOrder;
        }

        public String GetNextTurn()
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

        public List<String> GetTurnsTaken()
        {
            return turnStack;
        }
    }
}
