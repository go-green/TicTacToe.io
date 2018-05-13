using System;
using System.Linq;
using TicTacToe.Game;
using TicTacToeGame.GameBoard;

namespace TicTacToe.Board
{
    public class SquareBoard : IGameBoard
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly Grid _grid;
        private readonly int _height;
        private readonly int _length;

        public SquareBoard()
        {
            this._grid = GameStatus.Instance.Grid;
        }

        public void Draw()
        {
            var rows = _grid.Cordinates.GroupBy(g => g.X);
            foreach (var row in rows)
            {
                foreach (var cordinate in row.Select(c => c))
                {
                    Console.Write($"{cordinate.Symbol} ");
                }
                Console.WriteLine();
            }
        }

        public void Update(ICordinate cords)
        {
            try
            {
                _grid.Update(cords);
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        // TODO:If we extend the game so that players can play multiple games in the same session, we need to reset the board
        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Scan()
        {
            try
            {
                _grid.Scan();
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }

        }
    }
}
