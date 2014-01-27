using System;

namespace MonopolyKata
{
    public class GoToJail : IBoardSpace
    {
        private Int32 jail;
        private PositionKeeper positionKeeper;

        public GoToJail(PositionKeeper positionKeeper, Int32 jail)
        {
            this.positionKeeper = positionKeeper;
            this.jail = jail;
        }

        public void LandOnSpace(Player player)
        {
            positionKeeper.SetPosition(player, jail);
        }

        public void PassOverSpace(Player player)
        { }
    }
}
