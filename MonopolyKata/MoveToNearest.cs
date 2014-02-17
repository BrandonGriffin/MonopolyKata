using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class MoveToNearest : ICard
    {
        private Board board;
        private IEnumerable<Int32> indices;

        public MoveToNearest(Board board, IEnumerable<Int32> indices)
        {
            this.board = board;
            this.indices = indices;
        }

        public void Play(Player player)
        {
            board.MoveToNearest(player, indices);
        }
    }
}
