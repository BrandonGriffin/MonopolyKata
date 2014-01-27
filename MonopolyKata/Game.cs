﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Game
    {
        public List<Player> Players { get; private set; }
        public Int32 RoundsPlayed { get; private set; }

        private IDice dice;
        private PositionKeeper positionKeeper;
        private Teller teller;

        public Game(List<Player> players, IDice dice, PositionKeeper positionKeeper, Teller teller)
        {
            CheckNumberOfPlayers(players);
            Players = players;
            this.dice = dice;
            this.positionKeeper = positionKeeper;
            this.teller = teller;

            Shuffle();            
        }

        private static void CheckNumberOfPlayers(List<Player> players)
        {
            if (players.Count < 2)
                throw new NotEnoughPlayersException();
            else if (players.Count > 8)
                throw new TooManyPlayersException();
        }

        private void Shuffle()
        {
            Players = Players.OrderByDescending(p => dice.Roll()).ToList();
        }

        public void Play()
        {
            for (var i = 0; i < 20; i++)
            {
                foreach (var player in Players)
                    TakeTurn(player);

                RoundsPlayed++;
            }
        }

        public void TakeTurn(Player player)
        {
            var roll = dice.Roll();
            positionKeeper.MovePlayer(player, roll);
            player.TurnsTaken++;
        }
    }
}
