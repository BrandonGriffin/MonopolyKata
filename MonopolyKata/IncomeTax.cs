using System;

namespace MonopolyKata
{
    public class IncomeTax : IBoardSpace
    {
        private Banker teller;

        public IncomeTax(Banker teller)
        {
            this.teller = teller;
        }

        public void SpaceAction(Player player)
        {
            var amountToSubtract = Math.Min(200, TenPercentOfPlayersMoney(player));
            teller.Debit(player, amountToSubtract);
        }

        private Int32 TenPercentOfPlayersMoney(Player player)
        {
            return teller.accounts[player] / 10;
        }
    }
}
