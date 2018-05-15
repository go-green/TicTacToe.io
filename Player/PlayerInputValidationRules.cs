using System;
using System.Linq;
using TicTacToe.Game;
using TicTacToe.Player;
using TicTacToeGame.Game;
using TicTacToeGame.Player.Contracts;

namespace TicTacToeGame.Player
{
    public class NullChecker : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        public NullChecker(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.NoPlay };
        }

        public int RuleID
        {
            get => 1;
        }

        public IMoveResult Validate(string input)
        {
            if (!string.IsNullOrEmpty(_playerInput)) return this._moveResult;
            this._moveResult.Message = Constants.INVALIDCORDINATES;
            this._moveResult.Status = LastMoveStatus.InvalidCordinates;
            return this._moveResult;
        }
    }

    public class SkippCodeChecker : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        public const string SKIPPEDPCODE = "q";
        public SkippCodeChecker(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.NoPlay };
        }
        public int RuleID
        {
            get => 2;
        }
        public IMoveResult Validate(string input)
        {
            if (!_playerInput.ToLower().Trim().Equals(SKIPPEDPCODE)) return this._moveResult;
            _moveResult.Status = LastMoveStatus.Skipped;
            return this._moveResult;

        }
    }

    public class InputParser : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public InputParser(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.NoPlay };
        }
        public int RuleID
        {
            get => 3;
        }
        public IMoveResult Validate(string input)
        {
            string[] cordsAsArray;
            try
            {
                cordsAsArray = _playerInput.Split(',');
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.StackTrace);
                this._moveResult.Message = Constants.INVALIDCORDINATES;
                this._moveResult.Status = LastMoveStatus.InvalidCordinates;
                return this._moveResult;
            }
            return this._moveResult;
        }
    }

    public class InputLengthChecker : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        public InputLengthChecker(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.NoPlay };
        }
        public int RuleID
        {
            get => 4;
        }
        public IMoveResult Validate(string input)
        {
            if (_playerInput.Split(',').Length == 2) return this._moveResult;
            this._moveResult.Message = Constants.INVALIDCORDINATES;
            this._moveResult.Status = LastMoveStatus.InvalidCordinates;
            return this._moveResult;
        }
    }


    public class CordinateValidator : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        public CordinateValidator(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.NoPlay };
        }
        public int RuleID
        {
            get => 5;
        }
        public IMoveResult Validate(string input)
        {
            var cordsAsArray = _playerInput.Split(',');
            if (!int.TryParse(cordsAsArray[0], out var x))
            {
                this._moveResult.Message = Constants.INVALIDCORDINATES;
                this._moveResult.Status = LastMoveStatus.InvalidCordinates;
                return _moveResult;
            }

            if (!int.TryParse(cordsAsArray[1], out var y))
            {
                this._moveResult.Message = Constants.INVALIDCORDINATES;
                this._moveResult.Status = LastMoveStatus.InvalidCordinates;
                return _moveResult;
            }

            if (x >= 1 && y >= 1 && y <= Constants.GRID_HEIGHT && x <= Constants.GRID_WIDTH) return _moveResult;
            this._moveResult.Message = Constants.INVALIDCORDINATES;
            this._moveResult.Status = LastMoveStatus.InvalidCordinates;
            return _moveResult;
        }
    }

    public class CordinatePositionValidator : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        public CordinatePositionValidator(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.NoPlay };
        }
        public int RuleID
        {
            get => 6;
        }
        public IMoveResult Validate(string input)
        {
            var cordsAsArray = _playerInput.Split(',');
            int.TryParse(cordsAsArray[0], out var x);
            int.TryParse(cordsAsArray[1], out var y);

            if (GameStatus.Instance.Grid.Cordinates.Single(_grid => _grid.X == x && _grid.Y == y).IsOccupied)
            {
                this._moveResult.Message = Constants.POSITIONOCCUPIED;
                this._moveResult.Status = LastMoveStatus.PositionOccupied;
                return this._moveResult;
            }
            return this._moveResult;
        }
    }

    public class GridScanner : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        public const string ALLPOSITIONSOCCUPIED = "Oh no, All positions occupied...No more moves and the game draws!";
        public GridScanner(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.NoPlay };

        }
        public int RuleID
        {
            get => 7;
        }
        public IMoveResult Validate(string input)
        {
            if (GameStatus.Instance.Grid.Cordinates.Count(cord => cord.IsOccupied == false) == 0)
            {
                GameStatus.Instance.Finished = true;
                this._moveResult.Message = ALLPOSITIONSOCCUPIED;
                this._moveResult.Status = LastMoveStatus.AllPositionsOccupied;
                return this._moveResult;
            }
            return this._moveResult;
        }
    }

    public class ValidCordinateUpdator : IInputValidationRule
    {
        private readonly string _playerInput;
        private readonly IMoveResult _moveResult;
        public ValidCordinateUpdator(string input)
        {
            this._playerInput = input;
            this._moveResult = new MoveResult() { Status = LastMoveStatus.InvalidCordinates };
            this._moveResult.Status = LastMoveStatus.InvalidCordinates;
            this._moveResult.Message = Constants.INVALIDCORDINATES;

        }
        public int RuleID
        {
            get => 8;
        }
        public IMoveResult Validate(string input)
        {
            var cordsAsArray = _playerInput.Split(',');
            int.TryParse(cordsAsArray[0], out var x);
            int.TryParse(cordsAsArray[1], out var y);
            if (x > Constants.GRID_WIDTH || y > Constants.GRID_HEIGHT) return this._moveResult;
            this._moveResult.Message = Constants.MOVEACCEPTED;
            this._moveResult.Status = LastMoveStatus.Accepted;
            this._moveResult.Cordinate.X = x;
            this._moveResult.Cordinate.Y = y;
            return this._moveResult;
        }
    }
}
