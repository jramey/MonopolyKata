using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class GameTests
    {
        private Game game;
        private Player Car;
        private Player Horse;

        [TestInitialize]
        public void BeginTest()
        {
            game = new Game();
            Horse = new Player("horse", 0);
            Car = new Player("car", 0);
            
        }

        [TestMethod]
        public void CreateGameWithTwoPlayersCarAndHorse()
        {
            var expectedFirstPlayer = Car;
            var expectedSecondPlayer = Horse;

            game.AddPlayer(expectedFirstPlayer);
            game.AddPlayer(expectedSecondPlayer);

            var firsPlayer = game.GetPlayers().First();
            var secondPlayer = game.GetPlayers().Skip(1).First();

            Assert.AreEqual(expectedFirstPlayer, firsPlayer);
            Assert.AreEqual(expectedSecondPlayer, secondPlayer);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void CreateGameWithLessThanTwoPlayersFail()
        {
            game.AddPlayer(Car);
            game.CheckValidNumberOfPlayers();
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void CreateGameWithLMoreThanEightPlayersFail()
        {
            Player three = new Player("three", 0);
            Player four = new Player("four", 0);
            Player five = new Player("five", 0);
            Player six = new Player("six", 0);
            Player seven = new Player("seven", 0);
            Player eight = new Player("eight", 0);
            Player nine = new Player("nine", 0);

            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.AddPlayer(three);
            game.AddPlayer(four);
            game.AddPlayer(five); 
            game.AddPlayer(six);
            game.AddPlayer(seven);
            game.AddPlayer(eight);
            game.AddPlayer(nine);

            game.CheckValidNumberOfPlayers();
        }

        [TestMethod]
        public void GetNextPlayersTurn()
        {
            var expectedNextPlayer = Car;
            game.AddPlayer(Car);
            game.CreateTurnOrder();
            Assert.AreEqual(expectedNextPlayer, game.GetNextTurn());
        }

        [TestMethod]
        public void PlayerTakeTurns()
        {
            var expectedFirstTurn = Car;
            var expectedSecondTurn = Horse;
            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.CreateTurnOrder();
            TakeManyTurns(2);
            Assert.AreEqual(expectedFirstTurn, game.GetTurnsTaken().First());
            Assert.AreEqual(expectedSecondTurn, game.GetTurnsTaken().Skip(1).First());
        }

        [TestMethod]
        public void TakeTwentyTurns_OrderStaysTheSame()
        {
            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.CreateTurnOrder();
            var firstPlayer = game.GetTurnOrder().First();
            var secondPlayer = game.GetTurnOrder().Skip(1).First();
            var counter = 0;

            for (int i = 0; i < 20; i++)
            {
                TakeManyTurns(40);

                if (counter % 2 == 0)
                    Assert.AreEqual(firstPlayer, game.GetTurnsTaken().ElementAt(counter));
                else
                    Assert.AreEqual(secondPlayer, game.GetTurnsTaken().ElementAt(counter));
            }
            counter++;
        }

        [TestMethod]
        public void TakeTwentyTurns_TwentyTurnsEach()
        {
            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.CreateTurnOrder();
            var carCounter = 0;
            var horseCounter = 0;

            for (int i = 0; i < 40; i++)
            {
                TakeManyTurns(40);
            }

            for (int i = 0; i < 40; i++)
                if (game.GetTurnsTaken().ElementAt(i) == Car)
                    carCounter++;
                else
                    horseCounter++;

            Assert.AreEqual(20, carCounter);
            Assert.AreEqual(20, horseCounter);
        }

        public void TakeManyTurns(Int32 turns)
        {
            for (int i = 0; i < turns; i++)
                game.TakeTurn();
        }
   }
}
