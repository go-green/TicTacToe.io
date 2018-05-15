using System.Collections.Generic;
using TicTacToe.Board;

namespace TicTacToe.Player
{
    public interface IPlayer
    {
        int Id { get; set; }
        char Symbol { get; set; }
        string Name { get; set; }
        int MoveCount { get; set; }
        IList<Cordinate> OccupiedPositions { get; set; }
        string Move();
    }
}