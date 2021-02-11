using System.Collections.Generic;
using System.Linq;
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
            int sum = Throws.Sum();
            return sum;
        }

        public void Move(int diceAmount)
        {
            if (IsInReverse)
            {
                if ((Position + diceAmount) > 63)
                {
                    Position = 63 - ((Position + diceAmount) % 63);
                    //IsInReverse = true;
                }
                else
                {
                    Position -= diceAmount;
                }
            }
            else
            {
                Position += diceAmount;
            }
        }
    }
}