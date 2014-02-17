using System;
using MonopolyKata.CoreComponents;

namespace MonopolyKata.Cards
{
    public class GoBackSpaces : ICard
    {
        private Board board;
        private Int32 amount;

        public GoBackSpaces(Board board, Int32 amount)
        {
            this.board = board;
            this.amount = amount;
        }
        
        public void Play(Player player)
        {
            board.Move(player, -amount);
        }
    }
}
