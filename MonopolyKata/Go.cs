namespace MonopolyKata
{
    public class Go : IBoardSpace
    {
        private Teller teller;

        public Go(Teller teller)
        {
            this.teller = teller;
        }

        public void LandOnSpace(Player player)
        {
            teller.Credit(player, 200);
        }
    }
}
