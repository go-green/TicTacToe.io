namespace TicTacToe.Board
{
    public class Cordinate
    {
        public Cordinate()
        {
        }

        public Cordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Cordinate(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public int X { set; get; }

        public int Y { set; get; }

        public char Symbol { set; get; }

        public bool IsOccupied { get; set; }
    }
}