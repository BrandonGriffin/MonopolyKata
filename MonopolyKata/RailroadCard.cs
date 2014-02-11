using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class RailroadCard : ICard
    {
        private Board board;

        public RailroadCard(Board board)
        {
            this.board = board;
        }

        public void Play(Player player)
        {
            MoveToNextRailroad(player);
        }

        private void MoveToNextRailroad(Player player)
        {
            var positionIndex = board.GetPosition(player);

            if (positionIndex == 7)
            {
                board.SetPosition(player, 15);
                board.SetPosition(player, 15);
            }
            else if (positionIndex == 22)
            {
                board.SetPosition(player, 25);
                board.SetPosition(player, 25);
            }
            else if (positionIndex == 36)
            {
                board.SetPosition(player, 5);
                board.SetPosition(player, 5);
            }
        }
    }
}
