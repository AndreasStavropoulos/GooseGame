using TheGooseGame.Intefaces;

namespace TheGooseGame.Square
{
    public class Bridge : MySquare
    {
        public override void Action(IPlayer player)
        {
            player.Position = 12;
        }
    }
}