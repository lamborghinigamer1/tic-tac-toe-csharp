namespace TicTacToe
{
    public class DisplayGrid : Board
    {
        public DisplayGrid() : base()
        {

        }
        public void ShowGrid()
        {
            Console.Clear();
            int toeindex = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grid[toeindex] == 0)
                    {
                        Console.Write($"[ ]");
                    }
                    else
                    {
                        Console.Write($"[{GridIcon[toeindex]}]");
                    }
                    toeindex++;
                }
                Console.WriteLine();
            }
        }
    }
}