using System;
using System.Linq;
using NLog;
using TicTacToe.Game;
using TicTacToe.Player;
using TicTacToeGame.Game;
using TicTacToeGame.Player.Contracts;

namespace TicTacToeGame.Player
{
    public class NullChecker : IInputValidationRule
    {
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public NullChecker(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.NoPlay};
        }

        public int RuleID => 1;

        public IMoveResult Validate()
        {
            if (!string.IsNullOrEmpty(_playerInput)) return _moveResult;
            _moveResult.Message = Constants.INVALIDCORDINATES;
            _moveResult.Status = LastMoveStatus.InvalidCordinates;
            return _moveResult;
        }
    }

    public class SkippCodeChecker : IInputValidationRule
    {
        public const string SKIPPEDPCODE = "q";
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public SkippCodeChecker(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.NoPlay};
        }

        public int RuleID => 2;

        public IMoveResult Validate()
        {
            if (!_playerInput.ToLower().Trim().Equals(SKIPPEDPCODE)) return _moveResult;
            _moveResult.Status = LastMoveStatus.Skipped;
            return _moveResult;
        }
    }

    public class InputParser : IInputValidationRule
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public InputParser(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.NoPlay};
        }

        public int RuleID => 3;

        public IMoveResult Validate()
        {
            string[] cordsAsArray;
            try
            {
                cordsAsArray = _playerInput.Split(',');
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.StackTrace);
                _moveResult.Message = Constants.INVALIDCORDINATES;
                _moveResult.Status = LastMoveStatus.InvalidCordinates;
                return _moveResult;
            }

            return _moveResult;
        }
    }

    public class InputLengthChecker : IInputValidationRule
    {
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public InputLengthChecker(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.NoPlay};
        }

        public int RuleID => 4;

        public IMoveResult Validate()
        {
            if (_playerInput.Split(',').Length == 2) return _moveResult;
            _moveResult.Message = Constants.INVALIDCORDINATES;
            _moveResult.Status = LastMoveStatus.InvalidCordinates;
            return _moveResult;
        }
    }


    public class CordinateValidator : IInputValidationRule
    {
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public CordinateValidator(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.NoPlay};
        }

        public int RuleID => 5;

        public IMoveResult Validate()
        {
            var cordsAsArray = _playerInput.Split(',');
            if (!int.TryParse(cordsAsArray[0], out var x))
            {
                _moveResult.Message = Constants.INVALIDCORDINATES;
                _moveResult.Status = LastMoveStatus.InvalidCordinates;
                return _moveResult;
            }

            if (!int.TryParse(cordsAsArray[1], out var y))
            {
                _moveResult.Message = Constants.INVALIDCORDINATES;
                _moveResult.Status = LastMoveStatus.InvalidCordinates;
                return _moveResult;
            }

            if (x >= 1 && y >= 1 && y <= Constants.GRID_HEIGHT && x <= Constants.GRID_WIDTH) return _moveResult;
            _moveResult.Message = Constants.INVALIDCORDINATES;
            _moveResult.Status = LastMoveStatus.InvalidCordinates;
            return _moveResult;
        }
    }

    public class CordinatePositionValidator : IInputValidationRule
    {
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public CordinatePositionValidator(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.NoPlay};
        }

        public int RuleID => 7;

        public IMoveResult Validate()
        {
            var cordsAsArray = _playerInput.Split(',');
            int.TryParse(cordsAsArray[0], out var x);
            int.TryParse(cordsAsArray[1], out var y);

            if (GameStatus.Instance.Grid.Cordinates.Single(_grid => _grid.X == x && _grid.Y == y).IsOccupied)
            {
                _moveResult.Message = Constants.POSITIONOCCUPIED;
                _moveResult.Status = LastMoveStatus.PositionOccupied;
                return _moveResult;
            }

            return _moveResult;
        }
    }

    public class GridScanner : IInputValidationRule
    {
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public GridScanner(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.NoPlay};
        }

        public int RuleID => 6;

        public IMoveResult Validate()
        {
            if (GameStatus.Instance.Grid.Cordinates.Count(cord => cord.IsOccupied == false) == 0)
            {
                GameStatus.Instance.Draw = true;
                _moveResult.Status = LastMoveStatus.AllPositionsOccupied;
                return _moveResult;
            }

            return _moveResult;
        }
    }

    public class ValidCordinateUpdator : IInputValidationRule
    {
        private readonly IMoveResult _moveResult;
        private readonly string _playerInput;

        public ValidCordinateUpdator(string input)
        {
            _playerInput = input;
            _moveResult = new MoveResult {Status = LastMoveStatus.InvalidCordinates};
            _moveResult.Status = LastMoveStatus.InvalidCordinates;
            _moveResult.Message = Constants.INVALIDCORDINATES;
        }

        public int RuleID => 8;

        public IMoveResult Validate()
        {
            var cordsAsArray = _playerInput.Split(',');
            int.TryParse(cordsAsArray[0], out var x);
            int.TryParse(cordsAsArray[1], out var y);
            if (x > Constants.GRID_WIDTH || y > Constants.GRID_HEIGHT) return _moveResult;
            _moveResult.Message = Constants.MOVEACCEPTED;
            _moveResult.Status = LastMoveStatus.Accepted;
            _moveResult.Cordinate.X = x;
            _moveResult.Cordinate.Y = y;
            return _moveResult;
        }
    }
}