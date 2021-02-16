using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class Well : NormalSquare
    {
        public Well(int id) : base(id)
        {
            BackColor = Colors.Yellow;
        }

        public override void Action(IPlayer player)
        {
            player.IsInWell = true;
        }
    }
}