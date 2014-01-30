using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class RailroadTest
    {
        private Player player1;
        private Player player2;
        private List<Player> players;
        private Teller teller;
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
            teller = new Teller(players);
            reading = new Railroad("Reading Railroad", teller);
            pennsylvania = new Railroad("Pennsylvania Railroad", teller);
            bAndO = new Railroad("B & O Railroad", teller);
            shortLine = new Railroad("Short Line", teller);
            var railroads = new List<Railroad> { reading, pennsylvania, bAndO, shortLine };

            foreach (var railroad in railroads)
                railroad.SetRailroads(railroads);

        }
        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay50InRent()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);

            var beforePropertyIsLandedOn = teller.bank[player1]; //getbalance

            pennsylvania.LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player1];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 50));
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay100InRent()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);

            var beforePropertyIsLandedOn = teller.bank[player1]; //getbalance

            pennsylvania.LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player1];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 100));
        }

        [Test]
        public void IfAPlayerLandsOnARailroadOwnedByAnotherRailroadOwnerTheyPay200InRent()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);
            shortLine.LandOnSpace(player2);

            var beforePropertyIsLandedOn = teller.bank[player1]; //getbalance

            pennsylvania.LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player1];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 200));
        }

        [Test]
        public void IfIOwnTwoRailroadsAndAPlayerLandsOnOneIGet50Dollars()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);

            var beforePropertyIsLandedOn = teller.bank[player2]; //getbalance

            pennsylvania.LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player2];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 50));
        }

        [Test]
        public void IfIOwnThreeRailroadsAndAPlayerLandsOnOneIGet100Dollars()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);

            var beforePropertyIsLandedOn = teller.bank[player2]; //getbalance

            pennsylvania.LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player2];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 100));
        }

        [Test]
        public void IfIOwnAllRailroadsAndAPlayerLandsOnOneIGet200Dollars()
        {
            reading.LandOnSpace(player2);
            pennsylvania.LandOnSpace(player2);
            bAndO.LandOnSpace(player2);
            shortLine.LandOnSpace(player2);

            var beforePropertyIsLandedOn = teller.bank[player2]; //getbalance

            pennsylvania.LandOnSpace(player1);

            var afterPropertyIsLandedOn = teller.bank[player2];

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn + 200));
        }
    }
}
