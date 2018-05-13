namespace TicTacToe.Board
{
    public class Cordinate : ICordinate
    {
        public Cordinate()
        {
            
        }
        public Cordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Cordinate(int x, int y, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }

        public int X { set; get; }

        public int Y { set; get; }

        public char Symbol { set; get; }

        public bool IsOccupied { get; set; }
    }
}
