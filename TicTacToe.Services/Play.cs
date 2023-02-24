namespace TicTacToe.Services
{
    public class Play : IPlay
    {
        public async Task DoSomething()
        {
            Console.WriteLine("Doing something asynchronously...");
            await Task.Delay(1000); // simulate some asynchronous work
            Console.WriteLine("Done!");
        }
    }
}