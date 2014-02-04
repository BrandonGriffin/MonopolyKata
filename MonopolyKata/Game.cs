using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Game
    {
        public IEnumerable<Player> Players { get; private set; }
        public Int32 RoundsPlayed { get; private set; }

        private IDice dice;
        private PositionKeeper positionKeeper;
        private Teller teller;
        private PlayerTurnCounter turns;

        public Game(IEnumerable<Player> players, IDice dice, PositionKeeper positionKeeper, Teller teller, PlayerTurnCounter turns)
        {
            CheckNumberOfPlayers(players);
            Players = players;
            this.dice = dice;
            this.positionKeeper = positionKeeper;
            this.teller = teller;
            this.turns = turns;

            Shuffle();            
        }

        private void CheckNumberOfPlayers(IEnumerable<Player> players)
        {
            if (players.Count() < 2)
                throw new NotEnoughPlayersException();
            else if (players.Count() > 8)
                throw new TooManyPlayersException();
        }

        private void Shuffle()
        {
            var rolls = new Dictionary<Player, Int32>();

            foreach (var player in Players)
            {
                dice.Roll();
                rolls.Add(player, dice.Value);
            }

            Players = Players.OrderByDescending(p => rolls[p]);
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
            dice.Roll();
            var roll = dice.Value;
            positionKeeper.MovePlayer(player, roll);
            turns.IncreaseTurnsTakenByOne(player);
        }
    }
}
