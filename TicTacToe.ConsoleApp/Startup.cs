using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace TicTacToe.ConsoleApp
{
    public class Startup
    {
        public void Run()
        {
            // Configure the service container
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Create the game and start it
            var serviceProvider = services.BuildServiceProvider();
            var game = serviceProvider.GetRequiredService<Game>();
            game.Start().GetAwaiter().GetResult();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPlay, Play>();
            services.AddTransient<Game>();
        }

    }
}
