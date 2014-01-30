using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var previousBalance = teller.bank[player1] = 200;
            properties[3].LandOnSpace(player1);

            Assert.That(teller.bank[player1], Is.EqualTo(previousBalance - 60));
        }

        [Test]
        public void LandingOnAnUnownedPropertyWillMakeThatPlayerTheOwner()
        {
            var previousBalance = teller.bank[player1] = 200;

            properties[3].LandOnSpace(player1);
            var positionOwner = properties[3].Owner;

            Assert.That(positionOwner, Is.EqualTo(player1));
        }

        [Test]
        public void PassingOverAnUnownedPropertyDoesNothing()
        {
            var previousBalance = teller.bank[player1] = 200;

            properties[3].PassOverSpace(player1);
            var positionOwner = properties[3].Owner;

            Assert.That(positionOwner, Is.EqualTo(null));
        }

        [Test]
        public void LandingOnAPropertyIOwnDoesNothing()
        {
            var previousBalance = teller.bank[player1] = 200;

            properties[3].LandOnSpace(player1);
            properties[3].LandOnSpace(player1);

            var afterLandingOnMySpace = teller.bank[player1];

            Assert.That(afterLandingOnMySpace, Is.EqualTo(140));
        }

        [Test]
        public void LandingOnAPropertyOwnedByAnotherPlayerDeductsRentFromMyAccount()
        {
            properties[3].LandOnSpace(player2);
            var beforeLandingOnSpace = teller.bank[player1];
            properties[3].LandOnSpace(player1);

            var afterLandingOnMySpace = teller.bank[player1];

            Assert.That(afterLandingOnMySpace, Is.EqualTo(beforeLandingOnSpace - properties[3].Rent));
        }

        [Test]
        public void IfAnotherPlayerLandsOnMyPropertyMyAccountIsCreditedWithRent()
        {
            properties[3].LandOnSpace(player2);
            var beforePropertyIsLandedOn = teller.bank[player2];
            
            properties[3].LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player2];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + properties[3].Rent));
        }

        [Test]
        public void IfAPlayerHasAMonopolyOfAColorRentDoubles()
        {
            properties[1].LandOnSpace(player2);
            properties[3].LandOnSpace(player2);

            var beforePropertyIsLandedOn = teller.bank[player2]; //getbalance

            properties[3].LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player2];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 8));
        }
    }
}
