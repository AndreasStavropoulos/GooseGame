using System.Collections.Generic;
using System.Linq;
using TheGooseGame.Interfaces;

namespace TheGooseGame
{
    public class Player : IPlayer
    {
        Gameboard Gameboard = new Gameboard();

        public Player(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public int Position { get; set; }
        public bool IsInInn { get; set; }
        public int PrisonYearsLeft { get; set; }
        public bool IsInPrison { get; set; }
        public bool IsInWell { get; set; }
        public bool PlayerWon { get; set; }
        public bool IsOnGoose { get; set; }
        public bool IsInReverse { get; set; }
        public bool IsInNormalSquare { get; set; }
        public bool IsInMaze { get; set; }
        public bool IsInBridge { get; set; }

        public bool IsInDeath { get; set; }

        public int TurnsToStayStill { get; set; }
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
            if (Position + diceAmount > 63 && !IsInReverse)
            {
                Position = 63 - ((Position + diceAmount) % 63);
                IsInReverse = true;
                IsOnGoose = Gameboard.IsPlayerInGoose(this);

                while (IsInReverse && IsOnGoose)
                {
                    Position -= diceAmount;
                    IsOnGoose = Gameboard.IsPlayerInGoose(this);
                }
                IsInReverse = false;
            } else
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