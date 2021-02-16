using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class End : NormalSquare
    {
        public End(int id) : base(id)
        {
            BackColor = Colors.Orange;
        }

        public override void Action(IPlayer player)
        {
            player.PlayerWon = true;
        }

        
    }
}