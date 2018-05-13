using System;
using System.Collections.Generic;
using TicTacToe.Player;
using TicTacToeGame.Game;

namespace TicTacToe.Player
{
    public static class PlayerHelper
    {
        public static IEnumerable<IPlayer> InitializePlayers()
        {
            return new List<IPlayer>()
            {
                new ManualPlayer()
                {
                    Id = 1,
                    Symbol = Constants.PLAYER_X
                },
                new ManualPlayer()
                {
                    Id = 2,
                    Symbol = Constants.PLAYER_O
                }
            };
        }
    }
}
