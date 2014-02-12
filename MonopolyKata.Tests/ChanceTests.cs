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
        private Player player2;
        private List<Player> players;
        private Banker banker;
        private LoadedDice dice;
        private PrisonGuard guard;
        private BoardFactory boardFactory;
        private Board board;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            banker = new Banker(players);
            dice = new LoadedDice();
            guard = new PrisonGuard(players, banker, dice);
            boardFactory = new BoardFactory();
            board = boardFactory.Create(banker, players, dice, guard);
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
        public void GoToReadingRailroadShouldPayThePlayer200()
        {
            board.SetPosition(player1, 5);
            board.SetPosition(player1, 36);
            var rideTheReading = new MoveableCard("Ride the Reading Railroad", board, banker, 5);
            var previousBalance = banker.GetBalance(player1);

            rideTheReading.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance + 200));
        }

        [Test]
        public void GoBack3SpacesMovesThePlayerBackwards3Spaces()
        {
            board.SetPosition(player1, 28);
            var goBack3Spaces = new GoBack3Spaces(board);

            goBack3Spaces.Play(player1);

            Assert.That(board.GetPosition(player1), Is.EqualTo(25));
        }

        [Test]
        public void GoBack3SpacesShouldNotPayThePlayer200Dollars()
        {
            board.SetPosition(player1, 13);
            var goBack3Spaces = new GoBack3Spaces(board);
            var previousBalance = banker.GetBalance(player1);

            goBack3Spaces.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.LessThanOrEqualTo(previousBalance));
        }

        [Test]
        public void ChairmanOfTheBoardMakesThePlayerPayEachOtherPlayer50Dollars()
        {
            var player3 = new Player("Dog");
            players.Add(player3);
            banker = new Banker(players);
            var chairmanOfTheBoard = new PayEachPlayer(banker);
            var previousBalance = banker.GetBalance(player1);

            chairmanOfTheBoard.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 100));
        }

        [Test]
        public void MoveToTheNextRailroadDoublesRent()
        {
            banker = new Banker(players);
            board = boardFactory.Create(banker, players, dice, guard);
            var moveToNearestRailroad = new MoveToNearestRailroad(board, banker);
            board.SetPosition(player2, 15);
            board.SetPosition(player1, 7);
            var previousBalance = banker.GetBalance(player1);
           
            moveToNearestRailroad.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 50));
        }

        [Test]
        public void MoveToNearestUtilityForcesPlayerToPay10TimesRollAmount()
        {
            banker = new Banker(players);
            board = boardFactory.Create(banker, players, dice, guard);
            var moveToNearestUtility = new MoveToNearestUtility(board, dice, banker);
            board.SetPosition(player2, 12);
            board.SetPosition(player1, 7);
            var previousBalance = banker.GetBalance(player1);
            dice.SetNumberToRoll(new[] { 4, 1 });
            dice.Roll();

            moveToNearestUtility.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 50));
        }

        [Test]
        public void GoToJailSendsThePlayerDirectlyToJail()
        {
            var goToJail = new GoToJailCard(board);

            goToJail.Play(player1);

            Assert.That(board.GetPosition(player1), Is.EqualTo(10));
        }

        [Test]
        public void GoToJailDoesNotPassGo()
        {
            board.SetPosition(player1, 36);
            var goToJail = new GoToJailCard(board);
            var previousBalance = banker.GetBalance(player1);

            goToJail.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance));
        }

        [Test]
        public void AdvanceToGoGivesThePlayer200Dollars()
        {
            board.SetPosition(player1, 7);
            var advanceToGo = new AdvanceToGo(board);
            var previousBalance = banker.GetBalance(player1);

            advanceToGo.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance + 200));
        }

        [Test]
        public void APlayerThatGetsTheGetOutOfJailFreeCardDoesntStayInJail()
        {
            var getOutOfJailFree = new GetOutOfJailFree(guard);
            var turns = new PlayerTurnCounter(players);
            dice.SetNumberToRoll(new[] { 2, 4, 1, 2, 15, 15, 4, 1 });
            var game = new Game(players, dice, board, banker, turns, guard);

            

            getOutOfJailFree.Play(player1);
            game.TakeTurn(player1);

            Assert.That(board.GetPosition(player1), Is.EqualTo(15));
        }
    }
}
