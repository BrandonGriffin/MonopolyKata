using System;

namespace MonopolyKata.Cards
{
    public class Advance : ICard
    {
        private Board board;
        private Banker banker;
        private Int32 spaceIndex;

        public Advance(Board board, Banker banker, Int32 spaceIndex)
        {
            this.board = board;
            this.banker = banker;
            this.spaceIndex = spaceIndex;
        }

        public void Play(String player)
        {
            var previousPositionIndex = board.GetPosition(player);
            board.MoveTo(player, spaceIndex);

            if (PlayerPassesGo(previousPositionIndex))
                banker.Credit(player, 200);
        }

        private Boolean PlayerPassesGo(Int32 previousPositionIndex)
        {
            return spaceIndex < previousPositionIndex;
        }
    }
}