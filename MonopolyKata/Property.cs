using System;

namespace MonopolyKata
{
    public class Property : IBoardSpace
    {
        public String Title { get; set; }
        public Player Owner { get; set; }
        public Int32 Rent { get; private set; }
        public Int32 Price { get; private set; }
        public String Group { get; private set; }
        
        
        private Teller teller;

        public Property (String title, Int32 price, Int32 rent, String group, Teller teller)
        {
            this.Title = title;
            this.Price = price;
            this.Rent = rent;
            this.Group = group;
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
            teller.bank[player] -= Price;
        }
        
        private Boolean PropertyIsOwnedBySomeoneElse(Player player)
        {
            return Owner != player;
        }

        private void PlayerPaysTheOwnerRent(Player player)
        {
            teller.bank[player] -= Rent;
            teller.bank[Owner] += Rent;
        }
        
        public void PassOverSpace(Player player)
        { }
    }
}