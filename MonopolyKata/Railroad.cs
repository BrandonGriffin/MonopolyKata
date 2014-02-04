using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Railroad : IBoardSpace
    {
        public Player Owner { get; private set; }
        private Teller teller;
        private String title;
        private IEnumerable<Railroad> railroads;

        public Railroad(String title, Teller teller, IEnumerable<Railroad> railroads)
        {
            this.title = title;
            this.teller = teller;
            this.railroads = railroads;
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
            teller.Debit(player, 200);
        }

        private Boolean PropertyIsOwnedBySomeoneElse(Player player)
        {
            return Owner != player;
        }

        private void PlayerPaysTheOwnerRent(Player player)
        {
            var tempRent = 25;
            var count = railroads.Count(x => x.Owner == Owner);
            tempRent *= (Int32)Math.Pow(2, count - 1);

            teller.Debit(player, tempRent);
            teller.Credit(Owner, tempRent);
        }

        public void PassOverSpace(Player player)
        { }
    }
}