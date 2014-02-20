using System;

namespace MonopolyKata.Spaces
{
    public class Go : IBoardSpace
    {
        private Banker banker;

        public Go(Banker banker)
        {
            this.banker = banker;
        }

        public void LandOnSpace(String player)
        {
            banker.Credit(player, 200);
        }
    }
}
