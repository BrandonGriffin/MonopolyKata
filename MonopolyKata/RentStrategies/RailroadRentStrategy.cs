using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public class RailroadRentStrategy : RentStrategy
    {
        public RailroadRentStrategy(IEnumerable<RealEstate> railroads) : base(railroads)
        { }

        public override Int32 CalculateRent(String owner, Int32 rent)
        {
            var numberOfRailroadsWithSameOwner = properties.Count(x => x.Owner == owner);
            rent = rent * (Int32)Math.Pow(2, numberOfRailroadsWithSameOwner - 1);

            if (rentIsIncreased)
                rent *= 2;

            rentIsIncreased = false;

            return rent;
        }
    }
}
