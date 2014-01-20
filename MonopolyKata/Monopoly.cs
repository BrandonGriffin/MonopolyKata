using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Monopoly
    {
        public IEnumerable<Int32> Board()
        {
            return new List<Int32>(40);
        }
    }
}
