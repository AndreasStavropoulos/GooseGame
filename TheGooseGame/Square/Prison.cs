using TheGooseGame.Interfaces;

namespace TheGooseGame.Square
{
    internal class Prison : MySquare
    {
        public override void Action(IPlayer player)
        {
            if (player.PrisonYearsLeft == 0)
            {
                player.PrisonYearsLeft = 3;
            }
            else
            {
                player.PrisonYearsLeft--;
            }
        }
    }
}