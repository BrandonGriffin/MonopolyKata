using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class UtilityTests
    {
        private Player player1;
        private Player player2;
        private Player player3;
        private List<Player> players;
        private Teller teller;
        private FakeDice dice;
        private Utility electric;
        private Utility water;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            player3 = new Player("Dog");
            players = new List<Player> { player1, player2, player3 };
            teller = new Teller(players);
            var utilities = new List<Utility>();
            dice = new FakeDice();
            electric = new Utility("Electric Company", teller, dice, utilities);
            water = new Utility("Water Works", teller, dice, utilities);

            utilities.AddRange(new[] { electric, water });
        }

        [Test]
        public void IfAPlayerLandsOnAnOwnedUtilityRentIs4TimesDiceRoll()
        {
            electric.LandOnSpace(player2);
            var beforePropertyIsLandedOn = teller.GetBalance(player1);
            var rolls = new Stack<Int32>();
            rolls.Push(1);
            rolls.Push(2);
            dice.SetNumberToRoll(rolls);
            dice.Roll();

            electric.LandOnSpace(player1);
            var afterPropertyIsLandedOn = teller.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 12));
        }

        [Test]
        public void IfBothUtilitiesAreOwnedAndAPlayerLandsOnOneRentIs10TimesDiceRoll()
        {
            electric.LandOnSpace(player2);
            water.LandOnSpace(player3);
            var beforePropertyIsLandedOn = teller.GetBalance(player1);
            var rolls = new Stack<Int32>();
            rolls.Push(1);
            rolls.Push(2);
            dice.SetNumberToRoll(rolls);
            dice.Roll();

            electric.LandOnSpace(player1);
            var afterPropertyIsLandedOn = teller.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 30));
        }
    }
}
