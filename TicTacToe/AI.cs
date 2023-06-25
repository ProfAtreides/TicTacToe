using System.Security.Cryptography;

namespace TicTacToe
{
    public abstract class AI : IMoveable
    {
        private Sign sign;

        public Sign Sign
        {
            get => sign;
            set => sign = value;
        }

        public virtual void MakeMove(Board borad)
        {
            throw new System.Exception("Injedction error");
        }
    }
}