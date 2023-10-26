namespace TicTacToe
{
    public class Board
    {
        public char[] Grid
        {
            get; set;
        }
        public Board()
        {
            Grid = new char[9];
            ResetBoard();
        }
        public void ResetBoard()
        {
            Grid = new char[9];
            for (int i = 0; i < 9; i++)
            {
                Grid[i] = ' ';
            }
        }
        public char CheckForWinner()
        {
            // Rows
            for (int i = 0; i < 9; i += 3)
            {
                if (Grid[i] != ' ' && Grid[i] == Grid[i + 1] && Grid[i] == Grid[i + 2])
                {
                    return Grid[i];
                }
            }
            // columns
            for (int i = 0; i < 3; i++)
            {
                if (Grid[i] != ' ' && Grid[i] == Grid[i + 3] && Grid[i] == Grid[i + 6])
                {
                    return Grid[i];
                }
            }
            // Diagonal
            if (Grid[0] != ' ' && Grid[0] == Grid[4] && Grid[0] == Grid[8])
            {
                return Grid[0];
            }
            if (Grid[2] != ' ' && Grid[2] == Grid[4] && Grid[2] == Grid[6])
            {
                return Grid[2];
            }
            return ' ';
        }
        public bool CheckDraw()
        {
            int countAvailable = 9;
            foreach (int row in Grid)
            {
                if (row != ' ')
                {
                    countAvailable -= 1;
                }
            }
            if (countAvailable == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}