using System;
using System.Collections.Generic;

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

        private void ShufflePlayers()
        {
            int n = players.Count;
            Random random = new Random();

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (players[n], players[k]) = (players[k], players[n]);
            }
        }

        public void PlayGame()
        {
            ShufflePlayers();

            while (game.CheckForWinner() == 0 || !game.CheckDraw())
            {
                game.ShowGrid();
                int x;
                int y;
                int selectedOption;

                int PlayerNumber = 1;
                foreach (Player player in players)
                {
                    game.ShowGrid();

                    Console.WriteLine($"{player.Name} [{player.Icon}] it's your turn");
                    while (true)
                    {
                        Console.WriteLine("Select a number between 1 and 3 for the X");
                        while (true)
                        {
                            string inputx = Console.ReadLine();
                            if (inputx == null || inputx == "" || !int.TryParse(inputx, out x) || x < 1 || x > 3)
                            {
                                Console.WriteLine("Invalid! Please select a number between 1 and 3 for the X");
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine("Select a number between 1 and 3 for the Y");
                        while (true)
                        {
                            string inputy = Console.ReadLine();

                            if (inputy == null || inputy == "" || !int.TryParse(inputy, out y) || y < 1 || y > 3)
                            {
                                Console.WriteLine("Invalid! Please select a number between 1 and 3 for the X");
                            }
                            else
                            {
                                break;
                            }
                        }

                        selectedOption = (y - 1) * 3 + (x - 1);

                        if (game.Grid[selectedOption] != 0)
                        {
                            Console.WriteLine("Position already in use");
                        }
                        else
                        {
                            break;
                        }
                    }
                    game.Grid[selectedOption] = PlayerNumber;
                    game.GridIcon[selectedOption] = player.Icon;
                    if (game.CheckForWinner() != 0)
                    {
                        break;
                    }
                    if (game.CheckDraw())
                    {
                        break;
                    }
                    PlayerNumber++;
                }
                if (game.CheckForWinner() != 0)
                {
                    break;
                }
                if (game.CheckDraw())
                {
                    break;
                }
            }
            game.ShowGrid();
            if (game.CheckDraw())
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine($"{players[game.CheckForWinner() - 1].Name} [{players[game.CheckForWinner() - 1].Icon}] wins!");
            }
            game.ResetBoard();
        }
    }
}
