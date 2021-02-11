using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    internal class End : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.PlayerWon = true;
        }
    }
}