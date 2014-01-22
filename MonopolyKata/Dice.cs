using System;

namespace MonopolyKata
{
    public class Dice : IDice
    {
        private Random random;

        public Dice(Random random)
        {
            this.random = random;
        }

        public Int32 Roll()
        {
            return RollDie() + RollDie();
        }
        
        private Int32 RollDie()
        {
            return random.Next(6) + 1;
        }
    }
}
