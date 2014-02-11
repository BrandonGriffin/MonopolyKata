using System;

namespace MonopolyKata
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

        public void SpaceAction(Player player)
        {
            board.SetPosition(player, jailIndex);
            guard.Incarcerate(player);
        }
    }
}
