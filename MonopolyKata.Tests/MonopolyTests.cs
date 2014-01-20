using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class MonopolyTests
    {
        [Test]
        public void GameReturnsAMonopolyBoardWith40Spaces()
        {
            var game = new Monopoly();
            var actual = game.Board();

            Assert.That(actual, Is.EqualTo(new List<Int32>(40)));
        }
    }
}
