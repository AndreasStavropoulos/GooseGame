using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class Maze : NormalSquare
    {

        public Maze(int id) : base(id)
        {
            BackColor = Colors.Indigo;
        }

        public override void Action(IPlayer player)
        {
            player.Position = 39;
        }
    }
}