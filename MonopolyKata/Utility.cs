using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Utility : BuyableSpace
    {
        private UtilityRentStrategy rent;

        public Utility(String title, Banker banker, IDice dice, IEnumerable<Utility> utilities) : 
            base(title, banker, 150)
        {
            rent = new UtilityRentStrategy(utilities, dice, banker);
        }

        protected override void PayRent(Player player)
        {
            rent.PayRentFromUtility(this, player);
        }
    }
}
