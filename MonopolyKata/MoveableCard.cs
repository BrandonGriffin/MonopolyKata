using System;

namespace MonopolyKata
{
    public class MoveableCard : ICard
    {
        private String description;
        private Board board;
        private Int32 spaceIndex;
        private Banker banker;

        public MoveableCard(String description, Board board, Banker banker, Int32 spaceIndex)
        {
            this.description = description;
            this.board = board;
            this.banker = banker;
            this.spaceIndex = spaceIndex;
        }

        public void Play(Player player)
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
