using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class BalticAvenue : IProperty
    {
        public Int32 Price { get; private set; }
        public String Owner { get; private set; }

        private Teller teller;

        public BalticAvenue(Teller teller)
        {
            this.teller = teller;
            Price = 60;
        }

        public void LandOnSpace(Player player)
        {
            if (Owner == null)
            {
                Owner = player.Name;
                teller.bank[player] -= Price;
            }
        }

        public void PassOverSpace(Player player)
        { }
    }
}
