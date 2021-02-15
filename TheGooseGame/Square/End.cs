namespace TheGooseGame.Square
{
    internal class End : NormalSquare
    {
        public override void Action(IPlayer player)
        {
            player.PlayerWon = true;
        }

        public End(int id) : base(id)
        {

        }
    }
}