namespace TicTacToe
{
    public class Board
    {
        public Board(int size)
        {
            this.size = size;
            this.grids = new Sign[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grids[i, j] = Sign.Empty;
                }
            }
        }

        public Sign[,] Grids
        {
            get => grids;
            set => grids = value;
        }

        public int Size
        {
            get => size;
            set => size = value;
        }

        private int size;
        private Sign[,] grids;
    }
}