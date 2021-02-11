using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    class Prison :MySquare
    {
        public override void Action(IPlayer player)
        {
            if (player.PrisonYearsLeft == 0)
            {
                player.PrisonYearsLeft = 3;
            }
            else
            {
                player.PrisonYearsLeft--;
            }
        }
    }
}
