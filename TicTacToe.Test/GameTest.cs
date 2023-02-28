using TicTacToe.Services;
using Xunit;

namespace TicTacToe.Test
{
    public class GameTest
    {
        [Fact]
        public void Test_InitializeBoard()
        {
            //Arrange
            Game game = new Game();
            char[,] expectedBoard = new char[3, 3]
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };

            //Act
            char[,] actualBoard = game.Board;

            //Assert
            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Test_IsValidMove_ValidMove()
        {
            //Arrange
            Game game = new Game();
            int row = 0;
            int col = 0;

            //Act
            bool isValidMove = game.IsValidMove(row, col);

            //Assert
            Assert.True(isValidMove);
        }

        [Fact]
        public void Test_IsValidMove_InvalidMove_OutOfBounds()
        {
            //Arrange
            Game game = new Game();
            int row = 3;
            int col = 0;

            //Act
            bool isValidMove = game.IsValidMove(row, col);

            //Assert
            Assert.False(isValidMove);
        }

        [Fact]
        public void Test_IsValidMove_InvalidMove_AlreadyOccupied()
        {
            //Arrange
            Game game = new Game();
            int row = 0;
            int col = 0;
            game.Board[row, col] = 'X';

            //Act
            bool isValidMove = game.IsValidMove(row, col);

            //Assert
            Assert.False(isValidMove);
        }

        [Fact]
        public void Test_MakeMove()
        {
            //Arrange
            Game game = new Game();
            int row = 0;
            int col = 0;
            char marker = 'X';
            char[,] expectedBoard = new char[3, 3]
            {
                {'X', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };

            //Act
            game.MakeMove(row, col, marker);
            char[,] actualBoard = game.Board;

            //Assert
            Assert.Equal(expectedBoard, actualBoard);
        }

        [Fact]
        public void Test_CheckWin_Row()
        {
            //Arrange
            Game game = new Game();
            game.Board = new char[3, 3]
            {
                {'X', 'X', '3'},
                {'O', 'O', 'O'},
                {'7', '8', '9'}
            };
            char marker = 'O';

            //Act
            bool isWin = game.CheckWin(marker);

            //Assert
            Assert.True(isWin);
        }

        [Fact]
        public void Test_CheckWin_Column()
        {
            //Arrange
            Game game = new Game();
            game.Board = new char[3, 3]
            {
                {'X', '2', 'O'},
                {'X', 'X', 'O'},
                {'7', '8', 'O'}
            };
            char marker = 'O';

            //Act
            bool isWin = game.CheckWin(marker);

            //Assert
            Assert.True(isWin);
        }

        [Fact]
        public void Test_CheckWin_Diagonal()
        {
            //Arrange
            Game game = new Game();
            game.Board = new char[3, 3]
            {
                {'X', '2', 'O'},
                {'X', 'O', '6'},
                {'O', '8', '9'}
            };
            char marker = 'O';

            //Act
            bool isWin = game.CheckWin(marker);

            //Assert
            Assert.True(isWin);
        }

        [Fact]
        public void Test_CheckTie()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');
            game.MakeMove(0, 1, 'O');
            game.MakeMove(0, 2, 'X');
            game.MakeMove(1, 0, 'O');
            game.MakeMove(1, 1, 'X');
            game.MakeMove(1, 2, 'O');
            game.MakeMove(2, 0, 'O');
            game.MakeMove(2, 1, 'X');
            game.MakeMove(2, 2, 'O');

            // Act
            var isTie = game.CheckTie();

            // Assert
            Assert.True(isTie);
        }

    }
}