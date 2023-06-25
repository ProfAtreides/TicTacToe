using System.Linq;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class GameEnding
    {
        static private int  inRowToWin;
        static private Board board;

        static public void SetParameters(Board board,int inRowToWin)
        {
            GameEnding.board = board;
            GameEnding.inRowToWin = inRowToWin;
        }

        static public bool isDraw()
        {
            foreach (var grid in board.Grids)
            {
                if (grid == Sign.Empty) return false;
            }

            return true;
        }
        static public bool IsOver()
        {
            int free = 0;

            if (CheckVertical() != Sign.Empty) return true;
            if (CheckHortizontal() != Sign.Empty) return true;
            if (CheckLRDiagonal() != Sign.Empty) return true;
            if (CheckRLDiagonal() != Sign.Empty) return true;
            if (isDraw()) return true;
            return false;
        }

        static Sign CheckVertical()
        {
            int winningRow = 0;

            for (int i = 0; i < board.Size; i++)
            {
                Sign lastSign = board.Grids[0, i];
                winningRow = 0;
                for (int j = 0; j < board.Size; j++)
                {
                    if (lastSign == board.Grids[j, i] && lastSign != Sign.Empty)
                    {
                        winningRow++;
                    }
                    else if (board.Grids[j, i] != Sign.Empty)
                    {
                        lastSign = board.Grids[j, i];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = Sign.Empty;
                        winningRow = 0;
                    }

                    if (winningRow == inRowToWin) return lastSign;
                }
            }

            return Sign.Empty;
        }

        static Sign CheckHortizontal()
        {
            int winningRow = 0;

            for (int i = 0; i < board.Size; i++)
            {
                Sign lastSign = board.Grids[i, 0];
                winningRow = 0;
                for (int j = 0; j < board.Size; j++)
                {
                    if (lastSign == board.Grids[i, j] && lastSign != Sign.Empty)
                    {
                        winningRow++;
                    }
                    else if (board.Grids[i, j] != Sign.Empty)
                    {
                        lastSign = board.Grids[i, j];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = Sign.Empty;
                        winningRow = 0;
                    }

                    if (winningRow == inRowToWin) return lastSign;
                }
            }

            return Sign.Empty;
        }

        static Sign CheckLRDiagonal()
        {
            int winningRow = 0;

            for (int i = 0; i < board.Size - inRowToWin + 1; i++)
            {
                Sign lastSign = board.Grids[i, 0];
                winningRow = 0;
                for (int j = 0, z = i; j < board.Size; j++, z++)
                {
                    if (z >= board.Size) break;
                    if (lastSign == board.Grids[z, j] && lastSign != Sign.Empty)
                    {
                        winningRow++;
                    }
                    else if (board.Grids[z, j] != Sign.Empty)
                    {
                        lastSign = board.Grids[z, j];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = Sign.Empty;
                        winningRow = 0;
                    }

                    if (winningRow == inRowToWin) return lastSign;
                }
            }

            return Sign.Empty;
        }

        static Sign CheckRLDiagonal()
        {
            int winningRow = 0;

            for (int i = 0; i < board.Size - inRowToWin + 1; i++)
            {
                Sign lastSign = board.Grids[i, 0];
                winningRow = 0;
                for (int j = board.Size - 1, z = i; j > 0; j--, z++)
                {
                    if (z >= board.Size) break;
                    if (lastSign == board.Grids[z, j] && lastSign != Sign.Empty)
                    {
                        winningRow++;
                    }
                    else if (board.Grids[z, j] != Sign.Empty)
                    {
                        lastSign = board.Grids[z, j];
                        winningRow = 1;
                    }
                    else
                    {
                        lastSign = Sign.Empty;
                        winningRow = 0;
                    }

                    if (winningRow == inRowToWin) return lastSign;
                }
            }

            return Sign.Empty;
        }
        
        
        public static Sign CharResult()
        {
            if (CheckVertical() != Sign.Empty) return CheckVertical();
            if (CheckHortizontal() != Sign.Empty) return CheckHortizontal() ;
            if (CheckLRDiagonal() != Sign.Empty) return CheckLRDiagonal();
            if (CheckRLDiagonal() != Sign.Empty) return CheckRLDiagonal() ;
            return Sign.Empty;
        }
        
        public static string GameResult()
        {
            if (CheckVertical() != Sign.Empty) return (CheckVertical() + " V wins.");
            if (CheckHortizontal() != Sign.Empty) return (CheckHortizontal() + " H wins.");
            if (CheckLRDiagonal() != Sign.Empty) return (CheckLRDiagonal() + " L wins.");
            if (CheckRLDiagonal() != Sign.Empty) return (CheckRLDiagonal() + " R wins.");
            return "draw.";
        }
    }
}