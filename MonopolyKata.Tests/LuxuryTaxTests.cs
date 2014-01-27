using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class LuxuryTaxTests
    {
        private Player player;
        private List<Player> players;
        private Teller teller;
        private LuxuryTax luxuryTax;

        [Test]
        public void LuxuryTaxTakes75DollarsFromAPlayer()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            teller = new Teller(players);
            luxuryTax = new LuxuryTax(teller);

            teller.bank[player] = 200;

            luxuryTax.LandOnSpace(player);

            var afterTaxMoney = teller.bank[player];

            Assert.That(afterTaxMoney, Is.EqualTo(125));
        }
    }
}
