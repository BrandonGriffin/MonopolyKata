using System;
using System.Collections.Generic;

namespace MonopolyKata.CoreComponents
{
    public class PrisonGuard
    {
        private Dictionary<Player, Int32> turnsInJailPerPlayer;
        private IEnumerable<Player> players;
        private List<Player> holdsGetOutOfJailFree;
        private Banker banker;
        private IDice dice;

        public PrisonGuard(IEnumerable<Player> players, Banker banker, IDice dice)
        {
            turnsInJailPerPlayer = new Dictionary<Player, Int32>();
            holdsGetOutOfJailFree = new List<Player>();
            this.players = players;
            this.banker = banker;
            this.dice = dice;
        }

        public Boolean IsIncarcerated(Player player)
        {
            if (dice.isDoubles)
                turnsInJailPerPlayer.Remove(player);

            return turnsInJailPerPlayer.ContainsKey(player);
        }

        public void Incarcerate(Player player)
        {
            turnsInJailPerPlayer.Add(player, 1);

            if (holdsGetOutOfJailFree.Contains(player))
                holdsGetOutOfJailFree.Remove(player);
        }

        public void Bribe(Player player)
        {
            banker.Debit(player, 50);
            turnsInJailPerPlayer.Remove(player);
        }

        public void ServeTurn(Player player)
        {
            turnsInJailPerPlayer[player]++;
            if (turnsInJailPerPlayer[player] == 3)
                Bribe(player);
        }

        public void GiveGetOutOfJailFreeCard(Player player)
        {
            holdsGetOutOfJailFree.Add(player);
        }
    }
}