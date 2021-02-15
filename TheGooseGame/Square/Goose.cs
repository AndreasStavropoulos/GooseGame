namespace TheGooseGame.Square
{
    public class Goose : NormalSquare
    {

        public Goose(int id) : base(id)
        {

        }

        public override void Action(IPlayer player)
        {
            player.IsOnGoose = true;
            if (player.IsInReverse == true)
            {
                player.Position -= player.SumOfDices();
            }
            else
            {
                player.Position += player.SumOfDices();
            }
        }
    }
}