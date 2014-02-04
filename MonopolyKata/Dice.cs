using System;

namespace MonopolyKata
{
    public class Dice : IDice
    {
        public Int32 Value { get; private set; }
        private Random random;

        public Dice(Random random)
        {
            this.random = random;
        }

        public void Roll()
        {
            Value = RollDie() + RollDie();
        }
        
        private Int32 RollDie()
        {
            return random.Next(6) + 1;
        }
    }
}
