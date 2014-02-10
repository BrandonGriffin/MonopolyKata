using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            board.SetPosition(player, spaceIndex);

            if (spaceIndex < previousPositionIndex)
                banker.Credit(player, 200);                
        }
    }
}
