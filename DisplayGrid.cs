namespace TicTacToe
{
    public class DisplayGrid : Board
    {
        public DisplayGrid() : base()
        {

        }
        public void ShowGrid()
        {
            try
            {
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Y |");
            for (int i = 2; i >= 0; i--)
            {
                Console.Write(i + 1);
                for (int j = 0; j < 3; j++)
                {
                    int toeIndex = i * 3 + j;
                    if (Grid[toeIndex] == 0)
                    {
                        Console.Write($"[ ]");
                    }
                    else
                    {
                        Console.Write($"[{Grid[toeIndex]}]");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("0 ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1}  ");
            }
            Console.WriteLine();
            Console.Write("X -");
            Console.WriteLine();
        }
    }
}