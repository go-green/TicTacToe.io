using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Player;

namespace TicTacToeGame.Player.Contracts
{
    interface IInputValidationRule
    {
        int RuleID { get; }
        IMoveResult Validate(string input);
    }
}
