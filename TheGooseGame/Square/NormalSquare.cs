namespace TheGooseGame.Square
{
    public class NormalSquare : ISquare
    {
        public int Id { get; set; }

        public Square(int id)
        {
            Id = id;
        }

        public virtual void Action(IPlayer player)
        {
            
        }
    }
}