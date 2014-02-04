using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Utility : BuyableSpace
    {
        private IDice dice;
        private IEnumerable<Utility> utilities;

        public Utility(String title, Teller teller, IDice dice, IEnumerable<Utility> utilities) : 
            base(title, teller)
        {
            this.teller = teller;
            this.dice = dice;
            this.utilities = utilities;
        }

        protected override void CurrentPlayerBuysTheProperty(Player player)
        {
            Owner = player;
            teller.Debit(player, 150);
        }

        protected override void PlayerPaysTheOwnerRent(Player player)
        {
            var tempRent = dice.Value * 4;

            if (AllUtilitiesAreOwned(player))
                tempRent = dice.Value * 10;

            teller.Debit(player, tempRent);
            teller.Credit(Owner, tempRent);
        }

        private Boolean AllUtilitiesAreOwned(Player player)
        {
            return utilities.All(x => x.Owner != null);
        }

        public void PassOverSpace(Player player)
        { }
    }
}
