using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.CoreComponents;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public class RailroadRentStrategy
    {
        private IEnumerable<Railroad> railroads;
        private Boolean oneTimeRentBonus;

        public RailroadRentStrategy(IEnumerable<Railroad> railroads)
        {
            this.railroads = railroads;
        }

        public Int32 CalculateRent(BuyableSpace space, Player player)
        {
            var numberOfRailroadsWithSameOwner = railroads.Count(x => x.Owner == space.Owner);
            var rent = 25 * (Int32)Math.Pow(2, numberOfRailroadsWithSameOwner - 1);

            if (oneTimeRentBonus)
                rent *= 2;

            oneTimeRentBonus = false;

            return rent;
        }
        
        public void SetOneTimeRentBonus()
        {
            oneTimeRentBonus = true;
        }
    }
}
