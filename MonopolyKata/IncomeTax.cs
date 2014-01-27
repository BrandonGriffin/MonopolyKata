using System;

namespace MonopolyKata
{
    public class IncomeTax : IBoardSpace
    {
        private Teller teller;

        public IncomeTax(Teller teller)
        {
            this.teller = teller;
        }

        public void LandOnSpace(Player player)
        {
            var amountToSubtract = Math.Min(200, TenPercentOfPlayersMoney(player));
            teller.Debit(player, amountToSubtract);
        }

        private Int32 TenPercentOfPlayersMoney(Player player)
        {
            return teller.bank[player] / 10;
        }

        public void PassOverSpace(Player player)
        { }
    }
}
