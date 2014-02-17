using System;
using System.Collections.Generic;

namespace MonopolyKata.CoreComponents
{
    public class PlayerTurnCounter
    {
        public Dictionary<Player, Int32> TurnsTaken { get; set; }

        public PlayerTurnCounter(List<Player> players)
        {
            TurnsTaken = new Dictionary<Player, Int32>();
 
            foreach (var player in players)
                TurnsTaken.Add(player, 0);
        }

        public void IncreaseTurnsTakenByOne(Player player)
        {
            TurnsTaken[player]++;
        }
    }
}
