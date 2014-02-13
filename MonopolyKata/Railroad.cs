using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Railroad : BuyableSpace
    {
        private IEnumerable<Railroad> railroads;

        public Railroad(String title, Banker banker, IEnumerable<Railroad> railroads) : 
            base(title, banker, 200)
        {
            this.railroads = railroads;
        }

        protected override void PayRent(Player player)
        {
            var numberOfRailroadsWithSameOwner = railroads.Count(x => x.Owner == Owner);
            var rent = 25 * (Int32)Math.Pow(2, numberOfRailroadsWithSameOwner - 1);

            banker.Debit(player, rent);
            banker.Credit(Owner, rent);
        }
    }
}