using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Services;

namespace TicTacToe.ConsoleApp
{
    public class Play
    {
        private readonly IGame _game;

        public Play(IGame game)
        {
            _game = game;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("-----------------------\n");
            Console.WriteLine("Instructions:");
            Console.WriteLine("Enter the position number where you want to place your marker.");

            while (!_game.IsGameOver())
            {
                _game.DrawBoard();

                if (_game.GetCurrentPlayer() == 'X')
                {
                    Console.Write("Your move (X): ");
                    int position = int.Parse(Console.ReadLine());
                    int row = (position - 1) / 3;
                    int col = (position - 1) % 3;
                    if (_game.IsValidMove(row, col))
                    {
                        _game.MakeMove(row, col, 'X');
                    }
                    else
                    {
                        Console.WriteLine("Invalid move! Please try again.");
                        continue;
                    }

                    // Get computer move and make the move
                    int[] computerMove = _game.GetComputerMove();
                    if (_game.IsValidMove(computerMove[0], computerMove[1]))
                    {
                        _game.MakeMove(computerMove[0], computerMove[1], 'O');

                        Console.WriteLine("Computer's move (O): {0}\n", computerMove[0] * 3 + computerMove[1] + 1);
                    }
                }
            }

            Console.WriteLine("\nFinal board:\n");
            _game.DrawBoard();

            if (_game.CheckWin('X'))
            {
                Console.WriteLine("\nYou win!");
            }
            else if (_game.CheckWin('O'))
            {
                Console.WriteLine("\nComputer wins!");
            }
            else
            {
                Console.WriteLine("\nIt's a tie!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
