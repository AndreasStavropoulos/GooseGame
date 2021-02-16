using System.Collections.Generic;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public interface IGameboard
    {
        IList<ISquare> Squares { get; set; }

        IList<IPlayer> Players { get; set; }

        void GameLoop();

        ISquare GetSquare(int id);

        void MovePlayer(IPlayer player, int diceAmount, ISquare square);
    }
}