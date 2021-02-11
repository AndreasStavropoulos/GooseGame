using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    class Bridge : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.Position = 12;
        }
    }
}
