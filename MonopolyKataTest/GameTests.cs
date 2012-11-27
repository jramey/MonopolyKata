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

        [TestInitialize]
        public void BeginTest()
        {
            game = new Game();
        }

        [TestMethod]
        public void CreateGameWithTwoPlayersCarAndHorse()
        {
            game.AddPlayer("Car");
            game.AddPlayer("Horse");
            var firsPlayer = game.GetPlayers().First();
            var secondPlayer = game.GetPlayers().Skip(1).First();

            Assert.AreEqual("Car", firsPlayer);
            Assert.AreEqual("Horse", secondPlayer);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void CreateGameWithLessThanTwoPlayersFail()
        {
            game.AddPlayer("One");
            game.CheckValidNumberOfPlayers();
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void CreateGameWithLMoreThanEightPlayersFail()
        {
            game.AddPlayer("One");
            game.AddPlayer("Two");
            game.AddPlayer("Three");
            game.AddPlayer("Four");
            game.AddPlayer("Five");
            game.AddPlayer("Six");
            game.AddPlayer("Seven");
            game.AddPlayer("Eight");
            game.AddPlayer("Nine");
            game.CheckValidNumberOfPlayers();
        }
        
        [TestMethod]
        public void GetNextPlayersTurn()
        {
            game.AddPlayer("Car");
            game.CreateTurnOrder();
            Assert.AreEqual("Car", game.GetNextTurn());
        }

        [TestMethod]
        public void PlayerTakeTurns()
        {
            game.AddPlayer("Car");
            game.AddPlayer("Horse");
            game.CreateTurnOrder();
            TakeManyTurns(2);
            Assert.AreEqual("Car", game.GetTurnsTaken().First());
            Assert.AreEqual("Horse", game.GetTurnsTaken().Skip(1).First());
        }

        [TestMethod]
        public void TakeTwentyTurns_OrderStaysTheSame()
        {
            game.AddPlayer("Car");
            game.AddPlayer("Horse");
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
            game.AddPlayer("Car");
            game.AddPlayer("Horse");
            game.CreateTurnOrder();
            var carCounter = 0;
            var horseCounter = 0;

            for (int i = 0; i < 40; i++)
            {
                TakeManyTurns(40);
            }

            for (int i = 0; i < 40; i++)
                if (game.GetTurnsTaken().ElementAt(i) == "Car")
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
