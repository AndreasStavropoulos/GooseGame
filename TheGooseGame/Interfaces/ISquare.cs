namespace TheGooseGame.Square
{
    public interface ISquare
    {
        public int Id { get; set; }

        void Action(IPlayer player);
    }
}