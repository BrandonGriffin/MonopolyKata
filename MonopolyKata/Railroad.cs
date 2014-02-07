using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Railroad : BuyableSpace
    {
        private IEnumerable<Railroad> railroads;

        public Railroad(String title, Banker teller, IEnumerable<Railroad> railroads) : 
            base(title, teller, 200)
        {
            this.railroads = railroads;
        }

        protected override void PayTheOwnerRent(Player player)
        {
            var tempRent = 25;
            var count = railroads.Count(x => x.Owner == Owner);
            tempRent *= (Int32)Math.Pow(2, count - 1);

            teller.Debit(player, tempRent);
            teller.Credit(Owner, tempRent);
        }
    }
}