using System;
using System.Collections.Generic;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public abstract class RentStrategy
    {
        protected Boolean rentIsIncreased;
        protected IEnumerable<RealEstate> properties;

        public RentStrategy(IEnumerable<RealEstate> properties)
        {
            this.properties = properties;
        }

        public abstract Int32 CalculateRent(String Owner, Int32 rent);

        public void IncreaseRentOnce()
        {
            rentIsIncreased = true;
        }
    }
}
