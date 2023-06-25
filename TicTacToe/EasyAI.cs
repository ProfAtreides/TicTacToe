using System;
using System.Security.Cryptography;

namespace TicTacToe
{
    public class EasyAI : AI
    {
        public EasyAI(Sign sign)
        {
            Sign = sign;
        }

        public override void MakeMove(Board board)
        {
            int max = board.Size;
            bool madeMove = false;
            while (!madeMove)
            {
                int x = new Random().Next(0, max);
                int y = new Random().Next(0, max);
                if (board.Grids[x, y] == Sign.Empty)
                {
                    board.Grids[x, y] = Sign;
                    madeMove = true;
                }
            }
        }
    }
}