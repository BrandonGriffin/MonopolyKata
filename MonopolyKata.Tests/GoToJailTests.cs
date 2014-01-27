using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GoToJailTests
    {
        private Teller teller;
        private Player player;
        private List<Player> players;
        private PositionKeeper positionKeeper;
        private GoToJail goToJail;

        [Test]
        public void IfAPlayerLandsOnGoToJailTheyGoToJail()
        {
            var jail = 10;
            player = new Player("Horse");
            players = new List<Player> { player };
            teller = new Teller(players);
            positionKeeper = new PositionKeeper(players, teller);
            goToJail = new GoToJail(positionKeeper, jail);

            goToJail.LandOnSpace(player);

            Assert.That(positionKeeper.PlayerPositions[player], Is.EqualTo(10));
        }
    }
}
