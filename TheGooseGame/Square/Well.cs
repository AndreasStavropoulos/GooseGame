using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    class Well : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.IsInWell = true;
        }
    }
}
