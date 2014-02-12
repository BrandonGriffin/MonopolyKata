using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Utility : BuyableSpace
    {
        private IDice dice;
        private IEnumerable<Utility> utilities;

        public Utility(String title, Banker banker, IDice dice, IEnumerable<Utility> utilities) : 
            base(title, banker, 150)
        {
            this.dice = dice;
            this.utilities = utilities;
        }

        protected override void PayRent(Player player)
        {
            var rent = dice.Value * 4;

            if (AllUtilitiesAreOwned())
                rent = dice.Value * 10;

            banker.Debit(player, rent);
            banker.Credit(Owner, rent);
        }

        private Boolean AllUtilitiesAreOwned()
        {
            return utilities.All(x => x.Owner != null);
        }
    }
}
