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
        private Banker banker;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            dice = new Dice(random);
            banker = new Banker();
            player1 = new Player(dice, "Horse", banker);
            player2 = new Player(dice, "Car", banker);
            players = new List<Player>();

            players.Add(player1);
            players.Add(player2);
        }

        [Test]
        public void GameShouldNotAllowLessThan2Players()
        {
            var players = new List<Player>() { player1 };

            Assert.That(() => new Game(players, random), Throws.Exception.TypeOf<NotEnoughPlayersException>());
        }

        [Test]
        public void GameShouldNotAllowMoreThan8Players()
        {
            var player3 = new Player(dice, "Dog", banker);
            var player4 = new Player(dice, "Thimble", banker);
            var player5 = new Player(dice, "Top Hat", banker);
            var player6 = new Player(dice, "Cat", banker);
            var player7 = new Player(dice, "Shoe", banker);
            var player8 = new Player(dice, "Ship", banker);
            var player9 = new Player(dice, "Wheelbarrow", banker);
            var players = new List<Player>() { player1, player2, player3, player4, player5, player6, player7, player8, player9 };
            
            Assert.That(() => new Game(players, random), Throws.Exception.TypeOf<TooManyPlayersException>());
        }

        [Test]
        public void PlayerOrderShouldBeRandomlyGeneratedAtTheStartOfGame()
        {
            var carCount = 0;
            var horseCount = 0;

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(players, random);

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
            var game = new Game(players, random);
            game.Play();
            var actual = game.RoundsPlayed;

            Assert.That(actual, Is.EqualTo(20));
        }

        [Test]
        public void EachPlayerShouldTakeExactly20Turns()
        {
            var game = new Game(players, random);
            game.Play();

            Assert.That(player1.TurnsTaken, Is.EqualTo(20));
            Assert.That(player2.TurnsTaken, Is.EqualTo(20));
        }
    }
}
