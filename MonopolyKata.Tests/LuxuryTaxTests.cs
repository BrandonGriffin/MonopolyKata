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
            var banker = new Banker(players, 1500);
            var luxuryTax = new LuxuryTax(banker);
            banker.Debit(player, 1300);

            luxuryTax.LandOnSpace(player);
            var afterTaxMoney = banker.GetBalance(player);

            Assert.That(afterTaxMoney, Is.EqualTo(125));
        }
    }
}
