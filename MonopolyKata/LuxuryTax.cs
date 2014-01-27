namespace MonopolyKata
{
    public class LuxuryTax : IBoardSpace
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

        public void PassOverSpace(Player player)
        { }
    }
}
