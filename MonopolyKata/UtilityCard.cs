using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class UtilityCard : ICard
    {
        private Board board;
        private IDice dice;

        public UtilityCard(Board board, IDice dice)
        {
            this.board = board;
            this.dice = dice;
        }

        public void Play(Player player)
        {
            var positionIndex = board.GetPosition(player);

            if (positionIndex == 7 || positionIndex == 36)
                board.SetPosition(player, 12);
            else if (positionIndex == 22)
                board.SetPosition(player, 28);
        }
    }
}
