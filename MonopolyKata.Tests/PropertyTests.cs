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
        private Player player;
        private List<Player> players;
        private Teller teller;
        private IProperty property;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            teller = new Teller(players);
            property = new BalticAvenue(teller);
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillDeductThePurchaseAmountFromThePlayer()
        {
            var previousBalance = teller.bank[player] = 200;
            property.LandOnSpace(player);

            Assert.That(teller.bank[player], Is.EqualTo(previousBalance - 60));
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillMakeThatPlayerTheOwner()
        {
            var previousBalance = teller.bank[player] = 200;

            property.LandOnSpace(player);
            var positionOwner = property.Owner;

            Assert.That(positionOwner, Is.EqualTo("Horse"));
        }

        [Test]
        public void PassingOverAnUnownedPropertyDoesNothing()
        {
            var previousBalance = teller.bank[player] = 200;

            property.PassOverSpace(player);
            var positionOwner = property.Owner;

            Assert.That(positionOwner, Is.EqualTo(null));
        }

        [Test]
        public void LandingOnAPropertyIOwnDoesNothing()
        {
            var previousBalance = teller.bank[player] = 200;

            property.LandOnSpace(player);
            property.LandOnSpace(player);

            var afterLandingOnMySpace = teller.bank[player];

            Assert.That(afterLandingOnMySpace, Is.EqualTo(140));
        }
    }
}
