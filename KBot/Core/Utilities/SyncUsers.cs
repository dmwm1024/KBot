using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using KBot.Resources.Database;

namespace KBot.Core.Utilities
{
    static class SyncUsers
    {
        public static async Task Sync(DiscordSocketClient client)
        {
            foreach(SocketGuild guild in client.Guilds)
            {
                foreach(SocketGuildUser user in guild.Users)
                {
                    if (!user.IsBot)
                    {
                        if (Data.Data.GetUser(user.Id) == null)
                        {
                            try
                            {
                                await Data.Data.SaveUser(new Person
                                {
                                    Id = user.Id
                                });
                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Completed sync.");
        }
    }
}
