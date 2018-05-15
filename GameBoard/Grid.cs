

using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Game;
using TicTacToeGame.Game;

namespace TicTacToe.Board
{
    /// <summary>
    /// Grid is a wrapper class that caters to SquareGrid class
    /// </summary>
    public class Grid 
    {
        private readonly IList<Cordinate> _cordinates;
        private readonly Rules.GameRules _ruleses;


        public Grid(IList<Cordinate> cordinates)
        {
            this._cordinates = cordinates;
            this._ruleses = new Rules.GameRules();
        }

        public IList<Cordinate> Cordinates => _cordinates;

        public bool IsOccupied(Cordinate cords)
        {
            return this._cordinates.Single(x => x.X == cords.X && x.Y == cords.Y).IsOccupied;
        }

        public void Update(Cordinate cords)
        {
            if (!IsOccupied(cords))
            {
                UpdateGridStatus(cords);
                UpdateCurrentPlayerStatus(cords);
            }
        }

        private void UpdateCurrentPlayerStatus(Cordinate cords)
        {
            GameStatus.Instance.CurrentPlayer.MoveCount++;
            GameStatus.Instance.CurrentPlayer.OccupiedPositions.Add(cords);
        }


        private void UpdateGridStatus(Cordinate cords)
        {
            var cordinate = this._cordinates.Single(x => x.X == cords.X && x.Y == cords.Y);
            cordinate.IsOccupied = true;
            cordinate.Symbol = GameStatus.Instance.CurrentPlayer.Symbol;
        }


        public void Scan()
        {
            if (this._ruleses.Validate(GameStatus.Instance.CurrentPlayer.OccupiedPositions))
            {
                GameStatus.Instance.Finished = true;
            }
        }

        public void Draw()
        {
            var rows = Cordinates.GroupBy(g => g.X);
            foreach (var row in rows)
            {
                foreach (var cordinate in row.Select(c => c))
                {
                    Console.Write($"{cordinate.Symbol} ");
                }
                Console.WriteLine();
            }
        }
    }
}
