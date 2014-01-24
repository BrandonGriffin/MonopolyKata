using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Mover
    {
        private IDice dice;
     
        public Mover(IDice dice)
        {
            this.dice = dice;
        }

        public void MovePlayer(Player player)
        {
            player.PreviousPosition = player.Position;

            var roll = dice.Roll();
            player.Rolls.Add(roll);

            player.Position = NewPosition(roll, player.Position);
        }

        private Int32 NewPosition(Int32 roll, Int32 playerPosition)
        {
            Int32 newPosition = (playerPosition + roll) % 40;

            if (PlayerIsOnGoToJail(newPosition))
                return 10;

            return newPosition;
        }

        private Boolean PlayerIsOnGoToJail(Int32 newPosition)
        {
            return newPosition == 30;
        }
    }
}
