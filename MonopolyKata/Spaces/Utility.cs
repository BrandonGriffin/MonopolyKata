using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.CoreComponents;
using MonopolyKata.RentStrategies;

namespace MonopolyKata.Spaces
{
    public class Utility : BuyableSpace
    {
        private UtilityRentStrategy rentStrategy;

        public Utility(String title, Banker banker, UtilityRentStrategy rentStrategy) : 
            base(title, banker, 150)
        {
            this.rentStrategy = rentStrategy;
        }

        protected override void PayRent(Player player)
        {
            var rent = rentStrategy.CalculateRent(this, player);

            banker.Debit(player, rent);
            banker.Credit(Owner, rent);
        }
    }
}
