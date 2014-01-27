using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class PositionKeeper
    {
        public Dictionary<Player, Int32> PlayerPositions;
        public Dictionary<Int32, IBoardSpace> Board;
        private Teller teller;

        public PositionKeeper(List<Player> players, Teller teller)
        {
            PlayerPositions = new Dictionary<Player, Int32>();
            this.teller = teller;

            foreach (var player in players)
                PlayerPositions.Add(player, 0);

            Board = new Dictionary<Int32, IBoardSpace> 
            { 
                { 0, new Go(teller) },
                { 3, new BalticAvenue(teller) },
                { 4, new IncomeTax(teller) },
                { 30, new GoToJail(this, 10) },
                { 38, new LuxuryTax(teller) } 
            };
        }

        public void MovePlayer(Player player, Int32 roll)
        {
            var positionPlusRoll = PlayerPositions[player] + roll;

            UpdatePlayerPosition(player, roll);
            CheckToSeeIfPlayerPassesGo(player, positionPlusRoll);
            
            if (PlayerIsOnASpecialSpace(player))
                PerformSpaceAction(player);
        }

        private void UpdatePlayerPosition(Player player, Int32 roll)
        {
            PlayerPositions[player] = (PlayerPositions[player] + roll) % 40;
        }
        
        private void CheckToSeeIfPlayerPassesGo(Player player, Int32 positionPlusRoll)
        {
            while (positionPlusRoll > 40)
            {
                Board[0].PassOverSpace(player);
                positionPlusRoll -= 40;
            }
        }

        private Boolean PlayerIsOnASpecialSpace(Player player)
        {
            return Board.ContainsKey(PlayerPositions[player]);
        }

        private void PerformSpaceAction(Player player)
        {
            Board[PlayerPositions[player]].LandOnSpace(player);
        }
        public void SetPosition(Player player, Int32 space)
        {
            PlayerPositions[player] = space;
        }
    }
}
