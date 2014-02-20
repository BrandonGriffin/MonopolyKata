using System;
using System.Collections.Generic;
using MonopolyKata.Cards;
using NUnit.Framework;

namespace MonopolyKata.Tests.CardTests
{
    [TestFixture]
    public class CommunityChestTests
    {
        private String player1;
        private List<String> players;
        private Banker banker;

        [SetUp]
        public void SetUp()
        {
            player1 = "Horse";
            players = new List<String> { player1 };
            banker = new Banker(players, 1500);
        }

        [Test]
        public void XMasFundCardCreditsAPlayer100Dollars()
        {
            var christmasFund = new Collect(banker, 100);
            var previousBalance = banker.GetBalance(player1);
            christmasFund.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance + 100));
        }

        [Test]
        public void DoctorsFeeChargesThePlayer50Dollars()
        {
            var doctorsFee = new Pay(banker, 50);
            var previousBalance = banker.GetBalance(player1);
            doctorsFee.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance - 50));
        }

        [Test]
        public void GrandOperaLetsThePlayerCollect50DollarsFromEachPlayer()
        {
            var player2 = "Car";
            var player3 = "Dog";
            players.AddRange(new[] { player2, player3 });
            banker = new Banker(players, 1500);
            var grandOpera = new CollectFromEachString(banker, 50);
            var previousBalance = banker.GetBalance(player1);

            grandOpera.Play(player1);

            Assert.That(banker.GetBalance(player1), Is.EqualTo(previousBalance + 100));
        }
    }
}
