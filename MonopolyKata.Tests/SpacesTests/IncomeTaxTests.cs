using System.Collections.Generic;
using MonopolyKata.CoreComponents;
using MonopolyKata.Spaces;
using NUnit.Framework;

namespace MonopolyKata.Tests.SpacesTests
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
            banker = new Banker(players, 1500);
            incomeTax = new IncomeTax(banker, 200, 10);
        }

        [Test]
        public void IncomeTaxChargesAPlayer10PercentOfTheirCurrentMoney()
        {
            banker.Debit(player, 1300);

            incomeTax.LandOnSpace(player);
            var afterTaxMoney = banker.GetBalance(player);

            Assert.That(afterTaxMoney, Is.EqualTo(180));
        }   
        
        [Test]
        public void IncomeTaxTakes200DollarsIfAPlayerHasOver2000()
        {
            banker.Credit(player, 1000);

            incomeTax.LandOnSpace(player);
            var afterTaxMoney = banker.GetBalance(player);

            Assert.That(afterTaxMoney, Is.EqualTo(2300));
        }

        [Test]
        public void IncomeTaxTakesNothingIfAPlayerHasNoMoney()
        {
            banker.Debit(player, 1500);
            incomeTax.LandOnSpace(player);

            var afterTaxMoney = banker.GetBalance(player);
            Assert.That(afterTaxMoney, Is.EqualTo(0));
        }
    }
}
