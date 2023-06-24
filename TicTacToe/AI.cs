using System.Security.Cryptography;

namespace TicTacToe
{
    public abstract class AI : IMoveable
    {
        private char sign;

        public char Sign
        {
            get => sign;
            set => sign = value;
        }

        public virtual void makeMove(char[,] grids)
        {
            throw new System.Exception("Injedction error");
        }
    }
}