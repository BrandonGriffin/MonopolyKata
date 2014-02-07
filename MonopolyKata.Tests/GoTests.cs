using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GoTests
    {
        private Player player;
        private List<Player> players;
        private Banker teller;
        private IDice dice;
        private Board positionKeeper;
        private Go go;
    
        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            teller = new Banker(players);
            var positionKeeperFactory = new BoardFactory();
            dice = new LoadedDice();
            var guard = new PrisonGuard(players, teller, dice);
            positionKeeper = positionKeeperFactory.Create(teller, players, dice, guard);
            go = new Go(teller);
        }

        [Test]
        public void PlayerShouldReceive200DollarsForLandingOnGo()
        {
            var beforeGoMoney = teller.accounts[player];

            positionKeeper.MovePlayer(player, 40);

            Assert.That(teller.accounts[player], Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceive200DollarsForPassingGo()
        {     
            var beforeGoMoney = teller.accounts[player];

            positionKeeper.MovePlayer(player, 42);
            var afterGoMoney = teller.accounts[player];
           
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceiver400ForPassingGoTwiceInASingleTurn()
        {
            teller.accounts[player] = 0;
           
            positionKeeper.MovePlayer(player, 82);
            var afterGoMoney = teller.accounts[player];
            
            Assert.That(afterGoMoney, Is.EqualTo(400));
        }
    }
}
