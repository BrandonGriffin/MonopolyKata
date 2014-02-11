namespace MonopolyKata
{
    public class CollectFromEachPlayer : ICard
    {
        private Banker banker;

        public CollectFromEachPlayer(Banker banker)
        {
            this.banker = banker;
        }

        public void Play(Player player)
        {
            banker.CollectFromEveryone(player, 50);
        }
    }
}
