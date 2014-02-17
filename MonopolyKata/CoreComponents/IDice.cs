using System;

namespace MonopolyKata.CoreComponents
{
    public interface IDice
    {
        Int32 Value { get; }
        Boolean isDoubles { get; }
        void Roll();
    }
}
