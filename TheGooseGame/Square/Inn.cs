using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    class Inn : Square
    {
        public override void Action(IPlayer player)
        {
            player.IsInInn = true;
        }
    }
}
