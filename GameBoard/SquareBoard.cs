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

        public SquareBoard()
        {
            this._grid = GameStatus.Instance.Grid;
        }

        public void Draw()
        {
            try
            {
                _grid.Draw();
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
           
        }

        public void Update(Cordinate cords)
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
