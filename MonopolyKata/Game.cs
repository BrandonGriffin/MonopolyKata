using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Game
    {
        public IEnumerable<String> Players { get; private set; }
        public Int32 RoundsPlayed { get; private set; }

        private IDice dice;
        private Board board;
        private PlayerTurnCounter turns;
        private Int32 doubleCounter;
        private PrisonGuard guard;

        public Game(IEnumerable<String> players, IDice dice, Board board, PlayerTurnCounter turns, PrisonGuard guard)
        {
            CheckNumberOfPlayers(players);
            Players = players;
            this.dice = dice;
            this.board = board;
            this.turns = turns;
            this.guard = guard;

            ShufflePlayers();            
        }

        private void CheckNumberOfPlayers(IEnumerable<String> players)
        {
            if (players.Count() < 2)
                throw new NotEnoughPlayersException();
            else if (players.Count() > 8)
                throw new TooManyPlayersException();
        }

        private void ShufflePlayers()
        {
            Players = Players.OrderByDescending(p => { dice.Roll(); return dice.Value; });
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

        public void TakeTurn(String player)
        {
            var playerWasIncarecerated = guard.IsIncarcerated(player);
            dice.Roll();

            if (dice.IsDoubles)
            {
                board.Move(player, dice.Value);
                if (playerWasIncarecerated)
                {
                    turns.IncreaseTurnsTakenByOne(player);
                    return;
                }

                while (PlayerIsRollingDoubles())
                    ContinueTurn(player);
            }
            else if (playerWasIncarecerated)
            {
                guard.ServeTurn(player);
            }
            else
            {
                board.Move(player, dice.Value);
            }

            turns.IncreaseTurnsTakenByOne(player);
            doubleCounter = 0;
        }

        private void ContinueTurn(String player)
        {
            doubleCounter++;

            if (doubleCounter > 2)
            {
                guard.Incarcerate(player);
                board.MoveToJail(player);
            }
            else
            {
                dice.Roll();
                board.Move(player, dice.Value);
            }
        }

        private Boolean PlayerIsRollingDoubles()
        {
            return dice.IsDoubles && doubleCounter <= 2;
        }

        public class NotEnoughPlayersException : Exception
        { }

        public class TooManyPlayersException : Exception
        { }
    }
}
