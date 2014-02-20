using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public class RailroadRentStrategy : IRentStrategy
    {
        private IEnumerable<RealEstate> railroads;
        private Boolean rentIsIncreased;

        public RailroadRentStrategy(IEnumerable<RealEstate> railroads)
        {
            this.railroads = railroads;
        }

        public Int32 CalculateRent(String owner, Int32 rent)
        {
            var numberOfRailroadsWithSameOwner = railroads.Count(x => x.Owner == owner);
            rent =  rent * (Int32)Math.Pow(2, numberOfRailroadsWithSameOwner - 1);

            if (rentIsIncreased)
                rent *= 2;

            rentIsIncreased = false;

            return rent;
        }
        
        public void IncreaseRentOnce()
        {
            rentIsIncreased = true;
        }
    }
}
