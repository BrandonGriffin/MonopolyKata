using System;

namespace MonopolyKata.Tests
{
    public class FakeDice : IDice
    {
        private Int32 numberToRoll;

        public void SetNumberToRoll(Int32 number)
        {
            numberToRoll = number;
        }

        public Int32 Roll()
        {
            return numberToRoll;
        }
    }
}
