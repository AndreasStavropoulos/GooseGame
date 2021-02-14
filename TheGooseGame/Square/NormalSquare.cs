using TheGooseGame.Interfaces;

namespace TheGooseGame.Square
{
    internal class NormalSquare : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.IsInNormalSquare = true;
        }
    }
}