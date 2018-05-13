
using System.Collections.Generic;
using TicTacToe.Board;
using TicTacToe.Player;
using TicTacToeGame.GameBoard;

namespace TicTacToe.Game
{
    /// <summary>
    /// Singleton class to hold the current status of the game
    /// </summary>
    public class GameStatus
    {
        private static readonly GameStatus instance = new GameStatus();

        static GameStatus()
        {
        }

        private GameStatus()
        {
        }

        public static GameStatus Instance
        {
            get
            {
                return instance;
            }
        }

        public IPlayer CurrentPlayer { get; set; }

        public IEnumerable<IPlayer> Players { get; set; }

        public bool Finished { get; set; }

        public Grid Grid { get; set; }
    }
}
