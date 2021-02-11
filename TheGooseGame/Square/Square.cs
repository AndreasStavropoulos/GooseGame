using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    abstract class Square : ISquare
    {
        public virtual void Action(IPlayer player) { }
    }
}
