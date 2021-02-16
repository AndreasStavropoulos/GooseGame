using System.Collections.Generic;
using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class NormalSquare : ISquare
    {
        public int Id { get; set; }

        public Color BackColor { get; set; }

        public IList<IPlayer> PlayersOnSquare { get; set; }

        public NormalSquare(int id)
        {
            Id = id;
            PlayersOnSquare = new List<IPlayer>();
        }

        public virtual void Action(IPlayer player)
        {
            // To be overridden in deriving classes   
        }
    }
}