using System.Collections.Generic;
using System.Linq;

namespace TheGooseGame
{
    public class Player : IPlayer
    {
        public Player(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int Position { get; set; }
        public bool IsInWell { get; set; }
        public bool PlayerWon { get; set; }
        public bool IsOnGoose { get; set; }
        public bool IsInReverse { get; set; }
        public int TurnsToStayStill { get; set; }
        public int AmountOFDice { get; set; }

        public List<int> Throws { get; set; }


        public void Move(int diceAmount)
        {
            if (Position + diceAmount > 63 && !IsInReverse)
            {
                Position = 63 - ((Position + diceAmount) % 63);
                IsInReverse = true;
            }
            else
            {
                Position += diceAmount;
            }
        }
    }
}