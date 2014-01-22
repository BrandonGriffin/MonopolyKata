using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Game
    {
        public List<Player> Players { get; private set; }

        public Game(List<Player> players, Random random)
        {
            if (players.Count < 2)
                throw new NotEnoughPlayersException();
            else if (players.Count > 8)
                throw new TooManyPlayersException();

            players.Shuffle(random);

            Players = players;
        }

        public void Play()
        {
            foreach (var player in Players)
                player.RollDice();
        }
    }
}
