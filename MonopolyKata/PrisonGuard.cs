using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class PrisonGuard
    {
        private Dictionary<String, Int32> turnsInJailPerString;
        private IEnumerable<String> players;
        private List<String> holdsGetOutOfJailFree;
        private Banker banker;
        private IDice dice;

        public PrisonGuard(IEnumerable<String> players, Banker banker, IDice dice)
        {
            turnsInJailPerString = new Dictionary<String, Int32>();
            holdsGetOutOfJailFree = new List<String>();
            this.players = players;
            this.banker = banker;
            this.dice = dice;
        }

        public Boolean IsIncarcerated(String player)
        {
            if (dice.isDoubles)
                turnsInJailPerString.Remove(player);

            return turnsInJailPerString.ContainsKey(player);
        }

        public void Incarcerate(String player)
        {
            turnsInJailPerString.Add(player, 1);

            if (holdsGetOutOfJailFree.Contains(player))
                holdsGetOutOfJailFree.Remove(player);
        }

        public void Bribe(String player)
        {
            banker.Debit(player, 50);
            turnsInJailPerString.Remove(player);
        }

        public void ServeTurn(String player)
        {
            turnsInJailPerString[player]++;
            if (turnsInJailPerString[player] == 3)
                Bribe(player);
        }

        public void GiveGetOutOfJailFreeCard(String player)
        {
            holdsGetOutOfJailFree.Add(player);
        }
    }
}