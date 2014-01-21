using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Player
    {
        public Int32 Position { get; private set; }
        public String Name { get; private set; }
        private Random random;

        public Player(Random random, String name)
        {
            this.random = random;
            this.Name = name;
        }

        public void RollDice()
        {
            var dice = new Dice(random);
            var totalRoll = dice.Roll();
            UpdatePosition(totalRoll);       
        }

        private void UpdatePosition(Int32 totalRoll)
        {
            if (PlayerDoesNotPassGo(totalRoll))
                Position += totalRoll;
            else
                SetPositionBeyondGo(totalRoll);
        }

        private Boolean PlayerDoesNotPassGo(Int32 totalRoll)
        {
            return Position + totalRoll < 40;
        }

        private void SetPositionBeyondGo(Int32 totalRoll)
        {
            Position = totalRoll - (39 - Position - 1);
        }
    }
}
