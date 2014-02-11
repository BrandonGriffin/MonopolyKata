using System.Collections.Generic;

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
            var rideTheReading = new MoveableCard("Ride the Reading Railroad", board, banker, 5);
            var moveToNearestRailroad = new RailroadCard(board);
            var goBack3Spaces = new GoBack3Spaces(board);
            var chairmanOfTheboard = new PayEachPlayer(banker);
            var moveToIllinois = new MoveableCard("Move to Illinois Avenue", board, banker, 24);
            var moveToStCharles = new MoveableCard("Move to St. Charles Place", board, banker, 11);
            var goToJail = new GoToJailCard(board);

            //nearest utility rent = 10x roll
            //get out of jail free
            //advance to go

            var cards = new Queue<ICard>();
            cards.Enqueue(bankDividend);
            cards.Enqueue(maturedLoan);
            cards.Enqueue(poorTax);
            cards.Enqueue(moveToNearestRailroad);
            cards.Enqueue(moveToBoardwalk);
            cards.Enqueue(chairmanOfTheboard);
            cards.Enqueue(moveToNearestRailroad);
            cards.Enqueue(rideTheReading);
            cards.Enqueue(moveToIllinois);
            cards.Enqueue(moveToStCharles);
            cards.Enqueue(goToJail);
           
            return cards;
        }
    }
}
