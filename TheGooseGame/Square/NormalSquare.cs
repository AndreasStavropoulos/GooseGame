using TheGooseGame.Interfaces;

namespace TheGooseGame.Square
{
    internal class NormalSquare : MySquare
    {
        public int Id { get; set; }
        public ISquare Square { get; set; }

        public override void Action(IPlayer player)
        {
            player.IsInNormalSquare = true;
        }

        public NormalSquare(int id)
        {
            Id = id;
        }
    }
}