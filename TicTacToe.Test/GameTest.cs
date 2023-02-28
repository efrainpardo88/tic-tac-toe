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
    }
}