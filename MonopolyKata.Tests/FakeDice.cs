using System;
using System.Collections.Generic;

namespace MonopolyKata.Tests
{
    public class FakeDice : IDice
    {
        public Int32 Value { get; private set; }
        private Int32 Die1;
        private Int32 Die2;
        private Stack<Int32> rolls;

        public void SetNumberToRoll(Stack<Int32> rolls)
        {
            this.rolls = rolls;
        }

        public void Roll()
        {
            Die1 = rolls.Pop();
            Die2 = rolls.Pop();
            Value = Die1 + Die2;
        }

        public Boolean RollWasDoubles()
        {
            return Die1 == Die2;
        }
    }
}
