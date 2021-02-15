using TheGooseGame.Interfaces;

namespace TheGooseGame.Square
{
    internal class Goose : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.IsOnGoose = true;
            if (player.IsInReverse == true)
            {
                player.Position -= player.SumOfDices();
            }
            else
            {
                player.Position += player.SumOfDices();
            }
        }
    }
}