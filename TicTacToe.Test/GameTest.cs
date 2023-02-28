using TicTacToe.Services;
using Xunit;

namespace TicTacToe.Test
{
    public class GameTest
    {
        [Fact]
        public void Test_Initial_Board_Has_Correct_Markers()
        {
            // Arrange
            var game = new Game();

            // Assert
            Assert.Equal('1', game.Board[0, 0]);
            Assert.Equal('2', game.Board[0, 1]);
            Assert.Equal('3', game.Board[0, 2]);
            Assert.Equal('4', game.Board[1, 0]);
            Assert.Equal('5', game.Board[1, 1]);
            Assert.Equal('6', game.Board[1, 2]);
            Assert.Equal('7', game.Board[2, 0]);
            Assert.Equal('8', game.Board[2, 1]);
            Assert.Equal('9', game.Board[2, 2]);
        }

        [Fact]
        public void Test_Make_Move()
        {
            // Arrange
            var game = new Game();

            // Act
            game.MakeMove(0, 0, 'X');

            // Assert
            Assert.Equal('X', game.Board[0, 0]);
        }

        [Fact]
        public void Test_Invalid_Move()
        {
            // Arrange
            var game = new Game();

            // Act
            var isValidMove = game.IsValidMove(3, 3);

            // Assert
            Assert.False(isValidMove);
        }

        [Fact]
        public void Test_Valid_Move()
        {
            // Arrange
            var game = new Game();

            // Act
            var isValidMove = game.IsValidMove(0, 0);

            // Assert
            Assert.True(isValidMove);
        }

        [Fact]
        public void Test_Check_Win_Row()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');
            game.MakeMove(1, 0, 'O');
            game.MakeMove(0, 1, 'X');
            game.MakeMove(1, 1, 'O');

            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.False(isGameOver);

            // Act
            game.MakeMove(0, 2, 'X');

            // Assert
            Assert.True(game.IsGameOver());
        }

        [Fact]
        public void Test_Check_Win_Column()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');
            game.MakeMove(0, 1, 'O');
            game.MakeMove(1, 0, 'X');
            game.MakeMove(1, 1, 'O');

            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.False(isGameOver);

            // Act
            game.MakeMove(2, 0, 'X');

            // Assert
            Assert.True(game.IsGameOver());
        }

        [Fact]
        public void Test_Check_Win_Diagonal()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');
            game.MakeMove(0, 1, 'O');
            game.MakeMove(1, 1, 'X');
            game.MakeMove(0, 2, 'O');

            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.False(isGameOver);

            // Act
            game.MakeMove(2, 2, 'X');

            // Assert
            Assert.True(game.IsGameOver());
        }

        [Fact]
        public void Test_Get_Current_Player()
        {
            // Arrange
            var game = new Game();

            // Act
            var currentPlayer = game.GetCurrentPlayer();

            // Assert
            Assert.Equal('X', currentPlayer);
        }

        [Fact]
        public void Test_Check_Tie()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');
            game.MakeMove(1, 0, 'O');
            game.MakeMove(2, 0, 'X');
            game.MakeMove(1, 1, 'O');
            game.MakeMove(0, 1, 'X');
            game.MakeMove(0, 2, 'O');
            game.MakeMove(1, 2, 'X');
            game.MakeMove(2, 1, 'O');
            game.MakeMove(2, 2, 'X');

            // Act
            var isGameOver = game.IsGameOver();

            // Assert
            Assert.True(isGameOver);
            Assert.True(game.CheckTie());
        }

        [Fact]
        public void Test_Get_Status_Game_Over()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');
            game.MakeMove(1, 0, 'O');
            game.MakeMove(0, 1, 'X');
            game.MakeMove(1, 1, 'O');
            game.MakeMove(0, 2, 'X');

            // Act
            var status = game.GetStatus();

            // Assert
            Assert.Equal("Game Over", status);
        }

        [Fact]
        public void Test_Get_Status_In_Progress()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');
            game.MakeMove(1, 0, 'O');

            // Act
            var status = game.GetStatus();

            // Assert
            Assert.Equal("In progress", status);
        }

        [Fact]
        public void Test_Get_Board()
        {
            // Arrange
            var game = new Game();
            game.MakeMove(0, 0, 'X');

            // Act
            var board = game.GetBoard();

            // Assert
            Assert.Equal('X', board[0, 0]);
        }

    }
}