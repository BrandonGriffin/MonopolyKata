using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class PrisonGuard
    {
        private Dictionary<Player, Int32> turnsInJailPerPlayer;
        private Banker teller;
        private IDice dice;

        public PrisonGuard(List<Player> players, Banker teller, IDice dice)
        {
            turnsInJailPerPlayer = new Dictionary<Player, Int32>();
            this.teller = teller;
            this.dice = dice;

            foreach (var player in players)
                turnsInJailPerPlayer.Add(player, 0);
        }

        public Boolean IsIncarcerated(Player player)
        {
            if (dice.RollWasDoubles())
            {
                turnsInJailPerPlayer[player] = 0;
                return false;
            }

            return turnsInJailPerPlayer[player] > 0;
        }

        public void Incarcerate(Player player)
        {
            turnsInJailPerPlayer[player] = 1;
        }

        public void Bribe(Player player)
        {
            turnsInJailPerPlayer[player] = 0;
            teller.Debit(player, 50);
        }

        public void ServeTurn(Player player)
        {
            turnsInJailPerPlayer[player]++;
            if (turnsInJailPerPlayer[player] >= 3)
                Bribe(player);
        }
    }
}