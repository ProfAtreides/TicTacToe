namespace TicTacToe
{
    public class GameEnding
    { 
        static private int size, inRowToWin;
        static private char[,] grids;

        static public void setParameters(int size, int inRowToWin, char[,] grids)
        {
            GameEnding.size = size;
            GameEnding.inRowToWin = inRowToWin;
            GameEnding.grids = grids;

        }
        
       static public bool isOver()
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

       static char checkVertical()
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

       static char checkHortizontal()
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

       static char checkLRDiagonal()
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

       static char checkRLDiagonal()
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

       static public string gameResult()
        {
            if (checkVertical() != 'c') return (checkVertical() + " V wins.");
            if (checkHortizontal() != 'c') return (checkHortizontal() + " H wins.");
            if (checkLRDiagonal() != 'c') return (checkLRDiagonal() + " L wins.");
            if (checkRLDiagonal() != 'c') return (checkRLDiagonal() + " R wins.");
            return "draw.";
        }
    }
}