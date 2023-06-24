using System;

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
            bool moveMade = false;
            while (!moveMade)
            {
                try
                {
                    int x, y;
                    string input = Console.ReadLine();
                    int endOfFirstCord = input.IndexOf(' ');
                    x = Convert.ToInt32(input.Substring(0, endOfFirstCord));
                    y = Convert.ToInt32(input.Substring(endOfFirstCord+1, input.Length - (endOfFirstCord+ 1)));
                    Console.WriteLine(x + " " + y);
                    grids[x, y] = sign;
                    moveMade = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input try again!");
                }
            }
        }
    }
}