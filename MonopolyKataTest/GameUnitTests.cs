using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTest
{
    [TestClass]
    public class GameUnitTests
    {
        private Game game;
        private Player car;
        private Player horse;
        private Player player3;
        private FakeDice dice;

        [TestInitialize]
        public void SetupGameTest()
        {
            dice = new FakeDice();
            game = new Game(dice);
            horse = new Player("horse");
            car = new Player("car");
            player3 = new Player("Player 3");
        }

        [TestMethod]
        public void CreateGameWithTwoPlayersCarAndHorse()
        {
            var expectedFirstPlayer = car;
            var expectedSecondPlayer = horse;

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
            game.AddPlayer(car);
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

            game.AddPlayer(car);
            game.AddPlayer(horse);
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
        public void GameOverIsSetWhenOnlyOnePlayerHasMoneyLeft()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.CreateTurnOrder();
            horse.ModifyPlayerBalance(-1501);

            Assert.IsTrue(game.CheckGameover());
        }

        [TestMethod]
        public void PlayerIsRemovedFromOrderWhenBalanceIsLessThanZero()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.AddPlayer(player3);

            var playerCount = 3;

            game.CreateTurnOrder();
            horse.ModifyPlayerBalance(-1501);
            game.CheckPlayersBalance();

            Assert.AreEqual(playerCount- 1, game.GetTurnOrder().Count());
        }
    }
}
