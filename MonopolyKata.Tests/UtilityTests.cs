using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class UtilityTests
    {
        private Player player1;
        private Player player2;
        private List<Player> players;
        private Teller teller;
        private Utility electric;
        private Utility water;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            teller = new Teller(players);
            var utilities = new List<Utility>();
            electric = new Utility("Electric Company", teller, utilities);
            water = new Utility("Water Works", teller, utilities);

            utilities.AddRange(new[] { electric, water });
        }

        [Test]
        public void IfAPlayerLandsOnAnOwnedUtilityRentIs4TimesDiceRoll()
        {
            electric.LandOnSpace(player2);
            var beforePropertyIsLandedOn = teller.GetBalance(player1);

            electric.LandOnSpace(player1);
            var afterPropertyIsLandedOn = teller.GetBalance(player1);

            Assert.That(afterPropertyIsLandedOn, Is.EqualTo(beforePropertyIsLandedOn - 50));
        }
    }
}
