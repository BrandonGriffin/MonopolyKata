using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Banker
    {
        private Dictionary<String, Int32> accounts;
        
        public Banker(IEnumerable<String> players, Int32 startingAmount)
        {
            accounts = new Dictionary<String, Int32>();

            foreach (var player in players)
                accounts.Add(player, startingAmount);
        }
        
        public void Credit(String player, Int32 amount)
        {
            accounts[player] += amount;
        }

        public void Debit(String player, Int32 amount)
        {
            accounts[player] -= amount;
        }

        public Int32 GetBalance(String player)
        {
            return accounts[player];
        }

        public void Debit(String player, Int32 maxAmount, Int32 percent)
        {
            Debit(player, Math.Min(maxAmount, GetBalance(player) / percent));
        }

        public void PayEachPlayer(String payer, Int32 amount)
        {
            var playersToPay = accounts.Keys.Where(p => p != payer).ToList();

            foreach (var payee in playersToPay)
                Transfer(amount, payer, payee);
        }

        public void CollectFromEachPlayer(String payee, Int32 amount)
        {
            var playersToPay = accounts.Keys.Where(p => p != payee).ToList();

            foreach (var payer in playersToPay)
                Transfer(amount, payer, payee);
        }
        
        public void Transfer(Int32 amount, String payer, String payee)
        {
            Debit(payer, amount);
            Credit(payee, amount);
        }
    }
}