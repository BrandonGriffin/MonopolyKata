using System;
using System.Collections.Generic;
using MonopolyKata.RentStrategies;
using MonopolyKata.Spaces;
using NUnit.Framework;

namespace MonopolyKata.Tests.SpacesTests
{
    [TestFixture]
    public class PropertyTests
    {
        private String player1;
        private String player2;
        private List<String> players;
        private Banker banker;
        private RealEstate mediterranean;
        private RealEstate baltic;

        [SetUp]
        public void SetUp()
        {
            player1 = "Horse";
            player2 = "Car";
            players = new List<String> { player1, player2 };
            banker = new Banker(players, 1500);
            var purples = new List<RealEstate>();
            var purpleRentStrategy = new PropertyRentStrategy(purples);
            mediterranean = new RealEstate(banker, 60, 2, purpleRentStrategy);
            baltic = new RealEstate(banker, 60, 4, purpleRentStrategy);

            purples.AddRange(new[] { mediterranean, baltic });
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillDeductThePurchaseAmountFromThePlayer()
        {
            var previousBalance = banker.GetBalance(player1);
            baltic.LandOnSpace(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 60));
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillMakeThatPlayerTheOwner()
        {
            var previousBalance = banker.GetBalance(player1);

            baltic.LandOnSpace(player1);
            var positionOwner = baltic.Owner;

            Assert.That(positionOwner, Is.EqualTo(player1));
        }

        [Test]
        public void LandingOnAPropertyIOwnDoesNothing()
        {
            baltic.LandOnSpace(player1);
            baltic.LandOnSpace(player1);

            var afterLandingOnMySpace = banker.GetBalance(player1);

            Assert.That(afterLandingOnMySpace, Is.EqualTo(1440));
        }

        [Test]
        public void LandingOnAPropertyOwnedByAnotherPlayerDeductsRentFromMyAccount()
        {
            baltic.LandOnSpace(player2);
            var beforeLandingOnSpace = banker.GetBalance(player1);

            baltic.LandOnSpace(player1);
            var afterLandingOnMySpace = banker.GetBalance(player1);

            Assert.That(afterLandingOnMySpace, Is.EqualTo(beforeLandingOnSpace - 4));
        }

        [Test]
        public void IfAnotherPlayerLandsOnMyPropertyMyAccountIsCreditedWithRent()
        {
            baltic.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2);
            
            baltic.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 4));
        }

        [Test]
        public void IfAPlayerHasAMonopolyOfAColorRentDoubles()
        {
            mediterranean.LandOnSpace(player2);
            baltic.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2);
          
            baltic.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 8));
        }
    }
}
