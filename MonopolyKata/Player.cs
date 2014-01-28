using System;

namespace MonopolyKata
{
    public class Player
    {    
        public String Name { get; private set; }

        public Player(String name)
        {
            this.Name = name;
        }
    }
}
