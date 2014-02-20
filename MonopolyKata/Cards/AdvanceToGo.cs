using System;

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

        public void Play(String player)
        {
            board.MoveTo(player, goIndex);
        }
    }
}
