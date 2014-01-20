using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Board
    {
        public IEnumerable<Int32> CreateBoard()
        {
            return new List<Int32>(40);
        }
    }
}
