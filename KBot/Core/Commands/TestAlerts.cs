using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using KBot.Core.Utilities;

namespace KBot.Core.Commands
{
    public class TestAlerts : ModuleBase<SocketCommandContext>
    {
        [Command("pick")]
        public async Task PickOne([Remainder]string message)
        {
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];
            string title = Alerts.GetFormattedAlert("CHOICE_TITLE_&Username", Context.User.Username);

            var embed = new EmbedBuilder();
            embed.WithTitle(title);
            embed.WithDescription(selection);
            embed.WithColor(new Color(255, 255, 0));
            embed.WithThumbnailUrl(Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
