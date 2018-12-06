using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OverwatchAPI;

namespace KBot.Core.Utilities
{
    public static class Overwatch
    {
        private static OverwatchClient owClient = new OverwatchClient();

        public static async Task<Player> GetPlayer(string btag)
        {
            Player player = await owClient.GetPlayerAsync(btag);
            return await owClient.GetPlayerAsync(btag);
        }

    }
}
