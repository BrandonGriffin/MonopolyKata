using System;
using System.Collections.Generic;
using MonopolyKata.Spaces;
using NUnit.Framework;

namespace MonopolyKata.Tests.SpacesTests
{
    [TestFixture]
    public class GoTests
    {
        private String player;
        private List<String> players;
        private Banker banker;
        private IDice dice;
        private Board board;
        private Go go;
    
        [SetUp]
        public void SetUp()
        {
            player = "Horse";
            players = new List<String> { player };
            banker = new Banker(players, 1500);
            var boardFactory = new BoardFactory();
            dice = new LoadedDice();
            var guard = new PrisonGuard(banker, dice);
            board = boardFactory.Create(banker, players, dice, guard);
            go = new Go(banker);
        }

        [Test]
        public void PlayerShouldReceive200DollarsForLandingOnGo()
        {
            var beforeGoMoney = banker.GetBalance(player);

            board.Move(player, 40);

            Assert.That(banker.GetBalance(player), Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceive200DollarsForPassingGo()
        {
            var beforeGoMoney = banker.GetBalance(player);

            board.Move(player, 50);
            var afterGoMoney = banker.GetBalance(player);
           
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
        }

        [Test]
        public void PlayerShouldReceiver400ForPassingGoTwiceInASingleTurn()
        {
            var beforeGoMoney = banker.GetBalance(player);
           
            board.Move(player, 90);
            var afterGoMoney = banker.GetBalance(player);
            
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 400));
        }
    }
}
