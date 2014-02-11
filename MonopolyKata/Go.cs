namespace MonopolyKata
{
    public class Go : IBoardSpace
    {
        private Banker banker;

        public Go(Banker banker)
        {
            this.banker = banker;
        }

        public void SpaceAction(Player player)
        {
            banker.Credit(player, 200);
        }
    }
}
