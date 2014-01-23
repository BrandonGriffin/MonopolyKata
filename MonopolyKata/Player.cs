using System;

namespace MonopolyKata
{
    public class Player
    {
        public Int32 Position { get; private set; }
        public String Name { get; private set; }
        public Int32 TurnsTaken { get; private set; }
        public Double Money { get; set; }
        private Banker banker;

        private IDice dice;

        public Player(IDice dice, String name, Banker banker)
        {
            this.dice = dice;
            this.Name = name;
            this.banker = banker;
        }
        
        public void RollDice()
        {
            var totalRoll = dice.Roll();
            TurnsTaken++;

            UpdatePlayerBasedOnRoll(totalRoll);       
        }

        private void UpdatePlayerBasedOnRoll(Int32 totalRoll)
        {
            if (PlayerPassesGo(totalRoll))
                GiveMoneyForPassingGo(totalRoll);

            SetPosition(totalRoll);

            if (PlayerIsOnIncomeTax())
                TakeIncomeTax();
            else if (PlayerIsOnLuxuryTax())
                TakeLuxuryTax();
        }

        private Boolean PlayerPassesGo(Int32 totalRoll)
        {
            return Position + totalRoll > 39;
        }

        private Boolean PlayerLandsOnGoToJail(Int32 totalRoll)
        {
            return (Position + totalRoll) % 40 == 30;
        }
        
        private Boolean PlayerIsOnIncomeTax()
        {
            return Position == 4;
        }
    
        
       
        private Boolean PlayerIsOnLuxuryTax()
        {
            return Position == 38;
        }
        
        private void GiveMoneyForPassingGo(Int32 roll)
        {
            var timesPassingGo = (Double)(Position + roll) / 40;
            var amountToAdd = (Double)200 * Math.Floor(timesPassingGo);

            banker.CreditAccount(this, amountToAdd);
        }
        
        private void SetPosition(Int32 totalRoll)
        {
            if (PlayerLandsOnGoToJail(totalRoll))
                Position = 10;
            else
                Position = (Position + totalRoll) % 40;
        }
        
        private void TakeIncomeTax()
        {
            if (Money >= 2000)
                banker.DebitAccount(this, 200);
            else
                Take10PercentOfPlayersMoney();
        }
        
        private void TakeLuxuryTax()
        {
            banker.DebitAccount(this, 75);
        }
        
        private void Take10PercentOfPlayersMoney()
        {
            var amountToSubtract = Money * .1;
            banker.DebitAccount(this, amountToSubtract);
        }
    }
}
