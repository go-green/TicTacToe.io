using TicTacToe.Board;
using TicTacToe.Game;

namespace TicTacToe.Player
{
    public class MoveResult : IMoveResult
    {
        public MoveResult()
        {
            Cordinate = new Cordinate();
            Status = new LastMoveStatus();
        }

        public string Message { get; set; }
        public Cordinate Cordinate { get; set; }
        public LastMoveStatus Status { get; set; }
    }
}