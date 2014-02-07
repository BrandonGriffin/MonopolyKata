namespace MonopolyKata
{
    public class Go : IBoardSpace
    {
        private Banker teller;

        public Go(Banker teller)
        {
            this.teller = teller;
        }

        public void SpaceAction(Player player)
        {
            teller.Credit(player, 200);
        }
    }
}
