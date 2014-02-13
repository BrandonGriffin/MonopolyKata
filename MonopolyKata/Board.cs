using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Board
    {
        private Dictionary<Int32, IBoardSpace> spaces;
        private Dictionary<Player, Int32> playerPositions;
        private PrisonGuard guard;

        public Board(IEnumerable<Player> players, PrisonGuard guard)
        {
            playerPositions = new Dictionary<Player, Int32>();
            this.guard = guard;

            foreach (var player in players)
                playerPositions.Add(player, 0);
        }

        public void SetBoard(Dictionary<Int32, IBoardSpace> spaces)
        {
            this.spaces = spaces;
        }

        public Int32 GetPosition(Player player)
        {
            return playerPositions[player];
        }

        public void Move(Player player, Int32 roll)
        {
            if (!guard.IsIncarcerated(player))
            {
                var nextPosition = playerPositions[player] + roll;

                playerPositions[player] = nextPosition % 40;
                
                while (nextPosition > 40)
                {
                    spaces[0].LandOnSpace(player);
                    nextPosition -= 40;
                }
                
                PerformSpaceAction(player);
            }
        }

        public void MoveTo(Player player, Int32 spaceIndex)
        {
            playerPositions[player] = spaceIndex;
            PerformSpaceAction(player);
        }
        
        private void PerformSpaceAction(Player player)
        {
            if (spaces.ContainsKey(playerPositions[player]))
                spaces[playerPositions[player]].LandOnSpace(player);
        }
    }
}