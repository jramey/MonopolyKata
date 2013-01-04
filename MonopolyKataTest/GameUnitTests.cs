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
        private FakeDice dice;

        [TestInitialize]
        public void SetupGameTest()
        {
            dice = new FakeDice();
            game = new Game(dice);
            horse = new Player("horse");
            car = new Player("car");
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
        public void NotRollingDoubleTurnGoesToNextPlayer()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.CreateTurnOrder();

            var player = game.GetTurnOrder().ElementAt(1);

            var fakeRolls = new[] { 2, 3 };
            dice.SetFakeRolls(fakeRolls);
            dice.Roll();

            game.AssignNextPlayer();

            Assert.AreEqual(player, game.GetNextTurn());
        }

        [TestMethod]
        public void RollingDoublesStaysPLayersTurn()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.CreateTurnOrder();

            var player = game.GetNextTurn();

            var fakeRolls = new[] { 2, 2 };
            dice.SetFakeRolls(fakeRolls);
            dice.Roll();

            game.AssignNextPlayer();

            Assert.AreEqual(player, game.GetNextTurn());
        }

        [TestMethod]
        public void PlayerRollsDoublesThreeTimesMovesToJustVisiting()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.CreateTurnOrder();

            var player = game.GetNextTurn();

            var fakeRolls = new[] { 2, 2, 3, 3, 4, 4 };
            dice.SetFakeRolls(fakeRolls);
            RollMany(3);

            Assert.AreEqual(10, player.Position);
        }

        public void RollMany(Int32 rolls)
        {
            for (int i = 0; i < rolls; i++)
            {
                dice.Roll();
                game.AssignNextPlayer();
            }
        }

        public void TakeManyTurns(Int32 turns)
        {
            for (int i = 0; i < turns; i++)
                game.TakeTurn();
        }
    }
}
