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
        private FakeDice dice;
        private List<Player> players;
        private Banker banker;
        private Mover mover;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            dice = new FakeDice();
            banker = new Banker();
            mover = new Mover(dice);
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            game = new Game(players, random, dice, mover, banker);
        }

        [Test]
        public void GameShouldNotAllowLessThan2Players()
        {
            var players = new List<Player>() { player1 };

            Assert.That(() => new Game(players, random, dice, mover, banker), Throws.Exception.TypeOf<NotEnoughPlayersException>());
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

            Assert.That(() => new Game(players, random, dice, mover, banker), Throws.Exception.TypeOf<TooManyPlayersException>());
        }

        [Test]
        public void PlayerOrderShouldBeRandomlyGeneratedAtTheStartOfGame()
        {
            var carCount = 0;
            var horseCount = 0;

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(players, random, dice, mover, banker);

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

            Assert.That(player1.TurnsTaken, Is.EqualTo(20));
            Assert.That(player2.TurnsTaken, Is.EqualTo(20));
        }

        [Test]
        public void IncomeTaxChargesAPlayer10PercentOfTheirCurrentMoney()
        {
            player1.Money = 200;
            dice.SetNumberToRoll(4);
            game.TakeTurn(player1);
            game.CheckPosition(player1);

            var afterTaxMoney = player1.Money;

            Assert.That(afterTaxMoney, Is.EqualTo(180));
        }

        [Test]
        public void IncomeTaxTakes200DollarsIfAPlayerHasOver2000()
        {
            player1.Money = 2500;
            dice.SetNumberToRoll(4);
            game.TakeTurn(player1);
            game.CheckPosition(player1);

            var afterTaxMoney = player1.Money;
            Assert.That(afterTaxMoney, Is.EqualTo(2300));
        }

        [Test]
        public void IncomeTaxTakesNothingIfAPlayerHasNoMoney()
        {
            dice.SetNumberToRoll(4);
            game.TakeTurn(player1);
            game.CheckPosition(player1);

            Assert.That(player1.Money, Is.EqualTo(0));
        }

        [Test]
        public void LuxuryTaxTakes75DollarsFromPlayer()
        {
            player1.Money = 200;
            dice.SetNumberToRoll(38);
            game.TakeTurn(player1);
            game.CheckPosition(player1);

            Assert.That(player1.Money, Is.EqualTo(125));
        }

        [Test]
        public void PlayerShouldReceive200DollarsForLandingOnGo()
        {
            dice.SetNumberToRoll(38);
            game.TakeTurn(player1);

            var beforeGoMoney = player1.Money;

            dice.SetNumberToRoll(2);
            game.TakeTurn(player1);
            game.CheckPosition(player1);

            var afterGoMoney = player1.Money;
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceive200DollarsForPassingGo()
        {
            dice.SetNumberToRoll(39);
            game.TakeTurn(player1);

            var beforeGoMoney = player1.Money;

            dice.SetNumberToRoll(2);
            game.TakeTurn(player1);
            game.CheckPosition(player1);

            var afterGoMoney = player1.Money;
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceiver400ForPassingGoTwiceInASingleTurn()
        {
            player1.Position = 4;
            dice.SetNumberToRoll(79);
            game.TakeTurn(player1);
            game.CheckPosition(player1);

            Assert.That(player1.Money, Is.EqualTo(400));
        }
    }
}
