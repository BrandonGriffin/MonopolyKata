using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Property : BuyableSpace
    { 
        public Int32 Rent { get; private set; }
        public Int32 Price { get; private set; }
        private IEnumerable<Property> properties { get; set; }

        public Property (String title, Int32 price, Int32 rent, Teller teller, IEnumerable<Property> properties) :
            base(title, teller)
        {
            this.Price = price;
            this.Rent = rent;
            this.properties = properties;
        }

        public void LandOnSpace(Player player)
        {
            base.LandOnSpace(player);
        }

        protected override void CurrentPlayerBuysTheProperty(Player player)
        {
            Owner = player;
            teller.Debit(player, Price);
        }

        protected override void PlayerPaysTheOwnerRent(Player player)
        {
            var tempRent = Rent;

            if (OwnerHasAMonopoly())
                tempRent *= 2;

            teller.Debit(player, tempRent);
            teller.Credit(Owner, tempRent);
        }

        private Boolean OwnerHasAMonopoly()
        {
            return properties.All(x => x.Owner == Owner);
        }
        
        public void PassOverSpace(Player player)
        { }
    }
}