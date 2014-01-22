using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;
        private FakeDice dice;

        [SetUp]
        public void SetUp()
        {
            dice = new FakeDice();
            player = new Player(dice, "Horse");
        }

        [Test]
        public void PlayerCanRollDiceToMove()
        {
            dice.SetNumberToRoll(6);
            player.RollDice();
            var actual = player.Position;

            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void PlayersPositionCantBeHigherThan39()
        {
            dice.SetNumberToRoll(39);
            player.RollDice();

            dice.SetNumberToRoll(3);
            player.RollDice();

            var actual = player.Position;

            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void PlayerShouldReceive200DollarsForPassingGo()
        {
            dice.SetNumberToRoll(39);
            player.RollDice();

            var beforeGoMoney = player.Money;

            dice.SetNumberToRoll(2);
            player.RollDice();

            var afterGoMoney = player.Money;
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
        }
    }
}
