
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Board;
using TicTacToeGame.Game;

namespace TicTacToe.Rules
{
    /// <summary>
    /// Class to generate winning cordinate sets for squares
    /// Logic to get the diagonals only works for squares and not for rectangles
    /// </summary>
    public class SquareWinningCordinateSetGenerator
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<CordinateSet> GetWinningCordinateSetPermutations()
        {
            var lines = new List<CordinateSet>();
            try
            {
                lines.AddRange(GetRowCordinateSets());
                lines.AddRange(GetColumnCordinateSets());
                lines.Add(GetLeftDiagonal());
                lines.Add(GetRightDiagonal());
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
            return lines;
        }


        public IEnumerable<CordinateSet> GetRowCordinateSets()
        {
            return Enumerable.Range(1, Constants.GRID_WIDTH).Select(rowNumber => GetRowCordinates(rowNumber));


        }

        public IEnumerable<CordinateSet> GetColumnCordinateSets()
        {
            return Enumerable.Range(1, Constants.GRID_HEIGHT).Select(columnNumber => GetColumnCordinates(columnNumber));
        }

        public CordinateSet GetRowCordinates(int rowNumber)
        {
            var winningCordinates = new CordinateSet();
            for (var c = 1; c <= Constants.GRID_WIDTH; c++)
            {
                var cords = new Cordinate
                {
                    X = rowNumber,
                    Y = c
                };
                winningCordinates.Set(cords);
            }
            return winningCordinates;
        }

        public CordinateSet GetColumnCordinates(int columnNumber)
        {
            var winningCordinates = new CordinateSet();
            for (var r = 1; r <= Constants.GRID_HEIGHT; r++)
            {
                var cords =
                    new Cordinate
                    {
                        X = r,
                        Y = columnNumber
                    };
                winningCordinates.Set(cords);
            }
            return winningCordinates;
        }

        /// <summary>
        /// Get the rows and select the cordinates that make a backward(\) diagonal
        /// </summary>
        /// <returns></returns>
        public CordinateSet GetLeftDiagonal()
        {
            var rowCounter = 0;
            var winningCordinates = new CordinateSet();
            foreach (var set in GetRowCordinateSets())
            {
                var cords = set.Get().ToArray()[rowCounter];
                rowCounter++;
                winningCordinates.Set(cords);
            }
            return winningCordinates;
        }


        /// <summary>
        /// Get the rows and select the cordinates that make a forward(/) diagonal
        /// </summary>
        /// <returns></returns>
        public CordinateSet GetRightDiagonal()
        {
            var rowCounter = Constants.GRID_WIDTH - 1;
            var winningCordinates = new CordinateSet();
            foreach (var set in GetRowCordinateSets())
            {
                var cords = set.Get().ToArray()[rowCounter];
                rowCounter--;
                winningCordinates.Set(cords);
            }
            return winningCordinates;
        }
    }
}
