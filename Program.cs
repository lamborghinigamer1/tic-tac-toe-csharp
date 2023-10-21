using TicTacToe;

class Program
{
    static void Main()
    {
        PlayerController player = new(new DisplayGrid());
        int playercount = 0;
        while (playercount != 2)
        {
            string name = "";
            char icon;

            while (true)
            {
                Console.WriteLine("Player " + (playercount + 1) + " what's your name?");
                string? input = Console.ReadLine();
                if (input == null || input == "")
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    name = input;
                    break;
                }
            }
            while (true)
            {
                string? input;
                Console.WriteLine(name + " what will be your icon?");
                input = Console.ReadLine();
                if (char.TryParse(input, out icon))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please use a single character");
                }
            }
            player.AddPlayer(new Player(name, icon));
            playercount++;
        }
        player.PlayGame();
    }
}