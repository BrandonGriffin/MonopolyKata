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
            var banker = new Banker(players);
            var boardFactory = new BoardFactory();
            var dice = new LoadedDice();
            var guard = new PrisonGuard(players, banker, dice);
            var board = boardFactory.Create(banker, players, dice, guard);
            var goToJail = new GoToJail(board, jail, guard);

            goToJail.SpaceAction(player);

            Assert.That(board.GetPosition(player), Is.EqualTo(10));
        }
    }
}
