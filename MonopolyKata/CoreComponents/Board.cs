using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata.CoreComponents
{
    public class Board
    {
        private Dictionary<Int32, IBoardSpace> spaces;
        private Dictionary<Player, Int32> playerPositions;

        public Board(IEnumerable<Player> players)
        {
            playerPositions = new Dictionary<Player, Int32>();

            foreach (var player in players)
                playerPositions.Add(player, 0);
        }

        public void SetSpaces(Dictionary<Int32, IBoardSpace> spaces)
        {
            this.spaces = spaces;
        }

        public Int32 GetPosition(Player player)
        {
            return playerPositions[player];
        }

        public void Move(Player player, Int32 roll)
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

        public void MoveToJail(Player player)
        {
            MoveTo(player, 10);
        }

        public void MoveToNearest(Player player, IEnumerable<Int32> spaceIndices)
        {
            var positionIndex = GetPosition(player);
            var nextPosition = 0;

            foreach (var index in spaceIndices)
                if (nextPosition == 0 && index > positionIndex)
                    nextPosition = index;

            if (nextPosition == 0)
                nextPosition = spaceIndices.First();

            MoveTo(player, nextPosition);
        }
    }
}