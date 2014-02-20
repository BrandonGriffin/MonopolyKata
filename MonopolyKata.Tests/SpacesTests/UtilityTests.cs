using System;
using System.Collections.Generic;
using MonopolyKata.RentStrategies;
using MonopolyKata.Spaces;
using NUnit.Framework;

namespace MonopolyKata.Tests.SpacesTests
{
    [TestFixture]
    public class AnotherTypeOfSpaceTests
    {
        private String player1;
        private String player2;
        private String player3;
        private List<String> players;
        private Banker banker;
        private LoadedDice dice;
        private RealEstate electric;
        private RealEstate water;

        [SetUp]
        public void SetUp()
        {
            player1 = "Horse";
            player2 = "Car";
            player3 = "Dog";
            players = new List<String> { player1, player2, player3 };
            banker = new Banker(players, 1500);
            var utilities = new List<RealEstate>();
            dice = new LoadedDice();
            var utilityRentStrategy = new UtilityRentStrategy(utilities, dice);
            electric = new RealEstate(banker, 150, 0, utilityRentStrategy);
            water = new RealEstate(banker, 150, 0, utilityRentStrategy);

            utilities.AddRange(new[] { electric, water });
        }

        [Test]
        public void IfAPlayerLandsOnAnOwnedAnotherTypeOfSpaceRentIs4TimesDiceRoll()
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
