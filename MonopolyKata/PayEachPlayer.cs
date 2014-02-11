using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class PayEachPlayer : ICard
    {
        private Banker banker;

        public PayEachPlayer(Banker banker)
        {
            this.banker = banker;
        }

        public void Play(Player player)
        {
            banker.PayEachPlayer(player, 50);
        }
    }
}
