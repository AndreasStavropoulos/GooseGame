using System.Collections.Generic;

namespace TheGooseGame
{
    

    public class PlayerRepo : IPlayerRepo
    {
        //public int numberOfPlayers { get; set; }

        public IList<IPlayer> ListOfPlayers(int numberOfPlayers)
        {
            IList<IPlayer> players = new List<IPlayer>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(i+1));
            }
            return players;
        }
    }
}