using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class PrisonGuard
    {
        private Dictionary<String, Int32> turnsInJailPerPlayer;
        private List<String> holdsGetOutOfJailFree;
        private Banker banker;
        private IDice dice;

        public PrisonGuard(Banker banker, IDice dice)
        {
            turnsInJailPerPlayer = new Dictionary<String, Int32>();
            holdsGetOutOfJailFree = new List<String>();
            this.banker = banker;
            this.dice = dice;
        }

        public Boolean IsIncarcerated(String player)
        {
            if (dice.isDoubles)
                turnsInJailPerPlayer.Remove(player);

            return turnsInJailPerPlayer.ContainsKey(player);
        }

        public void Incarcerate(String player)
        {
            turnsInJailPerPlayer.Add(player, 1);

            if (holdsGetOutOfJailFree.Contains(player))
                holdsGetOutOfJailFree.Remove(player);
        }

        public void Bribe(String player)
        {
            banker.Debit(player, 50);
            turnsInJailPerPlayer.Remove(player);
        }

        public void ServeTurn(String player)
        {
            turnsInJailPerPlayer[player]++;
            if (turnsInJailPerPlayer[player] == 3)
                Bribe(player);
        }

        public void GiveGetOutOfJailFreeCard(String player)
        {
            holdsGetOutOfJailFree.Add(player);
        }
    }
}