using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class ChanceTests
    {
        private Player player1;
        private List<Player> players;
        private Banker banker;
        private LoadedDice dice;
        private PrisonGuard guard;
        private Board board;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            players = new List<Player> { player1 };
            banker = new Banker(players);
            dice = new LoadedDice();
            guard = new PrisonGuard(players, banker, dice);
            board = new Board(players, guard);
        }

        [Test]
        public void BankDividendPaysPlayer50Bucks()
        {
            var bankDividend = new PayableCard("Bank Dividend", banker, 50);
            var previousBalance = banker.GetBalance(player1);
            bankDividend.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance + 50));
        }

        [Test]
        public void TakeAWalkOnTheBoardwalkMovesPlayerToBoardwalk()
        {
            var moveToBoardwalk = new MoveableCard("Take a Walk on the boardwalk", board, banker, 39);
            moveToBoardwalk.Play(player1);

            Assert.That(board.GetPosition(player1), Is.EqualTo(39));
        }

        [Test]
        public void ChairmanOfTheBoardMakesThePlayerPayEachOtherPlayer50Dollars()
        {
            var player2 = new Player("Car");
            var player3 = new Player("Dog");
            players.AddRange(new[] { player2, player3 });
            banker = new Banker(players);
            var chairmanOfTheBoard = new PayEachPlayer(banker);
            var previousBalance = banker.GetBalance(player1);

            chairmanOfTheBoard.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 100));
        }
    }
}
