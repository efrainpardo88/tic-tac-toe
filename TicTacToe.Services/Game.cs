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

        public void DrawBoard()
        {
            Console.WriteLine(" " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " ");
        }

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

        public int[] GetComputerMove()
        {
            int[] move = LookForWinningMove(computer);

            if (move[0] != -1 && move[1] != -1) // Check if computer can win
            {
                return move;
            }

            move = LookForWinningMove(player);

            if (move[0] != -1 && move[1] != -1) // Check if player can win
            {
                return move;
            }

            // If center position is available, take it
            if (board[1, 1] == '5')
            {
                move[0] = 1;
                move[1] = 1;
                return move;
            }

            // If a corner position is available, take it
            if (board[0, 0] == '1')
            {
                move[0] = 0;
                move[1] = 0;
                return move;
            }
            if (board[0, 2] == '3')
            {
                move[0] = 0;
                move[1] = 2;
                return move;
            }
            if (board[2, 0] == '7')
            {
                move[0] = 2;
                move[1] = 0;
                return move;
            }
            if (board[2, 2] == '9')
            {
                move[0] = 2;
                move[1] = 2;
                return move;
            }

            // Take any available edge position
            if (board[0, 1] == '2')
            {
                move[0] = 0;
                move[1] = 1;
                return move;
            }
            if (board[1, 0] == '4')
            {
                move[0] = 1;
                move[1] = 0;
                return move;
            }
            if (board[1, 2] == '6')
            {
                move[0] = 1;
                move[1] = 2;
                return move;
            }
            if (board[2, 1] == '8')
            {
                move[0] = 2;
                move[1] = 1;
                return move;
            }

            move[0] = -1; // Indicates no valid move was found
            move[1] = -1;
            return move;
        }

        public int[] LookForWinningMove(char marker)
        {
            int[] move = new int[2];

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                int markerCount = 0;
                int emptyCount = 0;
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == marker)
                    {
                        markerCount++;
                    }
                    else if (board[row, col] >= '1' && board[row, col] <= '9')
                    {
                        emptyCount++;
                        move[0] = row;
                        move[1] = col;
                    }
                }
                if (markerCount == 2 && emptyCount == 1)
                {
                    return move;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                int markerCount = 0;
                int emptyCount = 0;
                for (int row = 0; row < 3; row++)
                {
                    if (board[row, col] == marker)
                    {
                        markerCount++;
                    }
                    else if (board[row, col] >= '1' && board[row, col] <= '9')
                    {
                        emptyCount++;
                        move[0] = row;
                        move[1] = col;
                    }
                }
                if (markerCount == 2 && emptyCount == 1)
                {
                    return move;
                }
            }

            // Check diagonals
            int diagonal1Count = 0;
            int diagonal1Empty = 0;
            int diagonal2Count = 0;
            int diagonal2Empty = 0;
            for (int i = 0; i < 3; i++)
            {
                if (board[i, i] == marker)
                {
                    diagonal1Count++;
                }
                else if (board[i, i] >= '1' && board[i, i] <= '9')
                {
                    diagonal1Empty++;
                    move[0] = i;
                    move[1] = i;
                }

                if (board[i, 2 - i] == marker)
                {
                    diagonal2Count++;
                }
                else if (board[i, 2 - i] >= '1' && board[i, 2 - i] <= '9')
                {
                    diagonal2Empty++;
                    move[0] = i;
                    move[1] = 2 - i;
                }
            }
            if (diagonal1Count == 2 && diagonal1Empty == 1)
            {
                return move;
            }
            if (diagonal2Count == 2 && diagonal2Empty == 1)
            {
                return move;
            }

            move[0] = -1; // Indicates no winning move was found
            move[1] = -1;
            return move;
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