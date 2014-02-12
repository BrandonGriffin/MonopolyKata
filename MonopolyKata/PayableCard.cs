using System;

namespace MonopolyKata
{
    public class PayableCard : ICard
    {
        private String description;
        private Banker banker;
        private Int32 amount;

        public PayableCard(String description, Banker banker, Int32 amount)
        {
            this.description = description;
            this.banker = banker;
            this.amount = amount;
        }

        public void Play(Player player)
        {
            banker.Credit(player, amount);
        }
    }
}
