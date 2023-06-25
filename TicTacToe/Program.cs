using System;
using System.Threading;

namespace TicTacToe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int size, inRowToWin;
            Difficulty difficulty ;
            Sign playerSign;
            bool correctGameSettings = false;
            while (!correctGameSettings)
            {
                Console.WriteLine("Input game settings: size(3-15),how many signs in a row needed to win(<=size)," +
                                  "difficulty(Easy,Medium,Hard,Impossible),sign(Cross,Circle))");
                string inputLine = Console.ReadLine();
                try
                {
                    int lastInput = 0;
                    String[] settings = inputLine.Split(' ');
                    size = Convert.ToInt32(settings[0]);
                    inRowToWin = Convert.ToInt32(settings[1]);
                    difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), settings[2]);
                    playerSign = (Sign)Enum.Parse(typeof(Sign), settings[3]);
                    Game test = new Game(size, inRowToWin, difficulty, playerSign);
                    correctGameSettings = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong settings!");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
    }
}