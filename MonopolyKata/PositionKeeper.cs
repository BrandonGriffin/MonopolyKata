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
            var timesPassedGo = (playerPositions[player] + roll) / 41;
            if (timesPassedGo > 0)
                GivePlayerMoneyForPassingGo(player, timesPassedGo);

            UpdatePlayerPosition(player, roll);

            if (PlayerIsOnASpecialSpace(player))
                PerformSpaceAction(player);
        }

        private void GivePlayerMoneyForPassingGo(Player player, Int32 timesPassedGo)
        {
            for (var i = 0; i < timesPassedGo; i++)
                board[0].LandOnSpace(player);
        }

        private void UpdatePlayerPosition(Player player, Int32 roll)
        {
            playerPositions[player] = (playerPositions[player] + roll) % 40;
        }

        private void PerformSpaceAction(Player player)
        {
            board[playerPositions[player]].LandOnSpace(player);
        }

        private bool PlayerIsOnASpecialSpace(Player player)
        {
            return board.ContainsKey(playerPositions[player]);
        }

        public void SetPosition(Player player, Int32 space)
        {
            playerPositions[player] = space;
        }
    }
}
