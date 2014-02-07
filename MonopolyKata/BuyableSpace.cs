using System;

namespace MonopolyKata
{
    public abstract class BuyableSpace : IBoardSpace
    {
        public Player Owner { get; protected set; }
        protected String Title;
        protected Int32 price;
        protected Banker teller;

        public BuyableSpace(String title, Banker teller, Int32 price)
        {
            this.Title = title;
            this.teller = teller;
            this.price = price;
        }

        public void SpaceAction(Player player)
        {
            if (IsUnowned())
                Purchase(player);
            else if (IsOwnedBySomeoneElse(player))
                PayTheOwnerRent(player);
        }

        private Boolean IsUnowned()
        {
            return Owner == null;
        }

        private void Purchase(Player player)
        {
            Owner = player;
            teller.Debit(player, price);
        }

        private Boolean IsOwnedBySomeoneElse(Player player)
        {
            return Owner != player;
        }

        protected abstract void PayTheOwnerRent(Player player);
    }
}
