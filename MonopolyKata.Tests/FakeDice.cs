using System;

namespace MonopolyKata.Tests
{
    public class FakeDice : IDice
    {
        public Int32 Value { get; private set; }
        private Int32 numberToRoll;

        public void SetNumberToRoll(Int32 number)
        {
            numberToRoll = number;
        }

        public void Roll()
        {
            Value = numberToRoll;
        }
    }
}
