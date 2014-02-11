using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class RailroadTest
    {
        private Player player1;
        private Player player2;
        private List<Player> players;
        private Banker banker;
        private Railroad reading;
        private Railroad pennsylvania;
        private Railroad bAndO;
        private Railroad shortLine;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            banker = new Banker(players);
            var railroads = new List<Railroad>();
            reading = new Railroad("Reading Railroad", banker, railroads);
            pennsylvania = new Railroad("Pennsylvania Railroad", banker, railroads);
            bAndO = new Railroad("B & O Railroad", banker, railroads);
            shortLine = new Railroad("Short Line", banker, railroads);

            railroads.AddRange(new[] { reading, pennsylvania, bAndO, shortLine });
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay50InRent()
        {
            reading.SpaceAction(player2);
            pennsylvania.SpaceAction(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player1); 

            pennsylvania.SpaceAction(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 50));
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay100InRent()
        {
            reading.SpaceAction(player2);
            pennsylvania.SpaceAction(player2);
            bAndO.SpaceAction(player2);

            var beforePropertyIsLandedOn = banker.GetBalance(player1); 

            pennsylvania.SpaceAction(player1);

            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 100));
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay200InRent()
        {
            reading.SpaceAction(player2);
            pennsylvania.SpaceAction(player2);
            bAndO.SpaceAction(player2);
            shortLine.SpaceAction(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player1); 

            pennsylvania.SpaceAction(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 200));
        }

        [Test]
        public void IfIOwnTwoRailroadsAndAPlayerLandsOnOneIGet50Dollars()
        {
            reading.SpaceAction(player2);
            pennsylvania.SpaceAction(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2); 

            pennsylvania.SpaceAction(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 50));
        }

        [Test]
        public void IfIOwnThreeRailroadsAndAPlayerLandsOnOneIGet100Dollars()
        {
            reading.SpaceAction(player2);
            pennsylvania.SpaceAction(player2);
            bAndO.SpaceAction(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2); 

            pennsylvania.SpaceAction(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 100));
        }

        [Test]
        public void IfIOwnAllRailroadsAndAPlayerLandsOnOneIGet200Dollars()
        {
            reading.SpaceAction(player2);
            pennsylvania.SpaceAction(player2);
            bAndO.SpaceAction(player2);
            shortLine.SpaceAction(player2);
            var beforePropertyIsLandedOn = banker.GetBalance(player2); 

            pennsylvania.SpaceAction(player1);
            var afterPropertyIsLandedOn = banker.GetBalance(player2);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 200));
        }
    }
}
