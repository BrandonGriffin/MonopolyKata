using System;

namespace MonopolyKata.Cards
{
    public class GetOutOfJailFree : ICard
    {
        private PrisonGuard guard;

        public GetOutOfJailFree(PrisonGuard guard)
        {
            this.guard = guard;
        }

        public void Play(String player)
        {
            guard.GiveGetOutOfJailFreeCard(player);
        }
    }
}
