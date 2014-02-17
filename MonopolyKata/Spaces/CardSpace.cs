using System.Collections.Generic;
using MonopolyKata.Cards;
using MonopolyKata.CoreComponents;

namespace MonopolyKata.Spaces
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