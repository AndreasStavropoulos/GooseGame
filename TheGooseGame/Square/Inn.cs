using TheGooseGame.Interfaces;

namespace TheGooseGame.Square
{
    internal class Inn : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.IsInInn = true;
        }
    }
}