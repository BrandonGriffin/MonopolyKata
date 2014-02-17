using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public interface IRentStrategy
    {
        void PayRentFromCard(Player owner, Player player);
        void PayRentFromUtility(BuyableSpace space, Player player);
    }
}
