using System;
using System.Collections.Generic;
using MonopolyKata.RentStrategies;
using MonopolyKata.Spaces;
using NUnit.Framework;

namespace MonopolyKata.Tests.SpacesTests
{
    [TestFixture]
    public class RailroadTests
    {
        private String player1;
        private String player2;
        private List<String> players;
        private Banker banker;
        private List<RealEstate> railroads;
        private RailroadRentStrategy railroadRentStrategy;
        private RealEstate reading;
        private RealEstate pennsylvania;
        private RealEstate bAndO;
        private RealEstate shortLine;

        [SetUp]
        public void SetUp()
        {
            player1 = "Horse";
            player2 = "Car";
            players = new List<String> { player1, player2 };
            banker = new Banker(players, 1500);
            railroads = new List<RealEstate>();
            railroadRentStrategy = new RailroadRentStrategy(railroads);
            reading = new RealEstate(banker, 200, 25, railroadRentStrategy);
            pennsylvania = new RealEstate(banker, 200, 25, railroadRentStrategy);
            bAndO = new RealEstate(banker, 200, 25, railroadRentStrategy);
            shortLine = new RealEstate(banker, 200, 25, railroadRentStrategy);

            railroads.AddRange(new[] { reading, pennsylvania, bAndO, shortLine });
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay50InRent()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player1); 

            pennsylvania.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 50));
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay100InRent()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);

            var beforePropertyIsLandedOn = banker.GetBalance(player1); 

            pennsylvania.LandOnSpace(player1);

            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 100));
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay200InRent()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);
            shortLine.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player1); 

            pennsylvania.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 200));
        }

        [Test]
        public void IfIOwnTwoRailroadsAndAPlayerLandsOnOneIGet50Dollars()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2); 

            pennsylvania.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 50));
        }

        [Test]
        public void IfIOwnThreeRailroadsAndAPlayerLandsOnOneIGet100Dollars()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2); 

            pennsylvania.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 100));
        }

        [Test]
        public void IfIOwnAllRailroadsAndAPlayerLandsOnOneIGet200Dollars()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);
            shortLine.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2); 

            pennsylvania.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 200));
        }
    }
}
