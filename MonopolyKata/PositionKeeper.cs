﻿using System;
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

            CreateBoard();
        }

        private void CreateBoard()
        {
            Board = new Dictionary<Int32, IBoardSpace> 
            { 
                { 0, new Go(teller) },
                { 1, new Property("Mediterranean Avenue", 60, 2,"Purple", teller) },
                { 3, new Property("Baltic Avenue", 60, 4, "Purple", teller) },
                { 4, new IncomeTax(teller) },
                { 5, new Property("Reading Railroad", 200, 25, "Railroad", teller) },
                { 6, new Property("Oriental Avenue", 100, 6, "Light Blue", teller) },
                { 8, new Property("Vermont Avenue", 100, 6, "Light Blue", teller) },
                { 9, new Property("Connecticut Avenue", 120, 8, "Light Blue", teller) }, 
                { 11, new Property("St. Charles Place", 140, 10, "Violet", teller) },
                { 12, new Property("Electric Company", 150, 0, "Utility", teller) },
                { 13, new Property("States Avenue", 140, 10, "Violet", teller) },
                { 14, new Property("Virginia Avenue", 160, 12, "Violet", teller) },
                { 15, new Property("Pennsylvania Railroad", 200, 25, "Railroad", teller) },
                { 16, new Property("St. James Place", 180, 14, "Orange", teller) },
                { 18, new Property("Tennessee Avenue", 180, 14, "Orange", teller) },
                { 19, new Property("New York Avenue", 200, 16, "Orange", teller) },
                { 21, new Property("Kentucky Avenue", 220, 18, "Red", teller) },
                { 23, new Property("Indiana Avenue", 220, 18, "Red", teller) },
                { 24, new Property("Illinois Avenue", 240, 20, "Red", teller) },
                { 25, new Property("B & O Railroad", 200, 25, "Railroad", teller) },
                { 26, new Property("Atlantic Avenue", 260, 22, "Yellow", teller) },
                { 27, new Property("Ventor Avenue", 260, 22, "Yellow", teller) },
                { 28, new Property("Water Works", 150, 0, "Utility", teller) },
                { 29, new Property("Marvin Gardens", 280, 24, "Yellow", teller) },
                { 30, new GoToJail(this, 10) },
                { 31, new Property("Pacific Avenue", 300, 26, "Green", teller) },
                { 32, new Property("North Carolina Avenue", 300, 26, "Green", teller) },
                { 34, new Property("Pennsylvania Avenue", 320, 28, "Green", teller) },
                { 35, new Property("Short Line", 200, 25, "Railroad", teller) },
                { 37, new Property("Park Place", 350, 35, "Blue", teller) },
                { 38, new LuxuryTax(teller) },
                { 39, new Property("Boardwalk", 400, 50, "Blue", teller) },
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
