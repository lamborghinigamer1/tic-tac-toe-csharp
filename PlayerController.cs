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

                var temp = players[n];
                players[n] = players[k];
                players[k] = temp;
            }
        }

        public void PlayGame()
        {
            ShufflePlayers();

            char winnerIcon = ' ';
            string winnerName = "";

            while (winnerIcon == ' ' && !game.CheckDraw())
            {
                game.ShowGrid();
                int x;
                int y;
                int selectedOption;

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

                        if (game.Grid[selectedOption] != ' ')
                        {
                            Console.WriteLine("Position already in use");
                        }
                        else
                        {
                            game.Grid[selectedOption] = player.Icon;
                            break;
                        }
                    }
                    if (game.CheckForWinner() != ' ')
                    {
                        winnerIcon = game.CheckForWinner();
                        winnerName += player.Name;
                        break;
                    }
                    if (game.CheckDraw())
                    {
                        break;
                    }
                }
                game.ShowGrid();
                if (game.CheckDraw() && winnerName == "")
                {
                    Console.WriteLine("Draw");
                }
                else
                {
                    Console.WriteLine($"{winnerName} [{winnerIcon}] wins!");
                }
            }
            game.ResetBoard();
        }
    }
}
