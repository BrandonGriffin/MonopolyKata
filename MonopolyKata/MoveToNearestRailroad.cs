using System;
using System.Collections;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class MoveToNearestRailroad : ICard
    {
        private Board board;
        private IEnumerable<Int32> indices;

        public MoveToNearestRailroad(Board board, IEnumerable<Int32> indices)
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
