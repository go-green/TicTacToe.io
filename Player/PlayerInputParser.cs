

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
        private readonly string _playerInput;
        private readonly Grid _grid;
        private readonly IList<IInputValidationRule> _playerInputValidationRules;

        public PlayerInputParser(string inputstring)
        {
            this._playerInput = inputstring;
            this._playerInputValidationRules = new List<IInputValidationRule>();
            InitializeUserInputValidationRules();
        }

        private void InitializeUserInputValidationRules()
        {
            this._playerInputValidationRules.Add(new NullChecker(this._playerInput));
            this._playerInputValidationRules.Add(new SkippCodeChecker(this._playerInput));
            this._playerInputValidationRules.Add(new InputParser(this._playerInput));
            this._playerInputValidationRules.Add(new InputLengthChecker(this._playerInput));
            this._playerInputValidationRules.Add(new CordinateValidator(this._playerInput));
            this._playerInputValidationRules.Add(new CordinatePositionValidator(this._playerInput));
            this._playerInputValidationRules.Add(new GridScanner(this._playerInput));
            this._playerInputValidationRules.Add(new ValidCordinateUpdator(this._playerInput));
        }

        public IMoveResult Parse()
        {

            return this._playerInputValidationRules
                .OrderBy(x => x.RuleID)
                .Select(x => x.Validate(this._playerInput))
                .FirstOrDefault(x => x.Status != LastMoveStatus.NoPlay);
        }
    }
}
