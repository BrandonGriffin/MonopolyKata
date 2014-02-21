using System;

namespace MonopolyKata
{
    public interface IDice
    {
        Int32 Value { get; }
        Boolean IsDoubles { get; }
        void Roll();
    }
}
