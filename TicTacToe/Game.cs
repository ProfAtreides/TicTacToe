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

        bool isOver()
        {
            int free = 0;

            if (checkVertical() != 'c') return true;
            if (checkHortizontal() != 'c') return true;
            if (checkLRDiagonal() != 'c') return true;
            if (checkRLDiagonal() != 'c') return true;

            foreach (var temp in grids)
            {
                if (temp == ' ') free++;
            }

            if (free > 0) return false;

            return true;
        }

        char checkVertical()
        {
            int winningRow = 0;

            for (int i = 0; i < size; i++)
            {
                char lastSign = grids[0, i];
                for (int j = 0; j < size; j++)
                {
                    if (lastSign == grids[j, i] && lastSign != ' ')
                    {
                        winningRow++;
                    }
                    else if (grids[j,i] != ' ')
                    {
                        lastSign = grids[j, i];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = ' ';
                        winningRow = 0;
                    }
                    if (winningRow == inRowToWin) return lastSign;
                }
            }

            return 'c';
        }

        char checkHortizontal()
        {
            int winningRow = 0;

            for (int i = 0; i < size; i++)
            {
                char lastSign = grids[i, 0];
                for (int j = 0; j < size; j++)
                {
                    if (lastSign == grids[i, j] && lastSign != ' ')
                    {
                        winningRow++;
                    }
                    else if (grids[i,j] != ' ')
                    {
                        lastSign = grids[i, j];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = ' ';
                        winningRow = 0;
                    }
                    if (winningRow == inRowToWin) return lastSign;
                    
                }
            }

            return 'c';
        }

        char checkLRDiagonal()
        {
            int winningRow = 0;

            for (int i = 0; i < size - inRowToWin; i++)
            {
                char lastSign = grids[i, 0];
                for (int j = 0, z = i; j < size; j++, z++)
                {
                    if (lastSign == grids[z, j] && lastSign != ' ')
                    {
                        winningRow++;
                    }
                    else if (grids[z,j] != ' ')
                    {
                        lastSign = grids[z, j];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = ' ';
                        winningRow = 0;
                    }
                    if (winningRow == inRowToWin) return lastSign;
                }
            }

            return 'c';
        }

        char checkRLDiagonal()
        {
            int winningRow = 0;

            for (int i = 0; i < size - inRowToWin; i++)
            {
                char lastSign = grids[i, 0];
                for (int j = size - 1, z = i; j > 0; j--, z++)
                {
                    if (lastSign == grids[z, j] && lastSign != ' ')
                    {
                        winningRow++;
                    }
                    else if (grids[z,j] != ' ')
                    {
                        lastSign = grids[z, j];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = ' ';
                        winningRow = 0;
                    }
                    if (winningRow == inRowToWin) return lastSign;
                }
            }

            return 'c';
        }

        string gameResult()
        {
            if (checkVertical() != 'c') return (checkVertical() + " V wins.");
            if (checkHortizontal() != 'c') return (checkHortizontal() + " H wins.");
            if (checkLRDiagonal() != 'c') return (checkLRDiagonal() + " L wins.");
            if (checkRLDiagonal() != 'c') return (checkRLDiagonal() + " R wins.");
            return "draw.";
        }

        void startGame()
        {
            char currentMove = 'X';
            while (!isOver())
            {
                printMap();
                player.makeMove(grids);
                ai.makeMove(grids);
                Console.Clear();
            }

            printMap();
            Console.Write("The game ended in " + gameResult());
            Thread.Sleep(2000);
        }
    }
}