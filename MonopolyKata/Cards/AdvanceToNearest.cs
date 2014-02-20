using System;
using System.Collections.Generic;
using MonopolyKata.RentStrategies;

namespace MonopolyKata.Cards
{
    public class AdvanceToNearest: ICard
    {
        private Board board;
        private IEnumerable<Int32> indices;
        private RentStrategy rentStrategy;

        public AdvanceToNearest(Board board, IEnumerable<Int32> indices, RentStrategy rentStrategy)
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
