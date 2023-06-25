using System;

namespace TicTacToe
{
    public class Player : IMoveable
    {
        private Sign sign;

        public Player(Sign sign)
        {
            this.sign = sign;
        }

        public void MakeMove(Board board)
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
                    y = Convert.ToInt32(input.Substring(endOfFirstCord + 1, input.Length - (endOfFirstCord + 1)));
                    if (board.Grids[x, y] == Sign.Empty)
                    {
                        board.Grids[x, y] = sign;
                        moveMade = true;
                    }
                    else
                    {
                        Console.WriteLine("Grid occupied!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input try again!");
                }
            }
        }
    }
}