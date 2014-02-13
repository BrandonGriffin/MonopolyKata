using System.Collections.Generic;

namespace MonopolyKata
{
    public class CardSpace : IBoardSpace
    {
        private Queue<ICard> cards;

        public CardSpace(Queue<ICard> cards)
        {
            this.cards = cards;
        }

        public void LandOnSpace(Player player)
        {
            var card = cards.Dequeue();
            card.Play(player);
            cards.Enqueue(card);
        }
    }
}