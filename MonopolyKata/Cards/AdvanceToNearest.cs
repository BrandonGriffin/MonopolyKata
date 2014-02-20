using System;
using System.Collections.Generic;
using MonopolyKata.RentStrategies;

namespace MonopolyKata.Cards
{
    public class MoveToNearest: ICard
    {
        private Board board;
        private IEnumerable<Int32> indices;
        private IRentStrategy rentStrategy;

        public MoveToNearest(Board board, IEnumerable<Int32> indices, IRentStrategy rentStrategy)
        {
            this.board = board;
            this.indices = indices;
            this.rentStrategy = rentStrategy;
        }

        public void Play(String player)
        {
            rentStrategy.IncreaseRentOnce();
            board.MoveToNearest(player, indices);
        }
    }
}
