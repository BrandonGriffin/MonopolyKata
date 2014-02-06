﻿using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PositionKeeperTests
    {
        private Player player1;
        private List<Player> players;
        private FakeDice dice;
        private Teller teller;
        private PositionKeeper positionKeeper;

        [SetUp]
        public void SetUp()
        {
            dice = new FakeDice();
            player1 = new Player("Horse");
            players = new List<Player> { player1 };
            teller = new Teller(players);
            var positionKeeperFactory = new PositionKeeperFactory();
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