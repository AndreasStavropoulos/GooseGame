using System.Windows;
using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class Inn : NormalSquare
    {
        public Inn(int id) : base(id)
        {
            BackColor = Colors.Blue;
        }

        public override void Action(IPlayer player)
        {
            player.TurnsToStayStill++;
            MessageBox.Show("Wait 1 turn");
        }
    }
}