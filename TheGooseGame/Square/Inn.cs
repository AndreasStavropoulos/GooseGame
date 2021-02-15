namespace TheGooseGame.Square
{
    public class Inn : NormalSquare
    {
        public Inn(int id) : base(id)
        {

        }

        public override void Action(IPlayer player)
        {
            player.TurnsToStayStill++;
        }
    }
}