namespace TicTacToe.Services
{
    public interface IGame
    {
        public bool IsValidMove(int row, int col);

        public void MakeMove(int row, int col, char marker);

        public bool IsGameOver();

        public bool CheckWin(char marker);

        public bool CheckTie();

        public char GetCurrentPlayer();

        public char[,] GetBoard();

        public string GetStatus();
    }
}