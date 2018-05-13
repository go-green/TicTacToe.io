
using System.Collections.Generic;
using TicTacToeGame.GameBoard;
using System.Linq;
using TicTacToe.Board;

namespace TicTacToe.Rules
{
    public class CordinateSet
    {
        private readonly IList<ICordinate> _line;

        public CordinateSet()
        {
            this._line = new List<ICordinate>();
        }

        public void Add(ICordinate cords)
        {
            _line.Add(cords);
        }

        public IEnumerable<ICordinate> Get()
        {
            return _line;
        }
    }
}
