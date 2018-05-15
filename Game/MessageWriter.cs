using System;
using TicTacToeGame.Game;

namespace TicTacToe.Game
{
    public static class MessageWriter
    {
        public static void Greet()
        {
            Console.WriteLine(Constants.WELCOME);
            Console.WriteLine(Constants.CURRENTBOARD);
        }

        public static void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}