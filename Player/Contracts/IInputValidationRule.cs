using TicTacToe.Player;

namespace TicTacToeGame.Player.Contracts
{
    internal interface IInputValidationRule
    {
        int RuleID { get; }
        IMoveResult Validate();
    }
}