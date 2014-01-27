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
            var teller = new Teller(players);
            var luxuryTax = new LuxuryTax(teller);
            teller.bank[player] = 200;

            luxuryTax.LandOnSpace(player);
            var afterTaxMoney = teller.bank[player];

            Assert.That(afterTaxMoney, Is.EqualTo(125));
        }
    }
}
