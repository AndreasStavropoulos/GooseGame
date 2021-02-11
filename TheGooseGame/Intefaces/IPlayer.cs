using System.Collections.Generic;

namespace TheGooseGame.Intefaces
{
    public interface IPlayer
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

        public int SumOfDices();

        public void Move(int cells);
    }
}