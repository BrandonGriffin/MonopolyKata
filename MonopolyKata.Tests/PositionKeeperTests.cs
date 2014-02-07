using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PositionKeeperTests
    {
        private Player player1;
        private List<Player> players;
        private LoadedDice dice;
        private Banker teller;
        private Board positionKeeper;

        [SetUp]
        public void SetUp()
        {
            dice = new LoadedDice();
            player1 = new Player("Horse");
            players = new List<Player> { player1 };
            teller = new Banker(players);
            var positionKeeperFactory = new BoardFactory();
            var guard = new PrisonGuard(players, teller, dice);
            positionKeeper = positionKeeperFactory.Create(teller, players, dice, guard);
        }
    
        [Test]
        public void PlayerCanRollDiceToMove()
        {
            positionKeeper.MovePlayer(player1, 6);
            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(6));
        }

        [Test]
        public void PlayersPositionCantBeHigherThan39()
        {
            positionKeeper.MovePlayer(player1, 39);
            positionKeeper.MovePlayer(player1, 3);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(2));
        }
    }
}