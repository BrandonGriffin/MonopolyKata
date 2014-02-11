using System;

namespace MonopolyKata
{
    public class IncomeTax : IBoardSpace
    {
        private Banker banker;

        public IncomeTax(Banker banker)
        {
            this.banker = banker;
        }

        public void SpaceAction(Player player)
        {
            var amountToSubtract = Math.Min(200, TenPercentOfPlayersMoney(player));
            banker.Debit(player, amountToSubtract);
        }

        private Int32 TenPercentOfPlayersMoney(Player player)
        {
            return banker.accounts[player] / 10;
        }
    }
}
