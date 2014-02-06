using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Railroad : BuyableSpace
    {
        private String title;
        private IEnumerable<Railroad> railroads;

        public Railroad(String title, Teller teller, IEnumerable<Railroad> railroads) : 
            base(title, teller)
        {
            this.title = title;
            this.teller = teller;
            this.railroads = railroads;
        }

        protected override void CurrentPlayerBuysTheProperty(Player player)
        {
            Owner = player;
            teller.Debit(player, 200);
        }

        protected override void PlayerPaysTheOwnerRent(Player player)
        {
            var tempRent = 25;
            var count = railroads.Count(x => x.Owner == Owner);
            tempRent *= (Int32)Math.Pow(2, count - 1);

            teller.Debit(player, tempRent);
            teller.Credit(Owner, tempRent);
        }
    }
}