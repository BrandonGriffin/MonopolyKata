using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PropertyTests
    {
        private Player player1;
        private Player player2;
        private List<Player> players;
        private Teller teller;
        private Property property;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            teller = new Teller(players);
            property = new Property("Baltic Avenue", 60, 4, "Purple", teller);
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillDeductThePurchaseAmountFromThePlayer()
        {
            var previousBalance = teller.bank[player1] = 200;
            property.LandOnSpace(player1);

            Assert.That(teller.bank[player1], Is.EqualTo(previousBalance - 60));
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillMakeThatPlayerTheOwner()
        {
            var previousBalance = teller.bank[player1] = 200;

            property.LandOnSpace(player1);
            var positionOwner = property.Owner;

            Assert.That(positionOwner, Is.EqualTo(player1));
        }

        [Test]
        public void PassingOverAnUnownedPropertyDoesNothing()
        {
            var previousBalance = teller.bank[player1] = 200;

            property.PassOverSpace(player1);
            var positionOwner = property.Owner;

            Assert.That(positionOwner, Is.EqualTo(null));
        }

        [Test]
        public void LandingOnAPropertyIOwnDoesNothing()
        {
            var previousBalance = teller.bank[player1] = 200;

            property.LandOnSpace(player1);
            property.LandOnSpace(player1);

            var afterLandingOnMySpace = teller.bank[player1];

            Assert.That(afterLandingOnMySpace, Is.EqualTo(140));
        }

        [Test]
        public void LandingOnAPropertyOwnedByAnotherPlayerDeductsRentFromMyAccount()
        {
            property.Owner = player2;
            var beforeLandingOnSpace = teller.bank[player1];
            property.LandOnSpace(player1);

            var afterLandingOnMySpace = teller.bank[player1];

            Assert.That(afterLandingOnMySpace, Is.EqualTo(beforeLandingOnSpace - property.Rent));
        }

        [Test]
        public void IfAnotherPlayerLandsOnMyPropertyMyAccountIsCreditedWithRent()
        {
            property.Owner = player2;
            var beforePropertyIsLandedOn = teller.bank[player2];
            
            property.LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player2];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + property.Rent));
        }
    }
}
