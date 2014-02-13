using System.Collections.Generic;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class CommunityChestTests
    {
        private Player player1;
        private List<Player> players;
        private Banker banker;

        [SetUp]
        public void SetUp()
        {
            player1 = new Player("Horse");
            players = new List<Player> { player1 };
            banker = new Banker(players, 1500);
        }

        [Test]
        public void XMasFundCardCreditsAPlayer100Dollars()
        {
            var christmasFund = new PayableCard("XMas Fund", banker, 100);
            var previousBalance = banker.GetBalance(player1);
            christmasFund.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance + 100));
        }

        [Test]
        public void DoctorsFeeChargesThePlayer50Dollars()
        {
            var doctorsFee = new ChargableCard("Doctor's Fee", banker, 50);
            var previousBalance = banker.GetBalance(player1);
            doctorsFee.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 50));
        }

        [Test]
        public void GrandOperaLetsThePlayerCollect50DollarsFromEachPlayer()
        {
            var player2 = new Player("Car");
            var player3 = new Player("Dog");
            players.AddRange(new[] { player2, player3 });
            banker = new Banker(players, 1500);
            var grandOpera = new CollectFromEachPlayer(banker);
            var previousBalance = banker.GetBalance(player1);

            grandOpera.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance + 100));
        }
    }
}
