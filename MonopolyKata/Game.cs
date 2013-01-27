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
        private static Random random;
        private Mover mover;
        private Dice dice;
        private Banker banker;
        private Board board;
        private Proprietor proprietor;
        private Gameplay gameplay;

       
        public Game(Dice dice)
        {
            players = new List<Player>();
            turnOrder = new List<Player>();
            dummyPlayerList = new List<Player>();
            random = new Random();
            banker = new Banker();
            this.dice = dice;
            board = new Board(banker, dice);
            mover = new Mover(dice, banker, board);
            proprietor = new Proprietor(banker);
            gameplay = new Gameplay(dice, mover, turnOrder);
        }

        public void PlayGame()
        {
            CheckValidNumberOfPlayers();
            CreateTurnOrder();

            while (CheckGameover() == false)
                CheckPlayersBalance();
                gameplay.TakeTurn();
        }

        public void CheckPlayersBalance()
        {
            foreach (var player in players)
                if (player.Balance < 0)
                    turnOrder.Remove(player);
        }

        public Boolean CheckGameover()
        {
            return (turnOrder.Count(p => p.Balance > 0) == 1);
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

        public void CreateTurnOrder()
        {
            CreateDummyPlayerList();
            
            foreach (Player player in players)
            {
                Player nextPievesToAdd = dummyPlayerList.ElementAt(random.Next(0, dummyPlayerList.Count - 1));
                turnOrder.Add(nextPievesToAdd);
                dummyPlayerList.Remove(nextPievesToAdd);
            }
        }

        private void CreateDummyPlayerList()
        {
            dummyPlayerList = players.ToList();
        }

        public IEnumerable<Player> GetTurnOrder()
        {
            return turnOrder;
        }
    }
}
