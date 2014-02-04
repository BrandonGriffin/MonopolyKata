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
        private Teller teller;
        private PlayerTurnCounter turns;
        private PositionKeeper positionKeeper;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            dice = new Dice(random);
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            teller = new Teller(players);
            turns = new PlayerTurnCounter(players);
            var positionKeeperFactory = new PositionKeeperFactory();
            positionKeeper = positionKeeperFactory.Create(teller, players, dice);
            game = new Game(players, dice, positionKeeper, teller, turns);
        }

        [Test]
        public void GameShouldNotAllowLessThan2Players()
        {
            var players = new List<Player>() { player1 };

            Assert.That(() => new Game(players, dice, positionKeeper, teller, turns), Throws.Exception.TypeOf<NotEnoughPlayersException>());
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
            teller = new Teller(players);
            positionKeeper = new PositionKeeper(players);

            Assert.That(() => new Game(players, dice, positionKeeper, teller, turns), Throws.Exception.TypeOf<TooManyPlayersException>());
        }

        [Test]
        public void PlayerOrderShouldBeRandomlyGeneratedAtTheStartOfGame()
        {
            var carCount = 0;
            var horseCount = 0;

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(players, dice, positionKeeper, teller, turns);

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
    }
}
