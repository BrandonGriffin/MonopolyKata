using System;
using MonopolyKata.CoreComponents;

namespace MonopolyKata.Cards
{
    public class AdvanceToGo : ICard
    {
        private Board board;
        private Int32 goIndex;

        public AdvanceToGo(Board board, Int32 goIndex)
        {
            this.board = board;
            this.goIndex = goIndex;
        }

        public void Play(Player player)
        {
            board.MoveTo(player, goIndex);
        }
    }
}
