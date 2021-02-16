using System.Collections.Generic;
using System.Windows.Media;

namespace TheGooseGame.Square
{
    public interface ISquare
    {
        public int Id { get; set; }

        public Color BackColor { get; set; }

        public IList<IPlayer> PlayersOnSquare { get; set; }

        void Action(IPlayer player);
    }
}