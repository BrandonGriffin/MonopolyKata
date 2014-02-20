using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata.RentStrategies
{
    public class UtilityRentStrategy : RentStrategy
    {
        private IDice dice;

        public UtilityRentStrategy(IEnumerable<RealEstate> utilities, IDice dice) : base(utilities)
        {
            this.dice = dice;
        }

        public override Int32 CalculateRent(String owner, Int32 rent)
        {
            rent = dice.Value * 4;

            if (AllUtilitiesAreOwned() || rentIsIncreased)
                rent = dice.Value * 10;

            rentIsIncreased = false;

            return rent;
        }

        private Boolean AllUtilitiesAreOwned()
        {
            return properties.All(x => x.Owner != null);
        }
    }
}
