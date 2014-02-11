using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class ChanceFactory
    {
        public Chance Create(Banker banker, Board board)
        {
            var cards = new Queue<ICard>();
            var chance = new Chance();

            cards = MakeCards(banker, board);
            chance.SetCards(cards);
            return chance;
        }

        private Queue<ICard> MakeCards(Banker banker, Board board)
        {
            var bankDividend = new PayableCard("Bank Dividend", banker, 50);
            var maturedLoan = new PayableCard("Loan Matures", banker, 150);

            var poorTax = new ChargableCard("Poor Tax", banker, 15);

            var moveToBoardwalk = new MoveableCard("Take a Walk on the Boardwalk", board, banker, 39);
            //give 50 to every player
            //go to jail
            //get out of jail free
            //advance to go

            var cards = new Queue<ICard>();
            cards.Enqueue(bankDividend);
            cards.Enqueue(maturedLoan);
            cards.Enqueue(poorTax);
            cards.Enqueue(moveToBoardwalk);
           
            return cards;
        }
    }
}
