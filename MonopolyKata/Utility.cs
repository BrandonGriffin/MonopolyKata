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

        protected override void PayTheOwnerRent(Player player)
        {
            var tempRent = dice.Value * 4;

            if (AllUtilitiesAreOwned(player))
                tempRent = dice.Value * 10;

            banker.Debit(player, tempRent);
            banker.Credit(Owner, tempRent);
        }

        private Boolean AllUtilitiesAreOwned(Player player)
        {
            return utilities.All(x => x.Owner != null);
        }
    }
}
