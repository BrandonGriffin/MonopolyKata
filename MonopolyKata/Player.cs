using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Player
    {    
        public String Name { get; private set; }
        public Int32 TurnsTaken { get; set; }
        public Int32 PreviousPosition { get; set; }
        public Int32 Position { get; set; }
        public Double Money { get; set; }
        public List<Int32> Rolls = new List<Int32>();

        public Player(String name)
        {
            this.Name = name;
        }
    }
}
