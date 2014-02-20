using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public class UtilityRentStrategy : IRentStrategy
    {
        private IEnumerable<RealEstate> utilities;
        private IDice dice;
        private Boolean rentIsIncreased;

        public UtilityRentStrategy(IEnumerable<RealEstate> utilities, IDice dice)
        {
            this.utilities = utilities;
            this.dice = dice;
        }

        public Int32 CalculateRent(String owner, Int32 rent)
        {
            rent = dice.Value * 4;

            if (AllUtilitiesAreOwned() || rentIsIncreased)
                rent = dice.Value * 10;

            rentIsIncreased = false;

            return rent;
        }
        
        public void IncreaseRentOnce()
        {
            rentIsIncreased = true;
        }

        private Boolean AllUtilitiesAreOwned()
        {
            return utilities.All(x => x.Owner != null);
        }
    }
}
