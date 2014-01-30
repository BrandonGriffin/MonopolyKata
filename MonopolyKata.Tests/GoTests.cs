using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GoTests
    {
        private Player player;
        private List<Player> players;
        private Teller teller;
        private PositionKeeper positionKeeper;
        private Go go;
    
        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            teller = new Teller(players);
            var positionKeeperFactory = new PositionKeeperFactory();
            positionKeeper = positionKeeperFactory.Create(teller, players);
            go = new Go(teller);
        }

        [Test]
        public void PlayerShouldReceive200DollarsForLandingOnGo()
        {
            var beforeGoMoney = teller.bank[player];

            positionKeeper.MovePlayer(player, 40);

            Assert.That(teller.bank[player], Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceive200DollarsForPassingGo()
        {     
            var beforeGoMoney = teller.bank[player];

            positionKeeper.MovePlayer(player, 42);
            var afterGoMoney = teller.bank[player];
           
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceiver400ForPassingGoTwiceInASingleTurn()
        {
            teller.bank[player] = 0;
           
            positionKeeper.MovePlayer(player, 82);
            var afterGoMoney = teller.bank[player];
            
            Assert.That(afterGoMoney, Is.EqualTo(400));
        }
    }
}
