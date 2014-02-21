using System;

namespace MonopolyKata
{
    public class Dice : IDice
    {
        public Int32 Value { get; private set; }
        public Boolean IsDoubles { get; private set; }

        private Random random;

        public Dice(Random random)
        {
            this.random = random;
        }

        public void Roll()
        {
            var die1 = RollDie();
            var die2 = RollDie();
            Value = die1 + die2;
            IsDoubles = die1 == die2;
        }
        
        private Int32 RollDie()
        {
            return random.Next(6) + 1;
        }
    }
}
