using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class Death : NormalSquare
    {
        public Death(int id) : base(id)
        {
            BackColor = Colors.Pink;
        }

        public override void Action(IPlayer player)
        {
            player.Position = 0;
        }


    }
}