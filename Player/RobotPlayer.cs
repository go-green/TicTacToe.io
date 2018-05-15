using System;
using System.Collections.Generic;
using TicTacToe.Board;

namespace TicTacToe.Player
{
    public class RobotPlayer : IPlayer
    {
        public int Id { get; set; }
        public char Symbol { get; set; }
        public string Name { get; set; }
        public int MoveCount { get; set; }
        public IList<Cordinate> OccupiedPositions { get; set; }

        public string Move()
        {
            throw new NotImplementedException();
        }
    }
}
