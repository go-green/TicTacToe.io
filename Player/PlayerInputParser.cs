
using System;
using System.Linq;
using TicTacToe.Board;
using TicTacToe.Game;
using TicTacToeGame.Game;


namespace TicTacToe.Player
{
    public class PlayerInputParser
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly string _playerInput;
        private readonly MoveResult _moveResult;
        private readonly Grid _grid;
        private readonly string _inputString;

        public PlayerInputParser(string inputstring)
        {
            this._playerInput = inputstring;
            this._moveResult = new MoveResult();
            this._inputString = inputstring;
        }

        public MoveResult Parse()
        {
            if (string.IsNullOrEmpty(_playerInput))
            {
                InvalidInput();
                return _moveResult;
            }

            if (_playerInput.ToLower().Trim().Equals(Constants.GIVEUPCODE))
            {
                _moveResult.Status = LastMoveStatus.Skipped;
                return _moveResult;
            }

            string[] cordsAsArray;
            try
            {
                cordsAsArray = _playerInput.Split(',');
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.StackTrace);
                InvalidInput();
                return _moveResult;
            }

            if (cordsAsArray.Length != 2)
            {
                InvalidInput();
                return _moveResult;
            }

            if (!int.TryParse(cordsAsArray[0], out var x))
            {
                InvalidInput();
                return _moveResult;
            }

            if (!int.TryParse(cordsAsArray[1], out var y))
            {
                InvalidInput();
                return _moveResult;
            }

            if (x < 1 || y < 1 || y > Constants.GRID_HEIGHT || x > Constants.GRID_WIDTH)
            {
                InvalidInput();
                return _moveResult;
            }

            if (GameStatus.Instance.Grid.Cordinates.Single(_grid => _grid.X == x && _grid.Y == y).IsOccupied)
            {
                _moveResult.Message = Constants.POSITIONOCCUPIED;
                _moveResult.Status = LastMoveStatus.PositionOccupied;
                return _moveResult;
            }

            if (x <= Constants.GRID_WIDTH && y <= Constants.GRID_HEIGHT)
            {
                _moveResult.Message = Constants.MOVEACCEPTED;
                _moveResult.Status = LastMoveStatus.Accepted;
                _moveResult.Cordinate.X = x;
                _moveResult.Cordinate.Y = y;
                return _moveResult;
            }

            InvalidInput();
            return _moveResult;
        }

        private void InvalidInput()
        {
            logger.Info($"Invalid Cordinates Entered {_inputString}");
            _moveResult.Message = Constants.INVALIDCORDINATES;
            _moveResult.Status = LastMoveStatus.InvalidCordinates;
            _moveResult.Cordinate = null;
        }
    }
}
