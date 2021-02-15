using System.Collections.Generic;

namespace TheGooseGame
{
    public interface IPlayer
    {
        int Id { get; set; }

        bool IsInReverse { get; set; }

        bool IsInWell { get; set; }

        bool IsOnGoose { get; set; }

        bool PlayerWon { get; set; }

        int Position { get; set; }

        List<int> Throws { get; set; }

        int TurnsToStayStill { get; set; }

        void Move(int diceAmount);

        int SumOfDices();
    }
}