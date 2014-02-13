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
        private Banker banker;
        private LoadedDice dice;
        private Utility electric;
        private Utility water;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            player3 = new Player("Dog");
            players = new List<Player> { player1, player2, player3 };
            banker = new Banker(players, 1500);
            var utilities = new List<Utility>();
            dice = new LoadedDice();
            electric = new Utility("Electric Company", banker, dice, utilities);
            water = new Utility("Water Works", banker, dice, utilities);

            utilities.AddRange(new[] { electric, water });
        }

        [Test]
        public void IfAPlayerLandsOnAnOwnedUtilityRentIs4TimesDiceRoll()
        {
            electric.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player1);
            var rolls = new Stack<Int32>();
            rolls.Push(1);
            rolls.Push(2);
            dice.SetNumberToRoll(rolls);
            dice.Roll();

            electric.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 12));
        }

        [Test]
        public void IfBothUtilitiesAreOwnedAndAPlayerLandsOnOneRentIs10TimesDiceRoll()
        {
            electric.LandOnSpace(player2);
            water.LandOnSpace(player3);
            var beforePropertyIsLandedOn = banker.GetBalance(player1);
            var rolls = new Stack<Int32>();
            rolls.Push(1);
            rolls.Push(2);
            dice.SetNumberToRoll(rolls);
            dice.Roll();

            electric.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 30));
        }
    }
}
