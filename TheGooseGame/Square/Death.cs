using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    class Death : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.Position = 0;
        }
    }
}
