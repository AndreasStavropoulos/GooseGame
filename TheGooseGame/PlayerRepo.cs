using System.Collections.Generic;

namespace TheGooseGame
{
    public class PlayerRepo
    {
        //public int NumberOfPlayers { get; set; }

        public List<Player> ListOfPlayers(int numberOfPlayers)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player());
            }
            return players;
        }
    }
}