using System.Collections.Generic;
using System.Linq;
using NLog;
using TicTacToe.Board;
using TicTacToe.Rule;

namespace TicTacToe.Rules
{
    /// <summary>
    ///     This class holds all the winning cordinate set permutaions and compare the player inputs
    ///     to see if player line matches any of the winning cordinate set.
    /// </summary>
    public class GameRules : IGameRule
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IEnumerable<Cordinate> _userCordinates;
        private readonly IEnumerable<CordinateSet> _winningCordinateSets;

        public GameRules()
        {
            _winningCordinateSets = new SquareWinningCordinateSetGenerator().GetWinningCordinateSetPermutations();
        }

        public bool Validate(IEnumerable<Cordinate> userCordinates)
        {
            _userCordinates = userCordinates;
            return _winningCordinateSets.Any(x => CompareWithPlayerCordinates(x.Get()));
        }

        /// <summary>
        ///     Compare user cordinate set to a winning cordinate set and return true
        ///     if all cordinates are equal
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        private bool CompareWithPlayerCordinates(IEnumerable<Cordinate> enumerable)
        {
            var returnFlag = true;
            var orderedWinningSet = enumerable.OrderBy(x => x.X).ThenBy(y => y.Y).ToArray();
            var orderedPlayerSet = _userCordinates.OrderBy(x => x.X).ThenBy(y => y.Y).ToArray();

            foreach (var winningSet in orderedWinningSet)
            {
                var match = orderedPlayerSet.Any(x => x.X == winningSet.X && x.Y == winningSet.Y);
                if (!match)
                    returnFlag = false;
            }

            return returnFlag;
        }
    }
}