using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class GoTests
    {
        private Player player;
        private List<Player> players;
        private Banker banker;
        private IDice dice;
        private Board board;
        private Go go;
    
        [SetUp]
        public void SetUp()
        {
            player = new Player("Horse");
            players = new List<Player> { player };
            banker = new Banker(players);
            var boardFactory = new BoardFactory();
            dice = new LoadedDice();
            var guard = new PrisonGuard(players, banker, dice);
            board = boardFactory.Create(banker, players, dice, guard);
            go = new Go(banker);
        }

        [Test]
        public void PlayerShouldReceive200DollarsForLandingOnGo()
        {
            var beforeGoMoney = banker.accounts[player];

            board.MovePlayer(player, 40);

            Assert.That(banker.accounts[player], Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceive200DollarsForPassingGo()
        {     
            var beforeGoMoney = banker.accounts[player];

            board.MovePlayer(player, 50);
            var afterGoMoney = banker.accounts[player];
           
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceiver400ForPassingGoTwiceInASingleTurn()
        {
            banker.accounts[player] = 0;
           
            board.MovePlayer(player, 90);
            var afterGoMoney = banker.accounts[player];
            
            Assert.That(afterGoMoney, Is.EqualTo(400));
        }
    }
}
