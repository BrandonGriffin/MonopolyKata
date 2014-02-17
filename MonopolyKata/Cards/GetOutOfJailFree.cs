using MonopolyKata.CoreComponents;

namespace MonopolyKata.Cards
{
    public class GetOutOfJailFree : ICard
    {
        private PrisonGuard guard;

        public GetOutOfJailFree(PrisonGuard guard)
        {
            this.guard = guard;
        }

        public void Play(Player player)
        {
            guard.GiveGetOutOfJailFreeCard(player);
        }
    }
}
