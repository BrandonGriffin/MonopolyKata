using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public class PropertyRentStrategy : RentStrategy
    {
        public PropertyRentStrategy(IEnumerable<RealEstate> properties) : base(properties)
        { }

        public override Int32 CalculateRent(String owner, Int32 rent)
        {
            if (OwnerHasAMonopoly(owner))
                IncreaseRentOnce();

            if (rentIsIncreased)
                rent *= 2;

            rentIsIncreased = false;

            return rent;
        }

        private Boolean OwnerHasAMonopoly(String owner)
        {
            return properties.All(x => x.Owner == owner);
        }
    }
}
