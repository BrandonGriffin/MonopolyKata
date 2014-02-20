using System;

namespace MonopolyKata.Cards
{
    public class Pay : ICard
    {
        private Banker banker;
        private Int32 amount;

        public Pay(Banker banker, Int32 amount)
        {
            this.banker = banker;
            this.amount = amount;
        }

        public void Play(String player)
        {
            banker.Debit(player, amount);
        }
    }
}
