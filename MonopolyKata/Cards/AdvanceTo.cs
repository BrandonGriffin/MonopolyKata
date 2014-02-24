using System;

namespace MonopolyKata.Cards
{
    public class AdvanceTo : ICard
    {
        private Board board;
        private Int32 index;

        public AdvanceTo(Board board, Int32 index)
        {
            this.board = board;
            this.index = index;
        }

        public void Play(String player)
        {
            board.MoveTo(player, index);
        }
    }
}
