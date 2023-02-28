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
            
            DrawBoard();

            while (!_game.IsGameOver())
            {
                if (_game.GetCurrentPlayer() == 'X')
                {
                    // Get move for player X
                    PlayerMove('X');
                }
                else
                {
                    // Get move for player O
                    PlayerMove('O');
                }
            }

            Console.WriteLine("\nFinal board:\n");
            DrawBoard();

            if (_game.CheckWin('X'))
            {
                Console.WriteLine("\nX wins!");
            }
            else if (_game.CheckWin('O'))
            {
                Console.WriteLine("\nO wins!");
            }
            else
            {
                Console.WriteLine("\nIt's a tie!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private void PlayerMove(char marker)
        {
            while (true)
            {
                Console.Write("Your move ({0}): ", marker);
                if (int.TryParse(Console.ReadLine(), out int position))
                {
                    int row = (position - 1) / 3;
                    int col = (position - 1) % 3;
                    if (_game.IsValidMove(row, col))
                    {
                        _game.MakeMove(row, col, marker);
                        DrawBoard();
                        break;
                    }
                }

                Console.WriteLine("Invalid move! Please try again.");
            }
        }

        private void DrawBoard()
        {
            var board = _game.GetBoard();

            if (board.GetLength(0) != 3 || board.GetLength(1) != 3)
            {
                Console.WriteLine("Invalid board size!");
                return;
            }

            Console.WriteLine("-----------------------\n");
            Console.WriteLine(" " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " ");
            Console.WriteLine("Status: {0}", _game.GetStatus());
        }
    }
}
