using System;

namespace MonopolyKata
{
    public abstract class BuyableSpace : IBoardSpace
    {
        protected String Title;
        public Player Owner { get; protected set; }
        protected Teller teller;

        public BuyableSpace(String title, Teller teller)
        {
            this.Title = title;
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

        protected abstract void CurrentPlayerBuysTheProperty(Player player);

        private Boolean PropertyIsOwnedBySomeoneElse(Player player)
        {
            return Owner != player;
        }

        protected abstract void PlayerPaysTheOwnerRent(Player player);

        public void PassOverSpace(Player player)
        { }
    }
}
