using System.Collections.Generic;
using TheGooseGame.Intefaces;

namespace TheGooseGame
{
    public class PlayerRepo
    {
        //public int NumberOfPlayers { get; set; }

        public List<IPlayer> ListOfPlayers(int numberOfPlayers)
        {
            List<IPlayer> players = new List<IPlayer>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(i+1));
            }
            return players;
        }
    }
}