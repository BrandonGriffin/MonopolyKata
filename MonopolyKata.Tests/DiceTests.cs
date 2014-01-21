using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MonopolyKata.Tests
{
    [TestFixture]
    public class DiceTests
    {
        private Random random;
        private Dice dice;

        [SetUp]
        public void SetUp()
        {
            random = new Random();
            dice = new Dice(random);
        }

        [Test]
        public void DiceRollsShouldBeSeeminglyRandom()
        {
            var rolls = new List<Int32>();
            var countOfPossibleRolls = new Dictionary<Int32, Int32>
                                           {
                                               {2, 0},
                                               {3, 0},
                                               {4, 0},
                                               {5, 0},
                                               {6, 0},
                                               {7, 0},
                                               {8, 0},
                                               {9, 0},
                                               {10, 0},
                                               {11, 0},
                                               {12, 0}
                                           };
            for (var i = 0; i < 150; i++)
            {
                var totalRoll = dice.Roll();
                rolls.Add(totalRoll);

                countOfPossibleRolls[totalRoll]++;
            }

            Assert.That(!countOfPossibleRolls.ContainsValue(0));
        }

        [Test]
        public void MultiplePlayersRollsAreSeeminglyRandom()
        {
            var rollsAreDifferent = false;

            for (var i = 0; i < 5; i++)
                if (dice.Roll() != dice.Roll())
                    rollsAreDifferent = true;

            Assert.That(rollsAreDifferent);
        }
    }
}
