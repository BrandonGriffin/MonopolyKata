using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Utility : IBoardSpace
    {
        public Player Owner { get; private set; }
        private Teller teller;
        private String title;
        private IEnumerable<Utility> utilities;

        public Utility(String title, Teller teller, IEnumerable<Utility> utilities)
        {
            this.title = title;
            this.teller = teller;
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
            var tempRent = GetRoll() * 4;

            teller.bank[player] -= tempRent;
            teller.bank[Owner] += tempRent;
        }

        public void PassOverSpace(Player player)
        { }
    }
}
