
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Board;
using TicTacToe.Rule;
using TicTacToeGame.Game;

namespace TicTacToe.Rules
{
    /// <summary>
    /// This class holds all the winning cordinate set permutaions and compare the player inputs
    /// to see if player line matches any of the winning cordinate set.
    /// </summary>
    public class GameRules : IGameRule
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private IEnumerable<CordinateSet> _winningCordinateSets;
        private IEnumerable<Cordinate> _userCordinates;
        public const int MAX_ATTEMPT_COUNT = 3;

        public GameRules()
        {
            this._winningCordinateSets = new SquareWinningCordinateSetGenerator().GetWinningCordinateSetPermutations();           
        }

        public bool Validate(IEnumerable<Cordinate> userCordinates)
        {
            this._userCordinates = userCordinates;
            return _winningCordinateSets.Any(x => CompareWithPlayerCordinates(x.Get()));
        }

        /// <summary>
        /// Compare user cordinate set to a winning cordinate set and return true
        /// if all cordinates are equal
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        private bool CompareWithPlayerCordinates(IEnumerable<Cordinate> enumerable)
        {
            var returnFlag = true;
            var orderedWinningSet = enumerable.OrderBy(x => x.X).ThenBy(y => y.Y).ToArray();
            var orderedPlayerSet = _userCordinates.OrderBy(x => x.X).ThenBy(y => y.Y).ToArray();

            if (orderedWinningSet.Count() != orderedPlayerSet.Count())
                return false;

            for (var i = 0; i < MAX_ATTEMPT_COUNT; i++)
            {
                try
                {
                    var match = orderedWinningSet[i].X == orderedPlayerSet[i].X &&
                                orderedWinningSet[i].Y == orderedPlayerSet[i].Y;
                    if (!match)
                        returnFlag = false;
                }
                catch (Exception e)
                {
                    logger.Error(e.StackTrace);
                }
                
            }
            return returnFlag;
        }
    }
}
