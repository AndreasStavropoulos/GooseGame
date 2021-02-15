namespace TheGooseGame.Square
{
    public class Prison : NormalSquare
    {
        public Prison(int id) : base(id)
        {

        }

        public override void Action(IPlayer player)
        {
            if (player.TurnsToStayStill == 0)
            {
                player.TurnsToStayStill = 3;
            }
            else
            {
                player.TurnsToStayStill--;
            }
        }
    }
}