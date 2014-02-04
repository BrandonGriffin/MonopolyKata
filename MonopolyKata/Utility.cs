using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Utility : IBoardSpace
    {
        public Player Owner { get; private set; }
        private Teller teller;
        private String title;
        private IDice dice;
        private IEnumerable<Utility> utilities;

        public Utility(String title, Teller teller, IDice dice, IEnumerable<Utility> utilities)
        {
            this.title = title;
            this.teller = teller;
            this.dice = dice;
            this.utilities = utilities;
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
            teller.Debit(player, 150);
        }

        private Boolean PropertyIsOwnedBySomeoneElse(Player player)
        {
            return Owner != player;
        }

        private void PlayerPaysTheOwnerRent(Player player)
        {
            var tempRent = dice.Value * 4;

            if (AllUtilitiesAreOwned(player))
                tempRent = dice.Value * 10;

            teller.Debit(player, tempRent);
            teller.Credit(Owner, tempRent);
        }

        private Boolean AllUtilitiesAreOwned(Player player)
        {
            return utilities.All(x => x.Owner != null && x.Owner != player);
        }

        public void PassOverSpace(Player player)
        { }
    }
}
