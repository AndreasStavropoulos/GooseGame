namespace TheGooseGame.Square
{
    public class Well : NormalSquare
    {
        public Well(int id) : base(id)
        {

        }

        public override void Action(IPlayer player)
        {
            player.IsInWell = true;
        }
    }
}