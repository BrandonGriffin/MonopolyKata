using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Dice
    {
        private Random random;

        public Dice(Random random)
        {
            this.random = random;
        }

        public Int32 Roll()
        {
            var rollOne = RollDie();
            var rollTwo = RollDie();
            var totalRoll = rollOne + rollTwo;

            return totalRoll;
        }
        
        private Int32 RollDie()
        {
            return random.Next(6) + 1;
        }
    }
}
