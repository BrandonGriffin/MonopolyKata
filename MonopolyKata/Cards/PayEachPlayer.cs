using System;

namespace MonopolyKata.Cards
{
    public class PayEachString : ICard
    {
        private Banker banker;
        private Int32 amount;

        public PayEachString(Banker banker, Int32 amount)
        {
            this.banker = banker;
            this.amount = amount;
        }

        public void Play(String player)
        {
            banker.PayEachPlayer(player, amount);
        }
    }
}
