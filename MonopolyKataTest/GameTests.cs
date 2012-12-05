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
        public void SetupGameTest()
        {
            game = new Game();
            Horse = new Player("horse");
            Car = new Player("car"); 
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
            game.PlayGame();
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void CreateGameWithLMoreThanEightPlayersFail()
        {
            var three = new Player("three");
            var four = new Player("four");
            var five = new Player("five");
            var six = new Player("six");
            var seven = new Player("seven");
            var eight = new Player("eight");
            var nine = new Player("nine");

            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.AddPlayer(three);
            game.AddPlayer(four);
            game.AddPlayer(five); 
            game.AddPlayer(six);
            game.AddPlayer(seven);
            game.AddPlayer(eight);
            game.AddPlayer(nine);

            game.PlayGame();
        }

        [TestMethod]
        public void FirstPlayTakeTheirTurn_GetTheNextPlayersTurn()
        {
            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.PlayGame();
            var expectedNextPlayer = game.GetTurnOrder().Skip(1).First(); ;
            Assert.AreEqual(expectedNextPlayer, game.GetNextTurn());
        }

        [TestMethod]
        public void BothPlayersTakeTheirTurns()
        {
            var expectedFirstTurn = Car;
            var expectedSecondTurn = Horse;
            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.PlayGame();
            TakeManyTurns(2);
            Assert.AreEqual(expectedFirstTurn, game.GetTurnsTaken().First());
            Assert.AreEqual(expectedSecondTurn, game.GetTurnsTaken().Skip(1).First());
        }

        [TestMethod]
        public void TakeTwentyTurns_OrderStaysTheSame()
        {
            game.AddPlayer(Car);
            game.AddPlayer(Horse);
            game.PlayGame();
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
            game.PlayGame();
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
