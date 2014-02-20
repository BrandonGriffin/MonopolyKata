using System;

namespace MonopolyKata.Cards
{
    public class GoToJailCard : ICard
    {
        private Board board;
        private Int32 jailIndex;

        public GoToJailCard(Board board, Int32 jailIndex)
        {
            this.board = board;
            this.jailIndex = jailIndex;
        }

        public void Play(String player)
        {
            board.MoveTo(player, jailIndex);
        }
    }
}
