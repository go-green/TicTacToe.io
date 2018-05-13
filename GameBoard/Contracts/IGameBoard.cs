using TicTacToe.Board;

namespace TicTacToeGame.GameBoard
{
    interface IGameBoard
    {
        void Draw();
        void Update(ICordinate cords);
        void Reset();
        void Scan();
    }
}
