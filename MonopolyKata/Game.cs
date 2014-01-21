using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Game
    {
        public List<Player> players { get; private set; }

        public Game(List<Player> players, Random random)
        {
            if (players.Count < 2)
                throw new NotEnoughPlayersException();
            else if (players.Count > 8)
                throw new TooManyPlayersException();

            players.Shuffle(random);

            this.players = players;
        }

        public IEnumerable<String> GetPlayerOrder()
        {
            var order = new List<String>();

            for (var i = 0; i < players.Count; i++)
                order.Add(players[i].Name);

            return order;
        }

        public void PlayRound()
        {
            foreach (var player in players)
                player.RollDice();
        }
    }
}
