namespace MonopolyKata
{
    public class GoBack3Spaces : ICard
    {
        private Board board;

        public GoBack3Spaces(Board board)
        {
            this.board = board;
        }
        
        public void Play(Player player)
        {
            board.SetPosition(player, board.GetPosition(player) - 3);
        }
    }
}
