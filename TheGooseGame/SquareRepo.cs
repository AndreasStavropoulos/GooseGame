using System.Collections.Generic;
using TheGooseGame.Intefaces;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public class SquareRepo 
    {
        public List<ISquare> SquareList;

        public List <ISquare> CreateSquareList ()
        {
            List<ISquare> squares = new List<ISquare>()
            {
//                new Goose

            };


            return squares;
        }
    }
}