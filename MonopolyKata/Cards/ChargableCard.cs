using System;
using MonopolyKata.CoreComponents;

namespace MonopolyKata.Cards
{
    public class ChargableCard : ICard
    {
        private String description;
        private Banker banker;
        private Int32 amount;

        public ChargableCard(String description, Banker banker, Int32 amount)
        {
            this.description = description;
            this.banker = banker;
            this.amount = amount;
        }

        public void Play(Player player)
        {
            banker.Debit(player, amount);
        }
    }
}
