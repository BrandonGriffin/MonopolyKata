using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class MoveToNearestUtility : ICard
    {
        private Board board;
        private IEnumerable<Int32> indices;

        public MoveToNearestUtility(Board board, IEnumerable<Int32> indices)
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
