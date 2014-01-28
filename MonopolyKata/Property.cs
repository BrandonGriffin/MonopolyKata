using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Property : IBoardSpace
    {
        public String Title { get; set; }
        public Int32 Price { get; private set; }
        public String Group { get; private set; }
        public String Owner { get; private set; }
        
        private Teller teller;

        public Property (String title, Int32 price, String group, Teller teller)
        {
            this.Title = title;
            this.Price = price;
            this.Group = group;
            this.teller = teller;
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