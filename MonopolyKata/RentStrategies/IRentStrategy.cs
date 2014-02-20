using System;

namespace MonopolyKata.RentStrategies
{
    public interface IRentStrategy
    {
        Int32 CalculateRent(String Owner, Int32 rent);
        void IncreaseRentOnce();
    }
}
