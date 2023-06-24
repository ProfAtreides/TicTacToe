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
            int max = grids.Length;
            int x = new Random(0).Next(0,max);
            int y = new Random(0).Next(0,max);
            grids[x, y] = Sign;
        }
    }
}