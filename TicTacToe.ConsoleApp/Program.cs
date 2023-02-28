using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Services;

namespace TicTacToe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the service container
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Create the game and start it
            var serviceProvider = services.BuildServiceProvider();
            var play = serviceProvider.GetRequiredService<Play>();
            play.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGame, Game>();
            services.AddTransient<Play>();
        }
    }
}
