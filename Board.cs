namespace TicTacToe
{
    public class Board
    {
        public int[] Grid
        {
            get; set;
        }
        public char[] GridIcon
        {
            get; set;
        }
        public Board()
        {
            Grid = new int[9];
            GridIcon = new char[9];
            ResetBoard();
        }
        public void ResetBoard()
        {
            Grid = new int[9];
            GridIcon = new char[9];
            for (int i = 0; i < 9; i++)
            {
                Grid[i] = 0;
                GridIcon[i] = ' ';
            }
        }
        public int CheckForWinner()
        {
            // Rows
            for (int i = 0; i < 9; i += 3)
            {
                if (Grid[i] != 0 && Grid[i] == Grid[i + 1] && Grid[i] == Grid[i + 2])
                {
                    return Grid[i];
                }
            }
            // columns
            for (int i = 0; i < 3; i++)
            {
                if (Grid[i] != 0 && Grid[i] == Grid[i + 3] && Grid[i] == Grid[i + 6])
                {
                    return Grid[i];
                }
            }
            // Diagonal
            if (Grid[0] != 0 && Grid[0] == Grid[4] && Grid[0] == Grid[8])
            {
                return Grid[0];
            }
            if (Grid[2] != 0 && Grid[2] == Grid[4] && Grid[2] == Grid[6])
            {
                return Grid[2];
            }
            return 0;
        }
        public bool CheckDraw()
        {
            int countAvailable = 9;
            foreach (int row in Grid)
            {
                if (row != 0)
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