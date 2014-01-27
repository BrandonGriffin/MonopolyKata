namespace MonopolyKata
{
    public class LuxuryTax : BoardSpace
    {
        private Teller teller;

        public LuxuryTax(Teller teller)
        {
            this.teller = teller;
        }

        public void LandOnSpace(Player player)
        {
            teller.Debit(player, 75);
        }
    }
}
