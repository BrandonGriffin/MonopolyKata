using System;
using MonopolyKata.CoreComponents;

namespace MonopolyKata.Spaces
{
    public abstract class BuyableSpace : IBoardSpace
    {
        public Player Owner { get; protected set; }

        protected String title;
        protected Int32 price;
        protected Banker banker;

        public BuyableSpace(String title, Banker banker, Int32 price)
        {
            this.title = title;
            this.banker = banker;
            this.price = price;
        }

        public void LandOnSpace(Player player)
        {
            if (IsUnowned())
                Purchase(player);
            else if (IsNotOwnedBy(player))
                PayRent(player);
        }

        private Boolean IsUnowned()
        {
            return Owner == null;
        }

        private void Purchase(Player player)
        {            
            banker.Debit(player, price);
            Owner = player;
        }

        private Boolean IsNotOwnedBy(Player player)
        {
            return Owner != player;
        }

        protected abstract void PayRent(Player player);
    }
}
