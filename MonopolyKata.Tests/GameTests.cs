using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Player player1;
        private Player player2;
        private Random random;
        private Dice dice;
        private List<Player> players;
        private Banker teller;
        private PlayerTurnCounter turns;
        private Board positionKeeper;
        private PrisonGuard guard;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            dice = new Dice(random);
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            teller = new Banker(players);
            turns = new PlayerTurnCounter(players);
            var positionKeeperFactory = new BoardFactory();
            guard = new PrisonGuard(players, teller, dice);
            positionKeeper = positionKeeperFactory.Create(teller, players, dice, guard);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);
        }

        [Test]
        public void GameShouldNotAllowLessThan2Players()
        {
            var players = new List<Player>() { player1 };

            Assert.That(() => new Game(players, dice, positionKeeper, teller, turns, guard), Throws.Exception.TypeOf<NotEnoughPlayersException>());
        }

        [Test]
        public void GameShouldNotAllowMoreThan8Players()
        {
            var player3 = new Player("Dog");
            var player4 = new Player("Thimble");
            var player5 = new Player("Top Hat");
            var player6 = new Player("Cat");
            var player7 = new Player("Shoe");
            var player8 = new Player("Ship");
            var player9 = new Player("Wheelbarrow");
            var players = new List<Player>() { player1, player2, player3, player4, player5, player6, player7, player8, player9 };
            teller = new Banker(players);
            var guard = new PrisonGuard(players, teller, dice);
            positionKeeper = new Board(players, guard);

            Assert.That(() => new Game(players, dice, positionKeeper, teller, turns, guard), Throws.Exception.TypeOf<TooManyPlayersException>());
        }

        [Test]
        public void PlayerOrderShouldBeRandomlyGeneratedAtTheStartOfGame()
        {
            var carCount = 0;
            var horseCount = 0;

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(players, dice, positionKeeper, teller, turns, guard);

                if (game.Players.First().Name == "Car")
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
            var rolls = new[] { 2, 6, 4, 2, 3, 3, 2, 1 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);

            game.TakeTurn(player1);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(9));
        }

        [Test]
        public void IfAPlayerRollsDoublesTwiceGetTwoExtraTurns()
        {
            var dice = new LoadedDice();
            var rolls = new[] { 2, 6, 4, 2, 3, 3, 2, 2, 1, 2 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);

            game.TakeTurn(player1);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(13));
        }
        
        [Test]
        public void IfAPlayerRollsDoublesThriceTheyGoToJail()
        {
            var dice = new LoadedDice();
            var rolls = new Stack<Int32>();
            rolls.Push(2);
            rolls.Push(1);
            rolls.Push(4);
            rolls.Push(4);
            rolls.Push(2);
            rolls.Push(2);
            rolls.Push(3);
            rolls.Push(3);
            rolls.Push(2);
            rolls.Push(4);
            rolls.Push(6);
            rolls.Push(2);
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);

            game.TakeTurn(player1);
            
            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(10));
        }
    }
}