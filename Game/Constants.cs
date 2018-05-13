

namespace TicTacToeGame.Game
{
    public static class Constants
    {
        public const char DOT = '*';
        public const string GIVEUPCODE = "q";
        public const int GRID_HEIGHT = 3;
        public const int GRID_WIDTH = 3;
        public const int MAX_ATTEMPT_COUNT = 3;
        public static readonly string CURRENTBOARD = $"Here's the current board:";
        public static readonly string POSITIONOCCUPIED = $"Oh no, a piece is already at this place! Try again...";
        public static readonly string MOVEACCEPTED = $"Move accepted, {CURRENTBOARD}";
        public static readonly string WELCOME = $"Welcome to Tic Tac Toe!";
        public static readonly string YOUWON = $"Move accepted, well done you've won the game!";
        public static readonly char PLAYER_O = 'O';
        public static readonly char PLAYER_X = 'X';
        public static readonly string INVALIDCORDINATES = "Invalid cordinates provided, Please try again!";
        public static readonly string ENTERCORDINATES = "Player {0} enter a coord x,y to place your {1} or enter 'q' to give up:";
    }
}
