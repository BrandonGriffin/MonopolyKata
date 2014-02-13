using System;

namespace MonopolyKata
{
    public abstract class BuyableSpace : IBoardSpace
    {
        public Player Owner { get; protected set; }
        protected String Title;
        protected Int32 price;
        protected Banker banker;

        public BuyableSpace(String title, Banker banker, Int32 price)
        {
            this.Title = title;
            this.banker = banker;
            this.price = price;
        }

        public void LandOnSpace(Player player)
        {
            if (IsUnowned())
                Purchase(player);
            else if (IsOwnedBySomeoneElse(player))
                PayRent(player);
        }

        private Boolean IsUnowned()
        {
            return Owner == null;
        }

        private void Purchase(Player player)
        {
            Owner = player;
            banker.Debit(player, price);
        }

        private Boolean IsOwnedBySomeoneElse(Player player)
        {
            return Owner != player;
        }

        protected abstract void PayRent(Player player);
    }
}
