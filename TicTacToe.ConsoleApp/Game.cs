using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace TicTacToe.ConsoleApp
{
    public class Game
    {
        private readonly IPlay _play;

        public Game(IPlay play)
        {
            _play = play;
        }

        public async Task Start()
        {
            await _play.DoSomething();
        }
    }
}
