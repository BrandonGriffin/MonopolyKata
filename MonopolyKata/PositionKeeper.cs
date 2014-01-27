using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class PositionKeeper
    {
        public Dictionary<Player, Int32> playerPositions;
        private Dictionary<Int32, IBoardSpace> board;
        private Teller teller;

        public PositionKeeper(List<Player> players, Teller teller)
        {
            playerPositions = new Dictionary<Player, Int32>();
            this.teller = teller;

            foreach (var player in players)
                playerPositions.Add(player, 0);

            board = new Dictionary<Int32, IBoardSpace> 
            { 
                { 0, new Go(teller) },
                { 4, new IncomeTax(teller) },
                { 30, new GoToJail(this, 10) },
                { 38, new LuxuryTax(teller) } 
            };
        }

        public void MovePlayer(Player player, Int32 roll)
        {
            var positionPlusRoll = playerPositions[player] + roll;

            UpdatePlayerPosition(player, roll);

            CheckToSeeIfPlayerPassesGo(player, positionPlusRoll);
            
            if (PlayerIsOnASpecialSpace(player))
                PerformSpaceAction(player);
        }

        private void UpdatePlayerPosition(Player player, Int32 roll)
        {
            playerPositions[player] = (playerPositions[player] + roll) % 40;
        }
        
        private void CheckToSeeIfPlayerPassesGo(Player player, Int32 positionPlusRoll)
        {
            while (positionPlusRoll > 40)
            {
                board[0].PassOverSpace(player);
                positionPlusRoll -= 40;
            }
        }

        private Boolean PlayerIsOnASpecialSpace(Player player)
        {
            return board.ContainsKey(playerPositions[player]);
        }

        private void PerformSpaceAction(Player player)
        {
            board[playerPositions[player]].LandOnSpace(player);
        }
        public void SetPosition(Player player, Int32 space)
        {
            playerPositions[player] = space;
        }
    }
}
