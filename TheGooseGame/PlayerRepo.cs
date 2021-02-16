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
                players.Add(new Player(i));
            }

            SetPlayerColours(numberOfPlayers, players);

            return players;
        }

        private void SetPlayerColours(int numberOfPlayers, IList<IPlayer> players)
        {
            if (numberOfPlayers > 0)
            {
                players[0].Pawn = "https://freesvg.org/img/red-pawn.png";
            }

            if (numberOfPlayers > 1)
            {
                players[1].Pawn = "https://freesvg.org/img/red-pawn.png";
            }

            if (numberOfPlayers > 2)
            {
                players[2].Pawn = "https://freesvg.org/img/red-pawn.png";
            }

            if (numberOfPlayers > 3)
            {
                players[3].Pawn = "https://freesvg.org/img/red-pawn.png";
            }
        }
    }
}