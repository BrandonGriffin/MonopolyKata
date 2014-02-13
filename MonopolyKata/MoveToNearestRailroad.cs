namespace MonopolyKata
{
    public class MoveToNearestRailroad : ICard
    {
        private Board board;
        private Banker banker;

        public MoveToNearestRailroad(Board board, Banker banker)
        {
            this.board = board;
            this.banker = banker;
        }

        public void Play(Player player)
        {
            MoveToNextRailroad(player);
        }

        private void MoveToNextRailroad(Player player)
        {
            var positionIndex = board.GetPosition(player);

            if (positionIndex == 7)
            {
                board.MoveTo(player, 15);
                board.MoveTo(player, 15);
            }
            else if (positionIndex == 22)
            {
                board.MoveTo(player, 25);
                board.MoveTo(player, 25);
            }
            else if (positionIndex == 36)
            {
                banker.Credit(player, 200);
                board.MoveTo(player, 5);
                board.MoveTo(player, 5);
            }
        }
    }
}
