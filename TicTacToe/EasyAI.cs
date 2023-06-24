using System;
using System.Security.Cryptography;

namespace TicTacToe
{
    public class EasyAI : AI
    {
        public EasyAI(char sign)
        {
            Sign = sign;
        }

        public override void makeMove(char[,] grids)
        {
            int max = Convert.ToInt32(Math.Sqrt(grids.Length));
            bool madeMove = false;
            while (!madeMove)
            {
                int x = new Random().Next(0,max);
                int y = new Random().Next(0,max);
                if (grids[x, y] == ' ')
                {
                    grids[x, y] = Sign;
                    madeMove = true;
                }
            }
            
        }
    }
}