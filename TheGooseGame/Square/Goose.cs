using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class Goose : NormalSquare
    {
        public Goose(int id) : base(id)
        {
            BackColor = Colors.Red;
        }

        public override void Action(IPlayer player)
        {
            if (player.IsInReverse)
            {
                player.Position -= player.AmountOfDice;
                while (player.IsInReverse && player.Position == 59 || player.IsInReverse && player.Position == 54)
                {
                    player.Position -= player.AmountOfDice;
                }
                player.IsInReverse = false;
            }
            else
            {
                player.Position += player.AmountOfDice;
            }
        }
    }
}