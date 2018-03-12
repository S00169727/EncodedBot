using Discord;
using Discord.Commands;
using EncodedBot.Command_Handler;
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
            var embed = new EmbedBuilder();
            embed.WithTitle(title: "Echoed Message");
            embed.WithDescription(message);
            embed.WithColor(new Color (0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
