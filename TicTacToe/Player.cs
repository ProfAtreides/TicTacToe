namespace TicTacToe
{
    public class Player : IMoveable
    {
        private char sign;
        public Player(char sign)
        {
            this.sign = sign;
        }

        public void makeMove(char[,] grids)
        {
            int x, y;
            x = System.Console.Read();
            y = System.Console.Read();
            grids[x, y] = sign;
        }
    }
}