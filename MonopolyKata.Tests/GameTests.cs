using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Player player1;
        private Player player2;
        private Random random;
        private List<Player> players;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            player1 = new Player(random, "Horse");
            player2 = new Player(random, "Car");
            players = new List<Player>();

            players.Add(player1);
            players.Add(player2);
        }

        [Test]
        public void GameShouldNotAllowLessThan2Players()
        {
            var players = new List<Player>();   
            players.Add(player1);

            Assert.That(() => new Game(players, random), Throws.Exception.TypeOf<NotEnoughPlayersException>());
        }

        [Test]
        public void GameShouldNotAllowMoreThan8Players()
        {
            var player3 = new Player(random, "Dog");
            var player4 = new Player(random, "Thimble");
            var player5 = new Player(random, "Top Hat");
            var player6 = new Player(random, "Cat");
            var player7 = new Player(random, "Shoe");
            var player8 = new Player(random, "Ship");
            var player9 = new Player(random, "Wheelbarrow");
            var players = new List<Player>();

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            players.Add(player5);
            players.Add(player6);
            players.Add(player7);
            players.Add(player8);
            players.Add(player9);
            
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
                var actual = game.GetPlayerOrder();

                if (actual.First() == "Car")
                    carCount++;
                else
                    horseCount++;
            }

            Assert.That(carCount > 0 && horseCount > 0);
        }

        [Test]
        public void GameShouldLetPlayersTake20TurnsEach()
        {
            var game = new Game(players, random);

            for (var i = 0; i < 20; i++)
                game.PlayRound();

            Assert.That(player1.Position < 40 && player1.Position > -1);
            Assert.That(player2.Position < 40 && player2.Position > -1);
        }
    }
}
