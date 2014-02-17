using System.Collections.Generic;
using MonopolyKata.CoreComponents;
using MonopolyKata.Spaces;
using NUnit.Framework;

namespace MonopolyKata.Tests.SpacesTests
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
            var luxuryTax = new LuxuryTax(banker, 75);

            luxuryTax.LandOnSpace(player);
            var afterTaxMoney = banker.GetBalance(player);

            Assert.That(afterTaxMoney, Is.EqualTo(1425));
        }
    }
}
