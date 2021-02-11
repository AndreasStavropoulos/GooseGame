using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGooseGame.Intefaces;

namespace TheGooseGame
{
    public class Player : IPlayer
    {
        public int Position { get; set; }
        public bool IsInInn { get; set; }
        public int PrisonYearsLeft { get; set; }
        public bool IsInWell { get; set; }
        public bool PlayerWon { get; set; }
        public bool IsOnGoose { get; set; }
        public bool IsInReverse { get; set; }
        public bool IsInNormalSquare { get; set; }
        public bool IsInMaze { get; set; }
        public List<int> Throws { get; set; }

        public int SumOfDices()
        {
            int sum = Throws.Take(3).Sum();
            return sum;
        }

        public void Move(int cells)
        {
            Position += cells;
        }

    }
}
