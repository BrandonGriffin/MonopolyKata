using System;
namespace MonopolyKata
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

        public void LandOnSpace(Player player)
        {
            banker.Debit(player, amount);
        }
    }
}
