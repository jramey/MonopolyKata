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
        private Int32 spacesToMove;
        private static Random random;
        Dice dice;

        public Game()
        {
            listOfPlayers = new List<Player>();
            turnOrder = new List<Player>();
            dummyPlayerList = new List<Player>();
            turnStack = new List<Player>();
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
            turnStack.Add(nextPlayer);
        }

        public void AddPlayer(Player piece)
        {
            listOfPlayers.Add(piece);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return listOfPlayers;
        }

        private void CheckValidNumberOfPlayers()
        {
            if (listOfPlayers.Count < 2 || listOfPlayers.Count > 8)
                throw new InvalidOperationException();
        }

        private void CreateTurnOrder()
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

        public List<Player> GetTurnsTaken()
        {
            return turnStack;
        }

        public int GetSpaceToMove()
        {
            return spacesToMove;
        }
    }
}
