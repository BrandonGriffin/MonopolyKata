using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    class UtilityRentStrategy : IRentStrategy
    {
        private IEnumerable<Utility> utilities;
        private IDice dice;
        private Banker banker;

        public UtilityRentStrategy(IEnumerable<Utility> utilities, IDice dice, Banker banker)
        {
            this.utilities = utilities;
            this.dice = dice;
            this.banker = banker;
        }

        public void PayRentFromCard(Player owner, Player player)
        {
            banker.Debit(player, dice.Value * 10);
            banker.Credit(owner, dice.Value * 10);
        }

        public void PayRentFromUtility(BuyableSpace space, Player player)
        {
            var rent = dice.Value * 4;

            if (AllUtilitiesAreOwned())
                rent = dice.Value * 10;

            banker.Debit(player, rent);
            banker.Credit(space.Owner, rent);
        }
        
        private Boolean AllUtilitiesAreOwned()
        {
            return utilities.All(x => x.Owner != null);
        }
    }
}
