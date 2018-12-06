using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KBot.Resources.Database;
using Discord;
using Discord.WebSocket;
using System.Linq;

namespace KBot.Core.Commands
{
    public class UserDataCommands : ModuleBase<SocketCommandContext>
    {
        [Group("add"), Alias("remember"), Summary("Allows users to add information to the bot.")]
        public class Add_UserDataCommandsGroup : ModuleBase<SocketCommandContext>
        {

            [Command("btag"), Alias("battletag"),Summary("Adds the user's battle tag to their record.")]
            public async Task Btag(string btag)
            {
                Person person = Data.Data.GetUser(Context.User.Id);
                person.BattleTag = btag;
                await Data.Data.SaveUser(person);
            }

            [Command("bday"), Alias("birthday"), Summary("Adds the user's birthday to their record.")]
            public async Task Bday(IUser BirthdayUser, int bdayMonth, int bdayDay)
            {
                var User = Context.User as SocketGuildUser;
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Captain");
                if (User.Roles.Contains(role))
                {
                    Person person = Data.Data.GetUser(BirthdayUser.Id);
                    person.BdayMonth = bdayMonth;
                    person.BdayDay = bdayDay;
                    await Data.Data.SaveUser(person);
                    await ReplyAsync("Perfect! I won't forget it!");
                } else
                {
                    await ReplyAsync("You must be a captain to use this command.");
                }
            }

            [Command("stream"), Summary("Adds the user's stream name to their record.")]
            public async Task Stream(string streamName)
            {
                Person person = Data.Data.GetUser(Context.User.Id);
                person.Name = streamName;
                await Data.Data.SaveUser(person);
            }
        }

        [Group("get"), Alias("pull"), Summary("Allows users to add information to the bot.")]
        public class Get_UserDataCommandsGroup : ModuleBase<SocketCommandContext>
        {
            [Command("btag"), Alias("battletag"), Summary("Returns the users btag stored on record.")]
            public async Task Btag()
            {
                Person person = Data.Data.GetUser(Context.User.Id);
                if (person.BattleTag == String.Empty)
                {
                    await Context.Channel.SendMessageAsync("I'm afraid I do not know your battle tag!");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Your Btag: " + person.BattleTag);
                }
            }

            [Command("bday"), Alias("birthday"), Summary("Gets the user's birthday from their record.")]
            public async Task Bday(IUser BirthdayUser)
            {
                Person person = Data.Data.GetUser(BirthdayUser.Id);
                await ReplyAsync($"Their birthday is on {person.BdayMonth}/{person.BdayDay}");
            }

            [Command("stream"), Summary("Adds the user's stream name to their record.")]
            public async Task Stream(IUser streamer)
            {
                Person person = Data.Data.GetUser(streamer.Id);
                await ReplyAsync("Their stream is: https://www.twitch.tv/" + person.Name);
            }
        }
    }
}
