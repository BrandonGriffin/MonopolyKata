using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Random random;
        private Mock mock;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            board = new Board();
            player1 = new Player(random, "Horse");
            player2 = new Player(random, "Car");
            //mock = new Mock<IDice>();
        }

        [Test]
        public void BoardReturnsABoardWithThe40MonopolySpacesNumbered()
        {
            var actual = board.CreateBoard();
            var expected = new List<Int32> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                             11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                                             21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                                             31, 32, 33, 34, 35, 36, 37, 38, 39 };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PlayerCanRollDiceToMove()
        {
            player1.RollDice();
            var actual = player1.Position;

            Assert.That(actual, Is.LessThanOrEqualTo(12));
        }

        [Test]
        public void PlayersPositionUpdatesBasedOnDiceRoll()
        {
            player1.RollDice();
            var actual = player1.Position;

            Assert.That(actual, Is.GreaterThan(1));
        }

        [Test]
        public void PlayersPositionCantBeHigherThan39()
        {
            rollMany(500);
            var actual = player1.Position;

            Assert.That(actual, Is.LessThanOrEqualTo(39));
        }

        [Test]
        public void GameShouldAllowForMulitplePlayers()
        {
            player1.RollDice();
            player2.RollDice();

            Assert.That(player1.Position, Is.GreaterThan(1));
            Assert.That(player2.Position, Is.GreaterThan(1));
        }


        private void rollMany(Int32 timesToRoll)
        {
            for (var i = 0; i < timesToRoll; i++)
                player1.RollDice();
        }

    }
}
