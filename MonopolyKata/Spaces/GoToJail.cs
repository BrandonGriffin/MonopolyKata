using System;
using MonopolyKata.CoreComponents;

namespace MonopolyKata.Spaces
{
    public class GoToJail : IBoardSpace
    {
        private Int32 jailIndex;
        private Board board;
        private PrisonGuard guard;

        public GoToJail(Board board, Int32 jailIndex, PrisonGuard guard)
        {
            this.board = board;
            this.jailIndex = jailIndex;
            this.guard = guard;
        }

        public void LandOnSpace(Player player)
        {
            board.MoveTo(player, jailIndex);
            guard.Incarcerate(player);
        }
    }
}
