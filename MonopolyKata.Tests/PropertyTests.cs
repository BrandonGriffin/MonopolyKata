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
        private BalticAvenue baltic;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            teller = new Teller(players);
            baltic = new BalticAvenue(teller);
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillDeductThePurchaseAmountFromThePlayer()
        {
            var previousBalance = teller.bank[player] = 200;
            baltic.LandOnSpace(player);

            Assert.That(teller.bank[player], Is.EqualTo(previousBalance - 60));
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillMakeThatPlayerTheOwner()
        {
            var previousBalance = teller.bank[player] = 200;

            baltic.LandOnSpace(player);
            var positionOwner = baltic.Owner;

            Assert.That(positionOwner, Is.EqualTo("Horse"));
        }
    }
}
