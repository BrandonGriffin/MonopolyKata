using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PropertyTests
    {
        private Player player1;
        private Player player2;
        private List<Player> players;
        private Banker banker;
        private Property mediterranean;
        private Property baltic;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            banker = new Banker(players, 1500);
            var purples = new List<Property>();
            mediterranean = new Property("Mediterranean Avenue", 60, 2, banker, purples);
            baltic = new Property("Baltic Avenue", 60, 4, banker, purples);

            purples.AddRange(new[] { mediterranean, baltic });
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillDeductThePurchaseAmountFromThePlayer()
        {
            var previousBalance = banker.GetBalance(player1);
            baltic.LandOnSpace(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 60));
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillMakeThatPlayerTheOwner()
        {
            var previousBalance = banker.GetBalance(player1);

            baltic.LandOnSpace(player1);
            var positionOwner = baltic.Owner;

            Assert.That(positionOwner, Is.EqualTo(player1));
        }

        [Test]
        public void LandingOnAPropertyIOwnDoesNothing()
        {
            baltic.LandOnSpace(player1);
            baltic.LandOnSpace(player1);

            var afterLandingOnMySpace = banker.GetBalance(player1);

            Assert.That(afterLandingOnMySpace, Is.EqualTo(1440));
        }

        [Test]
        public void LandingOnAPropertyOwnedByAnotherPlayerDeductsRentFromMyAccount()
        {
            baltic.LandOnSpace(player2);
            var beforeLandingOnSpace = banker.GetBalance(player1);

            baltic.LandOnSpace(player1);
            var afterLandingOnMySpace = banker.GetBalance(player1);

            Assert.That(afterLandingOnMySpace, Is.EqualTo(beforeLandingOnSpace - 4));
        }

        [Test]
        public void IfAnotherPlayerLandsOnMyPropertyMyAccountIsCreditedWithRent()
        {
            baltic.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2);
            
            baltic.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 4));
        }

        [Test]
        public void IfAPlayerHasAMonopolyOfAColorRentDoubles()
        {
            mediterranean.LandOnSpace(player2);
            baltic.LandOnSpace(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2);
          
            baltic.LandOnSpace(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 8));
        }
    }
}
