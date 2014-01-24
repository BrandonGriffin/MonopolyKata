using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class Game
    {
        public List<Player> Players { get; private set; }
        public Int32 RoundsPlayed { get; private set; }

        private IDice dice;
        private Mover mover;
        private Banker banker;

        public Game(List<Player> players, Random random, IDice dice, Mover mover, Banker banker)
        {
            CheckNumberOfPlayers(players);

            Players = players;
            Shuffle(random);
            this.dice = dice;
            this.mover = mover;
            this.banker = banker;
        }

        private static void CheckNumberOfPlayers(List<Player> players)
        {
            if (players.Count < 2)
                throw new NotEnoughPlayersException();
            else if (players.Count > 8)
                throw new TooManyPlayersException();
        }

        private void Shuffle(Random random)
        {
            var n = Players.Count;

            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                var value = Players[k];
                Players[k] = Players[n];
                Players[n] = value;
            }
        }

        public void Play()
        {
            for (var i = 0; i < 20; i++)
            {
                foreach (var player in Players)
                {
                    TakeTurn(player);
                    CheckPosition(player);
                }

                RoundsPlayed++;
            }
        }

        public void TakeTurn(Player player)
        {
            mover.MovePlayer(player);
            player.TurnsTaken++;
        }

        public void CheckPosition(Player player)
        {
            if (PlayerIsOnIncomeTax(player))
                CollectIncomeTax(player);
            else if (PlayerIsOnLuxuryTax(player))
                CollectLuxuryTax(player);

            if (PlayerPassedGo(player))
                GiveMoneyForPassingGo(player);
        }

        private Boolean PlayerIsOnIncomeTax(Player player)
        {
            return player.Position == 4;
        }
        
        private void CollectIncomeTax(Player player)
        {
            if (player.Money >= 2000)
            {
                banker.DebitAccount(player, 200);
            }
            else
            {
                var amountToSubtract = player.Money * .1;
                banker.DebitAccount(player, amountToSubtract); 
            }
        }
       
        private void CollectLuxuryTax(Player player)
        {
            banker.DebitAccount(player, 75);
        }

        private Boolean PlayerIsOnLuxuryTax(Player player)
        {
            return player.Position == 38;
        }

        private Boolean PlayerPassedGo(Player player)
        {
            return (Double)(player.PreviousPosition + player.Rolls[player.TurnsTaken - 1]) / 40 >= 1;
        }
        
        private void GiveMoneyForPassingGo(Player player)
        {
            var amountToAdd = GetTimesPassedGo(player);
            banker.CreditAccount(player, amountToAdd);
        } 
        
        private Double GetTimesPassedGo(Player player)
        {
            var timesPassingGo = (Double)(player.PreviousPosition + player.Rolls[player.TurnsTaken - 1]) / 40;
            var amountToAdd = (Double)200 * Math.Floor(timesPassingGo);
            return amountToAdd;
        }
    }
}
