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
            var playerIsInJail = guard.IsIncarcerated(player);
            dice.Roll();
            
            board.Move(player, dice.Value);

            if (playerIsInJail)
                guard.ServeTurn(player);
            else
                while (PlayerIsRollingDoubles())
                    PlayerKeepsPlaying(player);

            turns.IncreaseTurnsTakenByOne(player);
        }

        private void PlayerKeepsPlaying(Player player)
        {
            doubleCounter++;

            if (doubleCounter > 2)
            {
                SendPlayerToJail(player);
            }
            else
            {
                dice.Roll();
                board.Move(player, dice.Value);
            }
        }

        private Boolean PlayerIsRollingDoubles()
        {
            return dice.RollWasDoubles() && doubleCounter <= 2;
        }

        private void SendPlayerToJail(Player player)
        {
            board.MoveTo(player, 10);
        }
    }
}
