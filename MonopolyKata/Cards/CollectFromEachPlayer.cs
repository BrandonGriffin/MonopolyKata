using System;
using MonopolyKata.Cards;

namespace MonopolyKata.Cards
{
    public class CollectFromEachPlayer : ICard
    {
        private Banker banker;
        private Int32 amount;

        public CollectFromEachPlayer(Banker banker, Int32 amount)
        {
            this.banker = banker;
            this.amount = amount;
        }

        public void Play(String player)
        {
            banker.CollectFromEachPlayer(player, amount);
        }
    }
}
