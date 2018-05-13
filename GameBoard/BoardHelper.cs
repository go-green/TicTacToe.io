
using System.Collections.Generic;

namespace TicTacToe.Board
{
    public static class BoardHelper
    {
        public static IList<Cordinate> InitializeGrid(int _length,int _height,char symbol)
        {
            var cordinates = new List<Cordinate>();
            for (var i = 1; i <= _length; i++)
            {
                for (var j = 1; j <= _height; j++)
                {
                    var cord = new Cordinate(i, j, symbol) {IsOccupied = false};
                    cordinates.Add(cord);
                }
            }
            return cordinates;
        }
    }
}
