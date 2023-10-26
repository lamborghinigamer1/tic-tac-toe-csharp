using System;
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
                    int toeindex = i * 3 + j;
                    if (Grid[toeindex] == 0)
                    {
                        Console.Write($"[ ]");
                    }
                    else
                    {
                        Console.Write($"[{Grid[toeindex]}]");
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
