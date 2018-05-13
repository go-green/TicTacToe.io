using System;
using System.Collections.Generic;
using TicTacToe.Board;
using TicTacToe.Game;
using TicTacToe.Player;
using TicTacToeGame.Game;
using TicTacToeGame.GameBoard;

namespace TicTacToe.Player
{
    public class ManualPlayer : IPlayer
    {
        public int Id { get; set; }
        public char Symbol { get; set; }
        public string Name { get; set; }
        public int MoveCount { get; set; }
        public IList<ICordinate> OccupiedPositions { get; set; }

        public ManualPlayer()
        {
            OccupiedPositions = new List<ICordinate>();
        }
        public string Move()
        {
            MessageWriter.WriteToConsole(string.Format(Constants.ENTERCORDINATES, this.Id, this.Symbol));
            return Console.ReadLine();
        }
    }
}
