namespace MonopolyKata
{
    public class LuxuryTax : IBoardSpace
    {
        private Banker banker;

        public LuxuryTax(Banker banker)
        {
            this.banker = banker;
        }

        public void SpaceAction(Player player)
        {
            banker.Debit(player, 75);
        }
    }
}
