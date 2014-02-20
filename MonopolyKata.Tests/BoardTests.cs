using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private String player1;
        private List<String> players;
        private LoadedDice dice;
        private Banker banker;
        private Board board;

        [SetUp]
        public void SetUp()
        {
            dice = new LoadedDice();
            player1 = "Horse";
            players = new List<String> { player1 };
            banker = new Banker(players, 1500);
            var boardFactory = new BoardFactory();
            var guard = new PrisonGuard(banker, dice);
            board = boardFactory.Create(banker, players, dice, guard);
        }
    
        [Test]
        public void PlayerCanRollDiceToMove()
        {
            board.Move(player1, 6);
            Assert.That(board.GetPosition(player1), Is.EqualTo(6));
        }

        [Test]
        public void PlayersPositionCantBeHigherThan39()
        {
            board.Move(player1, 39);
            board.Move(player1, 3);

            Assert.That(board.GetPosition(player1), Is.EqualTo(2));
        }
    }
}