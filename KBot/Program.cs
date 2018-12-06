using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using KBot.Core.Utilities;

namespace KBot
{
    class Program
    {
        // Instantiate
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _handler;

        public async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null)
            {
                Console.WriteLine("Bot token not found.");
                Console.ReadLine();
                return;
            }

            _client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Verbose });
            _client.Log += Log;
            _client.Ready += SyncUsers;
            _handler = new CommandHandler();

            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }

        private async Task SyncUsers()
        {
            await KBot.Core.Utilities.SyncUsers.Sync(_client);
        }
    }
}


/*
   the new version will be built around 3 main concepts:
     - Guilded: Our own custom implementation of Guilded...
     - BirthdayBot: All existing functionality
     - Streamers: All of the things I mentioned regarding this functionality before.
*/