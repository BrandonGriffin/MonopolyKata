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
        private Board board;
        private Banker banker;
        private PlayerTurnCounter turns;
        private Int32 doubleCounter;
        private PrisonGuard guard;

        public Game(IEnumerable<Player> players, IDice dice, Board board, Banker banker, PlayerTurnCounter turns, PrisonGuard guard)
        {
            CheckNumberOfPlayers(players);
            Players = players;
            this.dice = dice;
            this.board = board;
            this.banker = banker;
            this.turns = turns;
            this.guard = guard;

            ShufflePlayers();            
        }

        private void CheckNumberOfPlayers(IEnumerable<Player> players)
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

        public void TakeTurn(Player player)
        {
            var playerWasIncarecerated = guard.IsIncarcerated(player);
            dice.Roll();

            if (dice.isDoubles)
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

        private void ContinueTurn(Player player)
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
            return dice.isDoubles && doubleCounter <= 2;
        }
    }
}
