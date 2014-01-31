using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Teller
    {
        public Dictionary<Player, Int32> bank;

        public Teller(List<Player> players)
        {
            bank = new Dictionary<Player, Int32>();

            foreach (var player in players)
                bank.Add(player, 1500);
        }
        
        public void Credit(Player player, Int32 amount)
        {
            bank[player] += amount;
        }

        public void Debit(Player player, Int32 amount)
        {
            bank[player] -= amount;
        }

        public Int32 GetBalance(Player player)
        {
            return bank[player];
        }
    }
}
