using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
     public class MySquare : ISquare
    {
        public virtual void Action(IPlayer player) { }
    }
}
