namespace MonopolyKata
{
    public class PayEachPlayer : ICard
    {
        private Banker banker;

        public PayEachPlayer(Banker banker)
        {
            this.banker = banker;
        }

        public void Play(Player player)
        {
            banker.PayEachPlayer(player, 50);
        }
    }
}
