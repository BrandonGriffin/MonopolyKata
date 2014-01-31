using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Property : IBoardSpace
    {
        public String Title { get; private set; }
        public Player Owner { get; private set; }
        public Int32 Rent { get; private set; }
        public Int32 Price { get; private set; }

        private IEnumerable<Property> properties { get; set; }
        private Teller teller;

        public Property (String title, Int32 price, Int32 rent, Teller teller, IEnumerable<Property> properties)
        {
            this.Title = title;
            this.Price = price;
            this.Rent = rent;
            this.properties = properties;
            this.teller = teller;
        }

        public void LandOnSpace(Player player)
        {
            if (PropertyIsUnowned())
                CurrentPlayerBuysTheProperty(player);
            else if (PropertyIsOwnedBySomeoneElse(player))
                PlayerPaysTheOwnerRent(player);
        }

        private Boolean PropertyIsUnowned()
        {
            return Owner == null;
        }        

        private void CurrentPlayerBuysTheProperty(Player player)
        {
            Owner = player;
            teller.Debit(player, Price);
        }
        
        private Boolean PropertyIsOwnedBySomeoneElse(Player player)
        {
            return Owner != player;
        }

        private void PlayerPaysTheOwnerRent(Player player)
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