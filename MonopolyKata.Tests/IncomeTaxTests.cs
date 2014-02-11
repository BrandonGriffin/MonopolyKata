using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class IncomeTaxTests
    {
        private Player player;
        private List<Player> players;
        private Banker banker;
        private IncomeTax incomeTax;

        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            banker = new Banker(players);
            incomeTax = new IncomeTax(banker);
        }

        [Test]
        public void IncomeTaxChargesAPlayer10PercentOfTheirCurrentMoney()
        {
            banker.accounts[player] = 200;

            incomeTax.SpaceAction(player);
            var afterTaxMoney = banker.accounts[player];

            Assert.That(afterTaxMoney, Is.EqualTo(180));
        }   
        
        [Test]
        public void IncomeTaxTakes200DollarsIfAPlayerHasOver2000()
        {
            banker.accounts[player] = 2500;

            incomeTax.SpaceAction(player);
            var afterTaxMoney = banker.accounts[player];

            Assert.That(afterTaxMoney, Is.EqualTo(2300));
        }

        [Test]
        public void IncomeTaxTakesNothingIfAPlayerHasNoMoney()
        {
            banker.accounts[player] = 0;
            incomeTax.SpaceAction(player);
            var afterTaxMoney = banker.accounts[player];
            Assert.That(afterTaxMoney, Is.EqualTo(0));
        }
    }
}
