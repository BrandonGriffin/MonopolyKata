namespace MonopolyKata
{
    public class LuxuryTax : IBoardSpace
    {
        private Banker banker;

        public LuxuryTax(Banker banker)
        {
            this.banker = banker;
        }

        public void LandOnSpace(Player player)
        {
            banker.Debit(player, 75);
        }
    }
}
