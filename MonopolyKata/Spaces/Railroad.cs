using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.CoreComponents;
using MonopolyKata.RentStrategies;

namespace MonopolyKata.Spaces
{
    public class Railroad : BuyableSpace
    {
        private RailroadRentStrategy rentStrategy;

        public Railroad(String title, Banker banker, RailroadRentStrategy rentStrategy) : 
            base(title, banker, 200)
        {
            this.rentStrategy = rentStrategy;
        }

        protected override void PayRent(Player player)
        {
            var rent = rentStrategy.CalculateRent(this, player);
            banker.Transfer(rent, player, Owner);
        }
    }
}