using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Property : BuyableSpace
    { 
        public Int32 BaseRent { get; private set; }
        private IEnumerable<Property> properties { get; set; }

        public Property(String title, Int32 price, Int32 baseRent, Banker banker, IEnumerable<Property> properties) :
            base(title, banker, price)
        {
            this.BaseRent = baseRent;
            this.properties = properties;
        }

        protected override void PayTheOwnerRent(Player player)
        {
            var rent = BaseRent;

            if (OwnerHasAMonopoly())
                rent *= 2;

            banker.Debit(player, rent);
            banker.Credit(Owner, rent);
        }

        private Boolean OwnerHasAMonopoly()
        {
            return properties.All(x => x.Owner == Owner);
        }
    }
}