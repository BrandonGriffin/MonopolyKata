using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class LuxuryTaxTests
    {
        [Test]
        public void LuxuryTaxTakes75DollarsFromAPlayer()
        {
            var player = new Player("Horse");
            var players = new List<Player> { player };
            var teller = new Banker(players);
            var luxuryTax = new LuxuryTax(teller);
            teller.accounts[player] = 200;

            luxuryTax.SpaceAction(player);
            var afterTaxMoney = teller.accounts[player];

            Assert.That(afterTaxMoney, Is.EqualTo(125));
        }
    }
}
