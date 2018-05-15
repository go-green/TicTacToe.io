using System;
using System.Collections.Generic;
using TicTacToe.Player;
using TicTacToeGame.Game;

namespace TicTacToe.Player
{
    public static class PlayerHelper
    {
        public const char PLAYER_O = 'O';
        public const char PLAYER_X = 'X';
        public static IEnumerable<IPlayer> InitializePlayers()
        {
            return new List<IPlayer>()
            {
                new ManualPlayer()
                {
                    Id = 1,
                    Symbol = PLAYER_X
                },
                new ManualPlayer()
                {
                    Id = 2,
                    Symbol = PLAYER_O
                }
            };
        }
    }
}
