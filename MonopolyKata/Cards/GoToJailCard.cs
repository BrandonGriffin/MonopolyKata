using MonopolyKata.CoreComponents;

namespace MonopolyKata.Cards
{
    public class GoToJailCard : ICard
    {
        private Board board;

        public GoToJailCard(Board board)
        {
            this.board = board;
        }

        public void Play(Player player)
        {
            board.MoveTo(player, 30);
        }
    }
}
