using System;
using System.Threading;

namespace TicTacToe
{
    public class Game
    {
        private Board board;
        private int inRowToWin;
        private IMoveable ai, player;

        public Game(int size, int inRowToWin, Difficulty difficulty, Sign playerSign)
        {
            this.board = new Board(size);
            player = new Player(playerSign);
            this.inRowToWin = inRowToWin;

            Sign aiSign;
            if (playerSign == Sign.Circle) aiSign = Sign.Cross;
            else aiSign = Sign.Circle;

            GameEnding.SetParameters(board, inRowToWin);

            switch (difficulty)
            {
                case Difficulty.Easy:
                    ai = new EasyAI(aiSign);
                    break;
                case Difficulty.Medium:
                    ai = new MediumAI(aiSign);
                    break;
                case Difficulty.Hard:
                    ai = new HardAI(aiSign);
                    break;
                case Difficulty.Impossible:
                    ai = new ImpossibleAI(aiSign);
                    break;
                default:
                    break;
            }

            StartGame();
        }

        void PrintMap()
        {
            for (int j = 0; j < board.Size * 2 + 1; j++)
            {
                System.Console.Write("-");
            }

            System.Console.Write("\n");
            for (int i = 0; i < board.Size; i++)
            {
                System.Console.Write('|');
                for (int j = 0; j < board.Size; j++)
                {
                    System.Console.Write((char)board.Grids[i, j] + "|");
                }

                System.Console.Write("\n");
                for (int j = 0; j < board.Size * 2 + 1; j++)
                {
                    System.Console.Write("-");
                }

                System.Console.Write("\n");
            }
        }

        void StartGame()
        {
            char currentMove = 'X';
            while (!GameEnding.IsOver())
            {
                PrintMap();
                player.MakeMove(board);
                if (GameEnding.IsOver()) break;
                ai.MakeMove(board);
                Console.Clear();
            }

            Console.Clear();
            PrintMap();
            Console.Write("The game ended in " + GameEnding.GameResult());
            Thread.Sleep(2000);
        }
    }
}