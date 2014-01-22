using System;

namespace MonopolyKata
{
    public class Player
    {
        public Int32 Position { get; private set; }
        public String Name { get; private set; }
        public Int32 Money { get; private set; }
        public Int32 TurnsTaken { get; private set; }

        private IDice dice;

        public Player(IDice dice, String name)
        {
            this.dice = dice;
            this.Name = name;
        }
        
        public void RollDice()
        {
            var totalRoll = dice.Roll();
            TurnsTaken++;

            UpdatePosition(totalRoll);       
        }

        private void UpdatePosition(Int32 totalRoll)
        {
            if (PlayerPassesGo(totalRoll))
                Money += 200;
            Position = (Position + totalRoll) % 40;
        }

        private Boolean PlayerPassesGo(Int32 totalRoll)
        {
            return Position + totalRoll > 39;
        }
    }
}
