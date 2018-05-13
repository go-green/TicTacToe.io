

using TicTacToe.Board;
using TicTacToe.Game;

namespace TicTacToe.Player
{
    public class MoveResult 
    {
        public string Message { get; set; }
        public ICordinate Cordinate { get; set; }
        public LastMoveStatus Status { get; set; }

        public MoveResult()
        {
            Cordinate = new Cordinate();
            Status = new LastMoveStatus();
        }
    }
}
