using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public interface IProperty : IBoardSpace
    {
        Int32 Price { get; }
        String Owner { get; }
    }
}
