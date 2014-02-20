using System;

namespace MonopolyKata.Spaces
{
    public class LuxuryTax : IBoardSpace
    {
        private Banker banker;
        private Int32 amount;

        public LuxuryTax(Banker banker, Int32 amount)
        {
            this.banker = banker;
            this.amount = amount;
        }

        public void LandOnSpace(String player)
        {
            banker.Debit(player, amount);
        }
    }
}
