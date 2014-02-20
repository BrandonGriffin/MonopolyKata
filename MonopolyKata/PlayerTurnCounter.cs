using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class PlayerTurnCounter
    {
        public Dictionary<String, Int32> TurnsTaken { get; set; }

        public PlayerTurnCounter(IEnumerable<String> players)
        {
            TurnsTaken = new Dictionary<String, Int32>();
 
            foreach (var player in players)
                TurnsTaken.Add(player, 0);
        }

        public void IncreaseTurnsTakenByOne(String player)
        {
            TurnsTaken[player]++;
        }
    }
}
