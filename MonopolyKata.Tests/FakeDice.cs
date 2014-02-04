using System;
using System.Collections.Generic;

namespace MonopolyKata.Tests
{
    public class FakeDice : IDice
    {
        public Int32 Value { get; private set; }
        private Int32 Die1;
        private Int32 Die2;
        private IEnumerator<Int32> rolls;

        public void SetNumberToRoll(IEnumerable<Int32> rolls)
        {
            this.rolls = rolls.GetEnumerator();
        }

        public void Roll()
        {
            Die1 = RollDie();
            Die2 = RollDie();
            Value = Die1 + Die2;
        }

        private Int32 RollDie()
        {
            rolls.MoveNext();
            return rolls.Current;
        }

        public Boolean RollWasDoubles()
        {
            return Die1 == Die2;
        }
    }
}
