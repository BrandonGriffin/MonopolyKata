using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Board
    {
        private Dictionary<Int32, IBoardSpace> board;
        private Dictionary<Player, Int32> playerPositions;
        private PrisonGuard guard;

        public Board(List<Player> players, PrisonGuard guard)
        {
            playerPositions = new Dictionary<Player, Int32>();
            this.guard = guard;

            foreach (var player in players)
                playerPositions.Add(player, 0);
        }

        public void SetBoard(Dictionary<Int32, IBoardSpace> board)
        {
            this.board = board;
        }

        public Int32 GetPosition(Player player)
        {
            return playerPositions[player];
        }

        public void MovePlayer(Player player, Int32 roll)
        {
            if (!guard.IsIncarcerated(player))
            {
                var positionPlusRoll = playerPositions[player] + roll;

                UpdatePlayerPosition(player, roll);
                CheckToSeeIfPlayerPassesGo(player, positionPlusRoll);

                if (PlayerIsOnASpecialSpace(player))
                    PerformSpaceAction(player);
            }
        }

        private void UpdatePlayerPosition(Player player, Int32 roll)
        {
            playerPositions[player] = (playerPositions[player] + roll) % 40;
        }
        
        private void CheckToSeeIfPlayerPassesGo(Player player, Int32 positionPlusRoll)
        {
            while (positionPlusRoll > 40)
            {
                board[0].SpaceAction(player);
                positionPlusRoll -= 40;
            }
        }

        private Boolean PlayerIsOnASpecialSpace(Player player)
        {
            return board.ContainsKey(playerPositions[player]);
        }

        private void PerformSpaceAction(Player player)
        {
            board[playerPositions[player]].SpaceAction(player);
        }
        public void SetPosition(Player player, Int32 spaceIndex)
        {
            playerPositions[player] = spaceIndex;
        }
    }
}