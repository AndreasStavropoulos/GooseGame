using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class NormalSquare : ISquare
    {
        public int Id { get; set; }
        public Color BackColor { get; set; }

        public NormalSquare(int id)
        {
            Id = id;
            
        }

        public virtual void Action(IPlayer player)
        {
            
        }
    }
}