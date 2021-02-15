namespace TheGooseGame.Square
{
    internal class Death : NormalSquare
    {
        public override void Action(IPlayer player)
        {
            player.Position = 0;
        }

        public Death(int id) : base(id)
        {

        }
    }
}