using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GameTests
    {
        private String player1;
        private String player2;
        private Random random;
        private Dice dice;
        private List<String> players;
        private Banker banker;
        private PlayerTurnCounter turns;
        private Board board;
        private PrisonGuard guard;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            dice = new Dice(random);
            player1 = "Horse";
            player2 = "Car";
            players = new List<String> { player1, player2 };
            banker = new Banker(players, 1500);
            turns = new PlayerTurnCounter(players);
            var boardFactory = new BoardFactory();
            guard = new PrisonGuard(banker, dice);
            board = boardFactory.Create(banker, players, dice, guard);
            game = new Game(players, dice, board, turns, guard);
        }

        [Test]
        public void GameShouldNotAllowLessThan2Players()
        {
            var players = new List<String>() { player1 };

            Assert.That(() => new Game(players, dice, board, turns, guard), Throws.Exception.TypeOf<Game.NotEnoughPlayersException>());
        }

        [Test]
        public void GameShouldNotAllowMoreThan8Players()
        {
            var player3 = "Dog";
            var player4 = "Thimble";
            var player5 = "Top Hat";
            var player6 = "Cat";
            var player7 = "Shoe";
            var player8 = "Ship";
            var player9 = "Wheelbarrow";
            var players = new List<String>() { player1, player2, player3, player4, player5, player6, player7, player8, player9 };
            banker = new Banker(players, 1500);
            var guard = new PrisonGuard(banker, dice);
            board = new Board(players);

            Assert.That(() => new Game(players, dice, board, turns, guard), Throws.Exception.TypeOf<Game.TooManyPlayersException>());
        }

        [Test]
        public void PlayerOrderShouldBeRandomlyGeneratedAtTheStartOfGame()
        {
            var carCount = 0;
            var horseCount = 0;

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(players, dice, board, turns, guard);

                if (game.Players.First() == "Car")
                    carCount++;
                else
                    horseCount++;
            }

            Assert.That(carCount, Is.GreaterThan(0));
            Assert.That(horseCount, Is.GreaterThan(0));
        }

        [Test]
        public void GameShouldLetPlayersTake20Turns()
        {
            game.Play();
            var actual = game.RoundsPlayed;

            Assert.That(actual, Is.EqualTo(20));
        }

        [Test]
        public void EachPlayerShouldTakeExactly20Turns()
        {
            game.Play();

            Assert.That(turns.TurnsTaken[player1], Is.EqualTo(20));
            Assert.That(turns.TurnsTaken[player2], Is.EqualTo(20));
        }

        [Test]
        public void IfAPlayerRollsDoublesTheyGetToTakeAnExtraTurn()
        {
            var dice = new LoadedDice();
            var rolls = new[] { 3, 3, 2, 1 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, board, turns, guard);

            game.TakeTurn(player1);

            Assert.That(board.GetPosition(player1), Is.EqualTo(9));
        }

        [Test]
        public void IfAPlayerRollsDoublesTwiceGetTwoExtraTurns()
        {
            var dice = new LoadedDice();
            var rolls = new[] { 3, 3, 2, 2, 1, 2 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, board, turns, guard);

            game.TakeTurn(player1);

            Assert.That(board.GetPosition(player1), Is.EqualTo(13));
        }
        
        [Test]
        public void IfAPlayerRollsDoublesThriceTheyGoToJail()
        {
            var dice = new LoadedDice();
            var rolls = new[] { 3, 3, 2, 2, 4, 4, 1, 2 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, board, turns, guard);

            game.TakeTurn(player1);
            
            Assert.That(board.GetPosition(player1), Is.EqualTo(10));
        }
    }
}