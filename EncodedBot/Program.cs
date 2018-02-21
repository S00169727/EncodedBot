using Discord;
using Discord.WebSocket;
using EncodedBot.Command_Handler;
using EncodedBot.Init;
using System;
using System.Threading.Tasks;

namespace EncodedBot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Startup.bot.token == "" || Startup.bot.token == null) return;

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Startup.bot.token);
            await _client.StartAsync();
            
            _handler = new CommandHandler();
            await _handler.InitializerAsync(_client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
