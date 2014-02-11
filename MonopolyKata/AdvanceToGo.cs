namespace MonopolyKata
{
    public class AdvanceToGo : ICard
    {
        private Board board;

        public AdvanceToGo(Board board)
        {
            this.board = board;
        }

        public void Play(Player player)
        {
            board.SetPosition(player, 0);
        }
    }
}
