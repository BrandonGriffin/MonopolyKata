using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class CommunityChest : IBoardSpace
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
