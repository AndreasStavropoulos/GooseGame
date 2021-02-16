namespace TheGooseGame.Square
{
    public class Goose : NormalSquare
    {

        public Goose(int id) : base(id)
        {

        }

        public override void Action(IPlayer player)
        {
            if (player.IsInReverse)
            {
                player.Position -= player.AmountOFDice;
                while (player.IsInReverse && player.Position == 59 || player.IsInReverse && player.Position == 54)
                {
                    player.Position -= player.AmountOFDice;
                }
                player.IsInReverse = false;
            }
            else
            {
                player.Position += player.AmountOFDice;
            } 
        }
    }
}