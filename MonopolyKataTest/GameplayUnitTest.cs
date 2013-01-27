using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKataTest
{
    [TestClass]
    public class GameplayUnitTest
    {
        private Game game;
        private Player car;
        private Player horse;
        private FakeDice dice;
        private Mover mover;
        private Banker banker;
        private Board board;
        private Gameplay gameplay;
        private List<Player> players;

        [TestInitialize]
        public void SetupGameTest()
        {
            dice = new FakeDice();
            game = new Game(dice);
            game = new Game(dice);
            horse = new Player("horse");
            car = new Player("car");
            players = new List<Player>();
            players.AddRange(new []  { horse, car } );
            mover = new Mover(dice, banker, board);
            banker = new Banker();
            board = new Board(banker, dice);
            gameplay = new Gameplay(dice, mover, players);
        }

        [TestMethod]
        public void NotRollingDoubleTurnGoesToNextPlayer()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.CreateTurnOrder();

            var player = gameplay.GetTurnOrder().ElementAt(1); ;

            var fakeRolls = new[] { 2, 3 };
            dice.SetFakeRolls(fakeRolls);
            dice.Roll();

            gameplay.AssignNextPlayer();

            Assert.AreEqual(player, gameplay.GetNextTurn());
        }

        [TestMethod]
        public void RollingDoublesStaysPLayersTurn()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.CreateTurnOrder();

            var player = gameplay.GetNextTurn();

            var fakeRolls = new[] { 2, 2 };
            dice.SetFakeRolls(fakeRolls);
            dice.Roll();

            gameplay.AssignNextPlayer();

            Assert.AreEqual(player, gameplay.GetNextTurn());
        }

        [TestMethod]
        public void PlayerRollsDoublesThreeTimesMovesToJustVisiting()
        {
            game.AddPlayer(car);
            game.AddPlayer(horse);
            game.CreateTurnOrder();

            var player = gameplay.GetNextTurn();

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
                gameplay.AssignNextPlayer();
            }
        }

        public void TakeManyTurns(Int32 turns)
        {
            for (int i = 0; i < turns; i++)
                gameplay.TakeTurn();
        }
    }
}
