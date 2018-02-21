using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EncodedBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Echo([Remainder] string message)
        {
            await Context.Channel.SendMessageAsync(message);
        }
    }
}
