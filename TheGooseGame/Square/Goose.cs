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
                player.Position -= player.AmountOFDice; 
            }
            else
            {
                player.Position += player.AmountOFDice;
            }
        }
    }
}