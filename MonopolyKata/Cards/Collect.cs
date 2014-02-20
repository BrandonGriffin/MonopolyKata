using System;

namespace MonopolyKata.Cards
{
    public class Collect : ICard
    {
        private Banker banker;
        private Int32 amount;

        public Collect(Banker banker, Int32 amount)
        {
            this.banker = banker;
            this.amount = amount;
        }

        public void Play(String player)
        {
            banker.Credit(player, amount);
        }
    }
}
