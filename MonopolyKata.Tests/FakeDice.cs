using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Tests
{
    public class FakeDice : IDice
    {
        private Int32 numberToRoll;

        public FakeDice()
        { }

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
