using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.CoreComponents;

namespace MonopolyKata.Spaces
{
    public class Property : BuyableSpace
    {
        private Int32 BaseRent;
        private IEnumerable<Property> properties;

        public Property(String title, Int32 price, Int32 baseRent, Banker banker, IEnumerable<Property> properties) :
            base(title, banker, price)
        {
            this.BaseRent = baseRent;
            this.properties = properties;
        }

        protected override void PayRent(Player player)
        {
            var rent = BaseRent;

            if (OwnerHasAMonopoly())
                rent *= 2;

            banker.Transfer(rent, player, Owner);
        }

        private Boolean OwnerHasAMonopoly()
        {
            return properties.All(x => x.Owner == Owner);
        }
    }
}