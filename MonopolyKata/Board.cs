using System;
using System.Collections.Generic;
using System.Linq;
using MonopolyKata.Spaces;

namespace MonopolyKata
{
    public class Board
    {
        private Dictionary<Int32, IBoardSpace> spaces;
        private Dictionary<String, Int32> playerPositions;

        public Board(IEnumerable<String> players)
        {
            playerPositions = new Dictionary<String, Int32>();

            foreach (var player in players)
                playerPositions.Add(player, 0);
        }

        public void SetSpaces(Dictionary<Int32, IBoardSpace> spaces)
        {
            this.spaces = spaces;
        }

        public Int32 GetPosition(String player)
        {
            return playerPositions[player];
        }

        public void Move(String player, Int32 roll)
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

        public void MoveTo(String player, Int32 spaceIndex)
        {
            playerPositions[player] = spaceIndex;
            PerformSpaceAction(player);
        }
        
        private void PerformSpaceAction(String player)
        {
            if (spaces.ContainsKey(playerPositions[player]))
                spaces[playerPositions[player]].LandOnSpace(player);
        }

        public void MoveToJail(String player)
        {
            MoveTo(player, 10);
        }

        public void MoveToNearest(String player, IEnumerable<Int32> spaceIndices)
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