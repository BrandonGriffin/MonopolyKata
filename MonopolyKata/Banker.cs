using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Banker
    {
        public void CreditAccount(Player player, Double amount)
        {
            player.Money += amount;
        }

        public void DebitAccount(Player player, Double amount)
        {
            player.Money -= amount;
        }
    }
}
