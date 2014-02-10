using System.Collections.Generic;

namespace MonopolyKata
{
    public class Chance : IBoardSpace
    {
        private Queue<ICard> cards;
        
        public void SetCards(Queue<ICard> cards)
        {
            this.cards = cards;
        }

        public void SpaceAction(Player player)
        {
            var card = cards.Dequeue();
            card.Play(player);
            cards.Enqueue(card);
        }
    }
}
