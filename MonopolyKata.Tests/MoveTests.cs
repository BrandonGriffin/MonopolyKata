using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class MoveTests
    {
        private Player player1;
        private FakeDice dice;
        private Mover move;

        [SetUp]
        public void SetUp()
        {
            dice = new FakeDice();
            player1 = new Player("Horse");
            move = new Mover(dice);
        }
    
        [Test]
        public void PlayerCanRollDiceToMove()
        {
            dice.SetNumberToRoll(6);
            move.MovePlayer(player1);

            var actual = player1.Position;

            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void PlayersPositionCantBeHigherThan39()
        {
            dice.SetNumberToRoll(39);
            move.MovePlayer(player1);

            dice.SetNumberToRoll(3);
            move.MovePlayer(player1);

            var actual = player1.Position;

            Assert.That(actual, Is.EqualTo(2));
        }    

        [Test]
        public void IfAPlayerLandsOnSpace30TheyGoToSpace10()
        {
            dice.SetNumberToRoll(30);
            move.MovePlayer(player1);

            Assert.That(player1.Position, Is.EqualTo(10));
        }
    }
}
