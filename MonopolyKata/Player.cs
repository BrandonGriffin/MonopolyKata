using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Player
    {    
        public String Name { get; private set; }
        public Int32 TurnsTaken { get; set; }

        public Player(String name)
        {
            this.Name = name;
        }
    }
}
