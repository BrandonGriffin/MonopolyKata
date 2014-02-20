using System;
using System.Collections.Generic;
using MonopolyKata.Spaces;
using NUnit.Framework;

namespace MonopolyKata.Tests.SpacesTests
{
    [TestFixture]
    public class GoToJailTests
    {
        [Test]
        public void IfAPlayerLandsOnGoToJailTheyGoToJail()
        {
            var jail = 10;
            var player = "Horse";
            var players = new List<String> { player };
            var banker = new Banker(players, 1500);
            var boardFactory = new BoardFactory();
            var dice = new LoadedDice();
            var guard = new PrisonGuard(banker, dice);
            var board = boardFactory.Create(banker, players, dice, guard);
            var goToJail = new GoToJail(board, jail, guard);

            goToJail.LandOnSpace(player);

            Assert.That(board.GetPosition(player), Is.EqualTo(10));
        }
    }
}
