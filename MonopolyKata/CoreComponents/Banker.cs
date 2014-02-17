using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata.CoreComponents
{
    public class Banker
    {
        private Dictionary<Player, Int32> accounts;
        
        public Banker(IEnumerable<Player> players, Int32 startingAmount)
        {
            accounts = new Dictionary<Player, Int32>();

            foreach (var player in players)
                accounts.Add(player, startingAmount);
        }
        
        public void Credit(Player player, Int32 amount)
        {
            accounts[player] += amount;
        }

        public void Debit(Player player, Int32 amount)
        {
            accounts[player] -= amount;
        }

        public Int32 GetBalance(Player player)
        {
            return accounts[player];
        }

        public void Debit(Player player, Int32 maxAmount, Int32 percent)
        {
            accounts[player] -= Math.Min(maxAmount, GetBalance(player) / percent);
        }

        public void PayEachPlayer(Player payer, Int32 amount)
        {
            var playersToPay = accounts.Keys.Where(p => p != payer).ToList();

            foreach (var payee in playersToPay)
            {
                Credit(payee, amount);
                Debit(payer, amount);
            }
        }

        public void CollectFromEachPlayer(Player payee, Int32 amount)
        {
            var playersToPay = new List<Player>();
            playersToPay = accounts.Keys.Where(p => p != payee).ToList();

            foreach (var payer in playersToPay)
            {
                Credit(payee, amount);
                Debit(payer, amount);
            }
        }
    }
}
