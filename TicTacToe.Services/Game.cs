namespace TicTacToe.Services
{
    public class Game : IGame
    {
        private char[,] board = new char[3, 3]; // Create the game board
        private char player = 'X'; // Player's marker
        private char computer = 'O'; // Computer's marker

        public char[,] Board {
            get {
                return board;
            }
            set {
                board = value;
            }
        }

        public Game()
        {
            InitializeBoard();
        }

        #region public methods

        public bool IsValidMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2) // Check if position is out of bounds
            {
                return false;
            }
            if (board[row, col] == 'X' || board[row, col] == 'O') // Check if position is already occupied
            {
                return false;
            }
            return true;
        }

        public void MakeMove(int row, int col, char marker)
        {
            board[row, col] = marker;
        }

        public bool IsGameOver()
        {
            if (CheckWin(player))
            {
                return true;
            }
            if (CheckWin(computer))
            {
                return true;
            }
            if (CheckTie())
            {
                return true;
            }
            return false;
        }

        public bool CheckWin(char marker)
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == marker && board[row, 1] == marker && board[row, 2] == marker)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == marker && board[1, col] == marker && board[2, col] == marker)
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] == marker && board[1, 1] == marker && board[2, 2] == marker)
            {
                return true;
            }
            if (board[0, 2] == marker && board[1, 1] == marker && board[2, 0] == marker)
            {
                return true;
            }

            return false;
        }

        public bool CheckTie()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] >= '1' && board[row, col] <= '9')
                    {
                        return false; // Game is not over yet
                    }
                }
            }
            return true; // All positions are occupied and no one has won, so it's a tie
        }

        public char GetCurrentPlayer()
        {
            int xCount = 0;
            int oCount = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == 'X')
                    {
                        xCount++;
                    }
                    else if (board[row, col] == 'O')
                    {
                        oCount++;
                    }
                }
            }
            return (xCount <= oCount) ? 'X' : 'O';
        }

        public char[,] GetBoard() => Board;

        public string GetStatus()
        {
            if (IsGameOver())
                return "Game Over";
            else
                return "In progress";
        }

        #endregion

        #region private methods

        private void InitializeBoard()
        {
            board[0, 0] = '1';
            board[0, 1] = '2';
            board[0, 2] = '3';
            board[1, 0] = '4';
            board[1, 1] = '5';
            board[1, 2] = '6';
            board[2, 0] = '7';
            board[2, 1] = '8';
            board[2, 2] = '9';
        }

        #endregion
    }
}