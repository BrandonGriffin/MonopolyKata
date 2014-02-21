using System;
using System.Collections.Generic;

namespace MonopolyKata.Tests
{
    public class LoadedDice : IDice
    {
        public Int32 Value { get; private set; }
        public Boolean IsDoubles { get; private set; }

        private IEnumerator<Int32> rolls;

        public void SetNumberToRoll(IEnumerable<Int32> rolls)
        {
            this.rolls = rolls.GetEnumerator();
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
            rolls.MoveNext();
            return rolls.Current;
        }
    }
}
