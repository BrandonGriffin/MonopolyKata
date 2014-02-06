using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GoToJailTests
    {
        [Test]
        public void IfAPlayerLandsOnGoToJailTheyGoToJail()
        {
            var jail = 10;
            var player = new Player("Horse");
            var players = new List<Player> { player };
            var teller = new Teller(players);
            var positionKeeperFactory = new PositionKeeperFactory();
            var dice = new FakeDice();
            var guard = new PrisonGuard(players, teller, dice);
            var positionKeeper = positionKeeperFactory.Create(teller, players, dice, guard);
            var goToJail = new GoToJail(positionKeeper, jail, guard);

            goToJail.LandOnSpace(player);

            Assert.That(positionKeeper.GetPosition(player), Is.EqualTo(10));
        }
    }
}
