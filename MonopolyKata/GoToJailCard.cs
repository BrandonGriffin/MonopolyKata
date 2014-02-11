using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class GoToJailCard : ICard
    {
        private Board board;

        public GoToJailCard(Board board)
        {
            this.board = board;
        }

        public void Play(Player player)
        {
            board.SetPosition(player, 30);
        }
    }
}
