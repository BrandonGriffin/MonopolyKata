using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public class PropertyRentStrategy : IRentStrategy
    {
        private IEnumerable<RealEstate> properties;
        private Boolean rentIsIncreased;

        public PropertyRentStrategy(IEnumerable<RealEstate> properties)
        {
            this.properties = properties;
        }

        public Int32 CalculateRent(String owner, Int32 rent)
        {
            if (OwnerHasAMonopoly(owner))
                IncreaseRentOnce();

            if (rentIsIncreased)
                rent *= 2;

            rentIsIncreased = false;

            return rent;
        }

        public void IncreaseRentOnce()
        {
            rentIsIncreased = true;
        }

        private Boolean OwnerHasAMonopoly(String owner)
        {
            return properties.All(x => x.Owner == owner);
        }
    }
}
