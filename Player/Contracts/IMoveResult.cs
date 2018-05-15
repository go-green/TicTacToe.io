using TicTacToe.Board;
using TicTacToe.Game;

namespace TicTacToe.Player
{
    public interface IMoveResult
    {
        string Message { get; set; }
        Cordinate Cordinate { get; set; }
        LastMoveStatus Status { get; set; }
    }
}