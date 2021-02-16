using System.Collections.Generic;

namespace TheGooseGame
{
    public class PlayerRepo : IPlayerRepo
    {
        public IList<IPlayer> ListOfPlayers(int numberOfPlayers)
        {
            IList<IPlayer> players = new List<IPlayer>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                players.Add(new Player(i, "https://freesvg.org/img/red-pawn.png"));
            }
            return players;
        }
    }
}