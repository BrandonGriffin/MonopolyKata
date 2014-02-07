using System;

namespace MonopolyKata
{
    public class GoToJail : IBoardSpace
    {
        private Int32 jailIndex;
        private Board positionKeeper;
        private PrisonGuard guard;

        public GoToJail(Board positionKeeper, Int32 jailIndex, PrisonGuard guard)
        {
            this.positionKeeper = positionKeeper;
            this.jailIndex = jailIndex;
            this.guard = guard;
        }

        public void SpaceAction(Player player)
        {
            positionKeeper.SetPosition(player, jailIndex);
            guard.Incarcerate(player);
        }
    }
}
