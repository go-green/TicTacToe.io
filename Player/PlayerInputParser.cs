using System.Collections.Generic;
using System.Linq;
using TicTacToe.Board;
using TicTacToe.Game;
using TicTacToeGame.Player;
using TicTacToeGame.Player.Contracts;

namespace TicTacToe.Player
{
    public class PlayerInputParser
    {
        private readonly Grid _grid;
        private readonly string _playerInput;
        private readonly IList<IInputValidationRule> _playerInputValidationRules;

        public PlayerInputParser(string inputstring)
        {
            _playerInput = inputstring;
            _playerInputValidationRules = new List<IInputValidationRule>();
            InitializeUserInputValidationRules();
        }

        private void InitializeUserInputValidationRules()
        {
            _playerInputValidationRules.Add(new NullChecker(_playerInput));
            _playerInputValidationRules.Add(new SkippCodeChecker(_playerInput));
            _playerInputValidationRules.Add(new InputParser(_playerInput));
            _playerInputValidationRules.Add(new InputLengthChecker(_playerInput));
            _playerInputValidationRules.Add(new CordinateValidator(_playerInput));
            _playerInputValidationRules.Add(new CordinatePositionValidator(_playerInput));
            _playerInputValidationRules.Add(new GridScanner(_playerInput));
            _playerInputValidationRules.Add(new ValidCordinateUpdator(_playerInput));
        }

        public IMoveResult Parse()
        {
            return _playerInputValidationRules
                .OrderBy(x => x.RuleID)
                .Select(x => x.Validate())
                .FirstOrDefault(x => x.Status != LastMoveStatus.NoPlay);
        }
    }
}