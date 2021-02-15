using System.Collections.Generic;

namespace TheGooseGame
{
    public interface IPlayerRepo
    {
        IList<IPlayer> ListOfPlayers(int numberOfPlayers);
    }
}