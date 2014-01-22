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
        private Player player;
        private FakeDice dice;

        [SetUp]
        public void SetUp()
        {
            dice = new FakeDice();
            player = new Player(dice, "Horse");
        }

        [Test]
        public void PlayerCanRollDiceToMove()
        {
            dice.SetNumberToRoll(6);
            player.RollDice();
            var actual = player.Position;

            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void PlayersPositionCantBeHigherThan39()
        {
            dice.SetNumberToRoll(39);
            player.RollDice();

            dice.SetNumberToRoll(3);
            player.RollDice();

            var actual = player.Position;

            Assert.That(actual, Is.EqualTo(2));
        }
    }
}
