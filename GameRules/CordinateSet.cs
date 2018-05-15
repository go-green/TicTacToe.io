
using System.Collections.Generic;
using TicTacToeGame.GameBoard;
using System.Linq;
using TicTacToe.Board;

namespace TicTacToe.Rules
{
    public class CordinateSet
    {
        private readonly IList<Cordinate> _line;

        public CordinateSet()
        {
            this._line = new List<Cordinate>();
        }

        public void Set(Cordinate cords)
        {
            _line.Add(cords);
        }

        public IEnumerable<Cordinate> Get()
        {
            return _line;
        }
    }
}
