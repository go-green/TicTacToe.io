using System;
using System.Collections.Generic;
using TicTacToe.Board;
using TicTacToe.Game;
using TicTacToeGame.Game;

namespace TicTacToe.Player
{
    public class ManualPlayer : IPlayer
    {
        public ManualPlayer()
        {
            OccupiedPositions = new List<Cordinate>();
        }

        public int Id { get; set; }
        public char Symbol { get; set; }
        public string Name { get; set; }
        public int MoveCount { get; set; }
        public IList<Cordinate> OccupiedPositions { get; set; }

        public string Move()
        {
            MessageWriter.WriteToConsole(string.Format(Constants.ENTERCORDINATES, Id, Symbol));
            return Console.ReadLine();
        }
    }
}