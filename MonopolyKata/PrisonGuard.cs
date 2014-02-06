using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class PrisonGuard
    {
        public Dictionary<Player, Int32> IncarcerationList;
        private Teller teller;
        private IDice dice;

        public PrisonGuard(List<Player> players, Teller teller, IDice dice)
        {
            IncarcerationList = new Dictionary<Player, Int32>();
            this.teller = teller;
            this.dice = dice;

            foreach (var player in players)
                IncarcerationList.Add(player, 0);
        }

        public Boolean IsIncarcerated(Player player)
        {
            if (dice.RollWasDoubles())
            {
                IncarcerationList[player] = 0;
                return false;
            }

            return IncarcerationList[player] > 0;
        }

        public void Incarcerate(Player player)
        {
            IncarcerationList[player] = 1;
        }

        public void Bribe(Player player)
        {
            IncarcerationList[player] = 0;
            teller.Debit(player, 50);
        }

        public void PassTime(Player player)
        {
            IncarcerationList[player]++;
            if (IncarcerationList[player] >= 3)
                Bribe(player);
        }
    }
}