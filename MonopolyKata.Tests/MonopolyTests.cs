using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class MonopolyTests
    {
        private Board board;
        private Player player;
        private Random random;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            board = new Board();
            player = new Player(random);
        }

        [Test]
        public void GameReturnsAMonopolyBoardWith40Spaces()
        {
            var actual = board.CreateBoard();
            Assert.That(actual, Is.EqualTo(new List<Int32>(40)));
        }

        [Test]
        public void PlayerCanRollDiceToMove()
        {
            var actual = player.Roll();
            Assert.That(actual, Is.LessThanOrEqualTo(12));
        }

        [Test]
        public void PlayersPositionUpdatesBasedOnDiceRoll()
        {
            player.Roll();
            var actual = player.Position;

            Assert.That(actual, Is.GreaterThan(1));
        }

        [Test]
        public void PlayersPositionCantBeHigherThan39()
        {
            rollMany(500);
            var actual = player.Position;

            Assert.That(actual, Is.LessThanOrEqualTo(39));
        }

        [Test]
        public void DiceRollsShouldBeSeeminglyRandom()
        {
            var rolls = new List<Int32>();
            rolls.Add(player.Roll());
            rolls.Add(player.Roll());

            Assert.That(rolls[0], Is.Not.EqualTo(rolls[1]));
        }

        [Test]
        public void GameShouldAllowForMulitplePlayers()
        {
            var player2 = new Player(random);

            player.Roll();
            player2.Roll();

            Assert.That(player.Position, Is.GreaterThan(1));
            Assert.That(player2.Position, Is.GreaterThan(1));
        }

        [Test]
        public void MultiplePlayersRollsAreSeeminglyRandom()
        {
            var player2 = new Player(random);

            player.Roll();
            player2.Roll();

            Assert.That(player.Position, Is.Not.EqualTo(player2.Position));
        }

        private void rollMany(Int32 timesToRoll)
        {
            for (var i = 0; i < timesToRoll; i++)
                player.Roll();
        }

    }
}
