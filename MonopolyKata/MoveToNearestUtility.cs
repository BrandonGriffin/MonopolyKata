namespace MonopolyKata
{
    public class MoveToNearestUtility : ICard
    {
        private Board board;
        private IDice dice;
        private Banker banker;

        public MoveToNearestUtility(Board board, IDice dice, Banker banker)
        {
            this.board = board;
            this.dice = dice;
            this.banker = banker;
        }

        public void Play(Player player)
        {
            var positionIndex = board.GetPosition(player);

            if (positionIndex == 7)
            { 
                board.SetPosition(player, 12); 
            }
            else if (positionIndex == 22)
            {
                board.SetPosition(player, 28);
            }
            else
            {
                banker.Credit(player, 200);
                board.SetPosition(player, 12);
            }
        }
    }
}
