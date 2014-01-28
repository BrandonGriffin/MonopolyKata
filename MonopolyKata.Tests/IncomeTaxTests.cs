using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class IncomeTaxTests
    {
        private Player player;
        private List<Player> players;
        private Teller teller;
        private IncomeTax incomeTax;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            teller = new Teller(players);
            incomeTax = new IncomeTax(teller);
        }

        [Test]
        public void IncomeTaxChargesAPlayer10PercentOfTheirCurrentMoney()
        {
            teller.bank[player] = 200;

            incomeTax.LandOnSpace(player);
            var afterTaxMoney = teller.bank[player];

            Assert.That(afterTaxMoney, Is.EqualTo(180));
        }   
        
        [Test]
        public void IncomeTaxTakes200DollarsIfAPlayerHasOver2000()
        {
            teller.bank[player] = 2500;

            incomeTax.LandOnSpace(player);
            var afterTaxMoney = teller.bank[player];

            Assert.That(afterTaxMoney, Is.EqualTo(2300));
        }

        [Test]
        public void IncomeTaxTakesNothingIfAPlayerHasNoMoney()
        {
            teller.bank[player] = 0;
            incomeTax.LandOnSpace(player);
            var afterTaxMoney = teller.bank[player];
            Assert.That(afterTaxMoney, Is.EqualTo(0));
        }
    }
}
