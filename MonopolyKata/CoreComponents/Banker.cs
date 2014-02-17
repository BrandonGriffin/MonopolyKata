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
            Debit(player, Math.Min(maxAmount, GetBalance(player) / percent));
        }

        public void PayEachPlayer(Player payer, Int32 amount)
        {
            var playersToPay = accounts.Keys.Where(p => p != payer).ToList();

            foreach (var payee in playersToPay)
                Transfer(amount, payer, payee);
        }

        public void CollectFromEachPlayer(Player payee, Int32 amount)
        {
            var playersToPay = accounts.Keys.Where(p => p != payee).ToList();

            foreach (var payer in playersToPay)
                Transfer(amount, payer, payee);
        }
        
        public void Transfer(Int32 amount, Player payer, Player payee)
        {
            Debit(payer, amount);
            Credit(payee, amount);
        }
    }
}