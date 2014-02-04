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
        private Teller teller;
        private Property mediterranean;
        private Property baltic;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            teller = new Teller(players);
            var purples = new List<Property>();
            mediterranean = new Property("Mediterranean Avenue", 60, 2, teller, purples);
            baltic = new Property("Baltic Avenue", 60, 4, teller, purples);

            purples.AddRange(new[] { mediterranean, baltic });
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillDeductThePurchaseAmountFromThePlayer()
        {
            var previousBalance = teller.GetBalance(player1);
            baltic.LandOnSpace(player1);

            Assert.That(teller.GetBalance(player1), Is.EqualTo(previousBalance - 60));
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillMakeThatPlayerTheOwner()
        {
            var previousBalance = teller.GetBalance(player1);

            baltic.LandOnSpace(player1);
            var positionOwner = baltic.Owner;

            Assert.That(positionOwner, Is.EqualTo(player1));
        }

        [Test]
        public void PassingOverAnUnownedPropertyDoesNothing()
        {
            var previousBalance = teller.GetBalance(player1);

            baltic.PassOverSpace(player1);
            var positionOwner = baltic.Owner;

            Assert.That(positionOwner, Is.EqualTo(null));
        }

        [Test]
        public void LandingOnAPropertyIOwnDoesNothing()
        {
            var previousBalance = teller.GetBalance(player1);

            baltic.LandOnSpace(player1);
            baltic.LandOnSpace(player1);

            var afterLandingOnMySpace = teller.GetBalance(player1);

            Assert.That(afterLandingOnMySpace, Is.EqualTo(1440));
        }

        [Test]
        public void LandingOnAPropertyOwnedByAnotherPlayerDeductsRentFromMyAccount()
        {
            baltic.LandOnSpace(player2);
            var beforeLandingOnSpace = teller.GetBalance(player1);

            baltic.LandOnSpace(player1);
            var afterLandingOnMySpace = teller.GetBalance(player1);

            Assert.That(afterLandingOnMySpace, Is.EqualTo(beforeLandingOnSpace - baltic.Rent));
        }

        [Test]
        public void IfAnotherPlayerLandsOnMyPropertyMyAccountIsCreditedWithRent()
        {
            baltic.LandOnSpace(player2);
            var beforePropertyIsLandedOn = teller.GetBalance(player2);
            
            baltic.LandOnSpace(player1);
            var afterPropertyIsLandedOn = teller.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + baltic.Rent));
        }

        [Test]
        public void IfAPlayerHasAMonopolyOfAColorRentDoubles()
        {
            mediterranean.LandOnSpace(player2);
            baltic.LandOnSpace(player2);
            var beforePropertyIsLandedOn = teller.GetBalance(player2);
          
            baltic.LandOnSpace(player1);
            var afterPropertyIsLandedOn = teller.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 8));
        }
    }
}
