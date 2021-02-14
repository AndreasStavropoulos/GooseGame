using TheGooseGame.Interfaces;

namespace TheGooseGame.Square
{
    internal class Bridge : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.Position = 12;
        }
    }
}