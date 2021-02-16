using System.Collections.Generic;

namespace TheGooseGame
{
    public interface IDice
    {
        List<int> Throw(int dice = 2);
    }
}