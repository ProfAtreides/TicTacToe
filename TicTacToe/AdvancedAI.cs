using System;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    public class AdvancedAI : AI
    {
        public int MaxDepth
        {
            get => maxDepth;
            set => maxDepth = value;
        }
        public Sign Sign
        {
            get => sign;
            set => sign = value;
        }
        private int maxDepth;
        private Sign sign;
        
        public override void MakeMove(Board board)
        {
            int size = board.Size;
            int bestMoveI=-1, bestMoveJ=-1;
            int bestScore = -10;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board.Grids[i, j] == Sign.Empty)
                    {
                        board.Grids[i, j] = sign;
                        var score = MinMax( board, false,0,0,0);
                        board.Grids[i, j] = Sign.Empty;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMoveI = i;
                            bestMoveJ = j;
                        }
                    }
                }
            }

            board.Grids[bestMoveI, bestMoveJ] = sign;
        }

        private int MinMax(Board board,bool isMaxing, int alpha,int beta, int depth)
        {
            if (depth == maxDepth || GameEnding.IsOver())
            {
                Sign result = GameEnding.CharResult();
                if (result == sign) return 5;
                else if (result != Sign.Empty) return -5;
                else if (GameEnding.isDraw() == true) return -1;
                else return 0;
            }

            if (isMaxing == true)
            {
                int maxScore = int.MinValue;
                for (int i = 0; i < board.Size; i++)
                {
                    for (int j = 0; j < board.Size; j++)
                    {
                        if (board.Grids[i, j] == Sign.Empty)
                        {
                            board.Grids[i, j] = sign;
                            int score = MinMax(board, false, alpha, beta, depth++);
                            board.Grids[i, j] = Sign.Empty;

                            maxScore = Math.Max(maxScore, score);
                            alpha = Math.Max(alpha, score);
                            if (alpha >= alpha)
                                break;
                        } 
                    }
                }
                return maxScore;
            }
            else
            {
                int minScore = int.MaxValue;
                for (int i = 0; i < board.Size; i++)
                {
                    for (int j = 0; j < board.Size; j++)
                    {
                        if (board.Grids[i, j] == Sign.Empty)
                        {
                            board.Grids[i, j] = (sign == Sign.Circle)? Sign.Cross : Sign.Circle;
                            int score = MinMax(board, true, alpha, beta, depth++);
                            board.Grids[i, j] = Sign.Empty;
                            minScore = Math.Min(minScore, score);
                            beta = Math.Min(beta, score);
                            if (alpha >= beta) break;
                                
                        }
                    }
                }
                return minScore;
            }
        }
        
    }
}