using System;

namespace MonopolyKata
{
    public class Dice : IDice
    {
        public Int32 Value { get; private set; }
        private Int32 Die1;
        private Int32 Die2;
        private Random random;

        public Dice(Random random)
        {
            this.random = random;
        }

        public void Roll()
        {
            Die1 = RollDie();
            Die2 = RollDie();
            Value = Die1 + Die2;
        }
        
        private Int32 RollDie()
        {
            return random.Next(6) + 1;
        }

        public Boolean RollWasDoubles()
        {
            return Die1 == Die2;
        }
    }
}
