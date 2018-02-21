using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using EncodedBot.Init;

namespace EncodedBot.Command_Handler
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializerAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();

            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var message = s as SocketUserMessage;
            if (message == null) return;

            var context = new SocketCommandContext(_client, message);
            int argPos = 0;

            if (message.HasStringPrefix(Startup.bot.prefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
