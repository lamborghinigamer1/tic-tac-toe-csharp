namespace TicTacToe
{
    public class PlayerController
    {
        protected readonly DisplayGrid game;
        private readonly List<Player> players;

        public PlayerController(DisplayGrid game)
        {
            this.game = game;
            players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void PlayGame()
        {
            while (game.CheckForWinner() == 0)
            {
                game.ShowGrid();
                int selectedOption;
                int PlayerNumber = 1;
                foreach (Player player in players)
                {
                    Console.WriteLine($"{player.Name} it's your turn");
                    while (true)
                    {
                        Console.WriteLine("Select a number between 1-9");
                        string? input = Console.ReadLine();
                        if (input == null || input == "" || !int.TryParse(input, out selectedOption) || selectedOption <= 0 || selectedOption > 9 || game.Grid[selectedOption - 1] != 0)
                        {
                            Console.WriteLine("Invalid input");
                        }
                        else
                        {
                            break;
                        }
                    }
                    game.Grid[selectedOption - 1] = PlayerNumber;
                    game.GridIcon[selectedOption - 1] = player.Icon;
                    PlayerNumber++;
                    game.ShowGrid();
                    if (game.CheckForWinner() != 0)
                    {
                        break;
                    }
                    if (game.CheckDraw())
                    {
                        break;
                    }
                }
            }
            game.ShowGrid();
            if (game.CheckDraw())
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine(players[game.CheckForWinner() - 1].Name + " wins!");
            }
        }
    }
}