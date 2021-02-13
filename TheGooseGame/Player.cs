using System.Collections.Generic;
using System.Linq;
using TheGooseGame.Intefaces;

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
        public bool IsInWell { get; set; }
        public bool PlayerWon { get; set; }
        public bool IsOnGoose { get; set; }
        public bool IsInReverse { get; set; }
        public bool IsInNormalSquare { get; set; }
        public bool IsInMaze { get; set; }

        public int TurnsToStayStill { get; set; }
        public List<int> Throws { get; set; }

        public int SumOfDices()
        {
            int sum = Throws.Sum();
            return sum;
        }

        public void Move(int diceAmount)
        {
            if (this.Position + diceAmount > 63 && !this.IsInReverse)
            {
                this.Position = 63 - ((Position + diceAmount) % 63);
                this.IsInReverse = true;
                IsOnGoose = Gameboard.IsPlayerInGoose(this);

                while (this.IsInReverse && this.IsOnGoose)
                {
                    Position -= diceAmount;
                    IsOnGoose = Gameboard.IsPlayerInGoose(this);
                }
                this.IsInReverse = false;
            } else
            {
                Position += diceAmount;
            }
        }
    }
}