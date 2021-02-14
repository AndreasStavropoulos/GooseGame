using TheGooseGame.Interfaces;

namespace TheGooseGame.Square
{
    internal class Well : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.IsInWell = true;
        }
    }
}