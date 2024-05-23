using MineSweeper_Console_Library;

namespace MineSweeper_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("MineSweeper!");

                var board = new Board(8, 8, 5);

                //Included for testing purposes
                board.PrintBoard();

                var player1 = new Player(1, board.Width, board.Height);
                Console.WriteLine(player1.PlayerStatus());

                //Player starts on the top left corner of the board, check if they are already on a mine
                if (board.MineHit(player1.X, player1.Y))
                {
                    player1.Lives--;
                    Console.WriteLine($"Mine hit!!  You have {player1.Lives} lives remaining.");
                }

                var quit = false;
                Console.WriteLine("Press arrow keys to move the player, Esc to quit.");
                do
                {
                    var key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            player1.Move("up");
                            break;
                        case ConsoleKey.DownArrow:
                            player1.Move("down");
                            break;
                        case ConsoleKey.LeftArrow:
                            player1.Move("left");
                            break;
                        case ConsoleKey.RightArrow:
                            player1.Move("right");
                            break;
                        case ConsoleKey.Escape:
                            quit = true;
                            break;
                    }
                    Console.WriteLine(player1.PlayerStatus());

                    if (board.MineHit(player1.X, player1.Y))
                    {
                        player1.Lives--;
                        Console.WriteLine($"Mine hit!!  You now have {player1.CurrentLivesString}.");
                        if (player1.Lives == 0)
                        {
                            Console.WriteLine("Game over!");
                            break;
                        }
                    }
                    if (player1.Won)
                    {
                        Console.WriteLine("You won!");
                        break;
                    }
                } while (quit != true);
                Thread.Sleep(1500);
            }
            catch (Exception err)
            {
                Console.WriteLine("An error occurred.  Game ending." + err.Message.ToString());
            }
        }
    }
}
