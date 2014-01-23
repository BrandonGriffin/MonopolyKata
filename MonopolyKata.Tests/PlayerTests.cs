using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player player;
        private FakeDice dice;
        private Banker banker;

        [SetUp]
        public void SetUp()
        {
            dice = new FakeDice();
            banker = new Banker();
            player = new Player(dice, "Horse", banker);
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
        public void PlayerShouldReceive200DollarsForLandingOnGo()
        {
            dice.SetNumberToRoll(38);
            player.RollDice();

            var beforeGoMoney = player.Money;

            dice.SetNumberToRoll(2);
            player.RollDice();

            var afterGoMoney = player.Money;
            Assert.That(afterGoMoney, Is.EqualTo(beforeGoMoney + 200));
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

        [Test]
        public void PlayerShouldReceiver400ForPassingGoTwiceInASingleTurn()
        {
            dice.SetNumberToRoll(82);
            player.RollDice();

            Assert.That(player.Money, Is.EqualTo(400));
        }

        [Test]
        public void IfAPlayerLandsOnSpace30TheyGoToSpace10()
        {
            dice.SetNumberToRoll(30);
            player.RollDice();

            Assert.That(player.Position, Is.EqualTo(10));
        }

        [Test]
        public void IncomeTaxChargesAPlayer10PercentOfTheirCurrentMoney()
        {
            player.Money = 200;            
            dice.SetNumberToRoll(4);
            player.RollDice();

            var afterTaxMoney = player.Money;

            Assert.That(afterTaxMoney, Is.EqualTo(180));
        }

        [Test]
        public void IncomeTaxTakes200DollarsIfAPlayerHasOver2000()
        {
            player.Money = 2500;
            dice.SetNumberToRoll(4);
            player.RollDice();

            var afterTaxMoney = player.Money;
            Assert.That(afterTaxMoney, Is.EqualTo(2300));
        }

        [Test]
        public void IncomeTaxTakesNothingIfAPlayerHasNoMoney()
        {
            dice.SetNumberToRoll(4);
            player.RollDice();

            Assert.That(player.Money, Is.EqualTo(0));
        }

        [Test]
        public void LuxuryTaxtTakes75DollarsFromPlayer()
        {
            player.Money = 200;
            dice.SetNumberToRoll(38);
            player.RollDice();

            Assert.That(player.Money, Is.EqualTo(125));
        }
    }
}
