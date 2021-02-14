using System.Collections.Generic;
using System.Linq;
using TheGooseGame.Interfaces;

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

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }


        public int Turn { get; set; }

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

        public int CheckPositionOfPlayer(IList<IPlayer> players)
        {

            int position = Position;

            return position;
        }

        public void CountOfTurns(IList<IPlayer> players, List<int> throws)
        {
            Count = 0;

            if (Position.Equals(IsOnGoose))
            {
                foreach (var turn in throws)
                {
                    Count++;
                    throws.Add(turn);
                }
            }
            throws.Clear();         
        }

    }
}