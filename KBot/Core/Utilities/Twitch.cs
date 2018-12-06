using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KBot.Core.Utilities
{
    public class Twitch
    {
        private static HttpClient httpClient;

        public Twitch()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("client-ID", "yy50vv42emks2h6plg1ppbgz94lyfm");
        }

        public async Task GetStreams(string names)
        {
            /*
            string url = "https://api.twitch.tv/kraken/streams?channel=" + names;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var root = JsonConvert.DeserializeObject<RootObject>(await response.Content.ReadAsStringAsync());
                if (root._total > 0)
                {
                    foreach (Stream stream in root.streams)
                    {

                    }
                }
            }
            */
        }
    }
}
