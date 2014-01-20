using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Player
    {
        public Int32 Position { get; set; }
        private Random random;

        public Player(Random random)
        {
            this.random = random;
        }

        public Int32 Roll()
        {
            var rollOne = random.Next(6) + 1;
            var rollTwo = random.Next(6) + 1;

            UpdatePosition(rollOne + rollTwo);

            return rollOne + rollTwo;        
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
