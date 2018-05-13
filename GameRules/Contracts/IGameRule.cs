

using System.Collections.Generic;
using TicTacToe.Board;

namespace TicTacToe.Rule
{
    public interface IGameRule
    {
        bool Validate(IEnumerable<ICordinate> cordinates);
    }
}
