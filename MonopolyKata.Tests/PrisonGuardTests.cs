using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PrisonGuardTests
    {
        private Player player1;
        private Player player2;
        private List<Player> players;
        private FakeDice dice;
        private Teller teller;
        private PrisonGuard guard;
        private PositionKeeper positionKeeper;
        private PlayerTurnCounter turns;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            dice = new FakeDice();
            player1 = new Player("Horse");
            player2 = new Player("Car");
            players = new List<Player> { player1, player2 };
            teller = new Teller(players);
            var positionKeeperFactory = new PositionKeeperFactory();
            guard = new PrisonGuard(players, teller, dice);
            positionKeeper = positionKeeperFactory.Create(teller, players, dice, guard);
            turns = new PlayerTurnCounter(players);
        }

        [Test]
        public void PlayersInJailDontMoveWhenTheyRoll()
        {
            positionKeeper.MovePlayer(player1, 30);
            var rolls = new[] { 2, 4, 6, 2, 3, 2 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);
            
            game.TakeTurn(player1);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(10));
        }

        [Test]
        public void APlayerCanPay50DollarsAtTheStartOfATurnToGetOutOfJail()
        {
            positionKeeper.MovePlayer(player1, 30);
            guard.Bribe(player1);
            var rolls = new[] { 2, 4, 6, 2, 3, 2 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);

            game.TakeTurn(player1);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(15));
        }

        [Test]
        public void APlayerGetsOutOfJailForRollingDoubles()
        {
            positionKeeper.MovePlayer(player1, 30);
            var rolls = new[] { 2, 4, 6, 2, 3, 3};
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);

            game.TakeTurn(player1);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(16));
        }

        [Test]
        public void APlayerDoesNotgetAnExtraTurnForDoublesWhileInJail()
        {
            positionKeeper.MovePlayer(player1, 30);
            var rolls = new[] { 2, 4, 6, 2, 3, 3, 4, 2, 5 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);

            game.TakeTurn(player1);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(16));
        }

        [Test]
        public void APlayerGetsOutOfJailAfter3Turns()
        {
            positionKeeper.MovePlayer(player1, 30);
            var rolls = new[] { 2, 4, 6, 2, 3, 2, 4, 2, 5, 2, 4, 5 };
            dice.SetNumberToRoll(rolls);
            game = new Game(players, dice, positionKeeper, teller, turns, guard);

            game.TakeTurn(player1);
            game.TakeTurn(player1);
            game.TakeTurn(player1);

            Assert.That(positionKeeper.GetPosition(player1), Is.EqualTo(17));
        }
    }
}
