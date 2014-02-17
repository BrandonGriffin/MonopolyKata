using System;
using System.Collections.Generic;
using MonopolyKata.CoreComponents;
using MonopolyKata.RentStrategies;

namespace MonopolyKata.Cards
{
    public class MoveToNearestRailroad : ICard
    {
        private Board board;
        private IEnumerable<Int32> indices;
        private RailroadRentStrategy rentStrategy;

        public MoveToNearestRailroad(Board board, IEnumerable<Int32> indices, RailroadRentStrategy rentStrategy)
        {
            this.board = board;
            this.indices = indices;
            this.rentStrategy = rentStrategy;
        }

        public void Play(Player player)
        {
            rentStrategy.SetOneTimeRentBonus();
            board.MoveToNearest(player, indices);
        }
    }
}
