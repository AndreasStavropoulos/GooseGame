using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    class Goose: MySquare
    {
        public override void Action(IPlayer player)
        {
            player.IsOnGoose = true;
            if (player.IsInReverse == true)
            {
                player.Position -= player.SumOfDices();
            }
            else
            {
                player.Position += player.SumOfDices();
            }
        }
    }
}
