namespace MonopolyKata
{
    public class LuxuryTax : IBoardSpace
    {
        private Banker teller;

        public LuxuryTax(Banker teller)
        {
            this.teller = teller;
        }

        public void SpaceAction(Player player)
        {
            teller.Debit(player, 75);
        }
    }
}
