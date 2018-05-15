

namespace TicTacToeGame.Game
{
    public static class Constants
    {
        public const char DOT = '*';
        public const int GRID_HEIGHT = 3;
        public const int GRID_WIDTH = 3;
        public const int MAX_ATTEMPT_COUNT = 3;
        public const string CURRENTBOARD = "Here's the current board:";
        public const string POSITIONOCCUPIED = "Oh no, a piece is already at this place! Try again...";
        public const string MOVEACCEPTED = "Move accepted, Here's the current board:";
        public const string WELCOME = "Welcome to Tic Tac Toe!";
        public const string YOUWON = "Move accepted, well done you've won the game!";
        public const char PLAYER_O = 'O';
        public const char PLAYER_X = 'X';
        public const string INVALIDCORDINATES = "Invalid cordinates provided, Please try again!";
        public const string ENTERCORDINATES = "Player {0} enter a coord x,y to place your {1} or enter 'q' to give up:";
    }
}
