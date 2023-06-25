using System;
using System.Threading;

namespace TicTacToe
{
    public class Game
    {
        private int size;
        private int inRowToWin;
        private char[,] grids;
        private IMoveable ai, player;

        public Game(int size, int inRowToWin, int level, char playerSign)
        {
            player = new Player(playerSign);
            grids = new char[size, size];
            this.inRowToWin = inRowToWin;
            this.size = size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grids[i, j] = ' ';
                }
            }

            GameEnding.setParameters(size,inRowToWin,grids);
            
            //TODO
            switch (level)
            {
                case 0:
                    ai = new EasyAI('X');
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            startGame();
        }

        void printMap()
        {
            for (int j = 0; j < size * 2 + 1; j++)
            {
                System.Console.Write("-");
            }

            System.Console.Write("\n");
            for (int i = 0; i < size; i++)
            {
                System.Console.Write('|');
                for (int j = 0; j < size; j++)
                {
                    System.Console.Write(grids[i, j] + "|");
                }

                System.Console.Write("\n");
                for (int j = 0; j < size * 2 + 1; j++)
                {
                    System.Console.Write("-");
                }

                System.Console.Write("\n");
            }
        }

        void startGame()
        {
            char currentMove = 'X';
            while (!GameEnding.isOver())
            {
                printMap();
                player.makeMove(grids);
                ai.makeMove(grids);
                Console.Clear();
            }

            printMap();
            Console.Write("The game ended in " + GameEnding.gameResult());
            Thread.Sleep(2000);
        }
    }
}