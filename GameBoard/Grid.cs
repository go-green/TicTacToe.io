using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Game;
using TicTacToe.Rules;

namespace TicTacToe.Board
{
    /// <summary>
    ///     Grid is a wrapper class that caters to SquareGrid class
    /// </summary>
    public class Grid
    {
        private readonly GameRules _ruleses;


        public Grid(IList<Cordinate> cordinates)
        {
            Cordinates = cordinates;
            _ruleses = new GameRules();
        }

        public IList<Cordinate> Cordinates { get; }

        public bool IsOccupied(Cordinate cords)
        {
            return Cordinates.Single(x => x.X == cords.X && x.Y == cords.Y).IsOccupied;
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
            var cordinate = Cordinates.Single(x => x.X == cords.X && x.Y == cords.Y);
            cordinate.IsOccupied = true;
            cordinate.Symbol = GameStatus.Instance.CurrentPlayer.Symbol;
        }


        public void Scan()
        {
            if (_ruleses.Validate(GameStatus.Instance.CurrentPlayer.OccupiedPositions))
            {
                GameStatus.Instance.Finished = true;
                return;
            }

            if (GameStatus.Instance.Grid.Cordinates.Count(cord => cord.IsOccupied == false) == 0)
                GameStatus.Instance.Draw = true;
        }

        public void Draw()
        {
            var rows = Cordinates.GroupBy(g => g.X);
            foreach (var row in rows)
            {
                foreach (var cordinate in row.Select(c => c)) Console.Write($"{cordinate.Symbol} ");
                Console.WriteLine();
            }
        }
    }
}