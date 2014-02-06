using System;

namespace MonopolyKata
{
    public class GoToJail : IBoardSpace
    {
        private Int32 jail;
        private PositionKeeper positionKeeper;
        private PrisonGuard guard;

        public GoToJail(PositionKeeper positionKeeper, Int32 jail, PrisonGuard guard)
        {
            this.positionKeeper = positionKeeper;
            this.jail = jail;
            this.guard = guard;
        }

        public void LandOnSpace(Player player)
        {
            positionKeeper.SetPosition(player, jail);
            guard.Incarcerate(player);
        }

        public void PassOverSpace(Player player)
        { }
    }
}
