using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace KBot.Core.Utilities
{
    class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";

        public static BotConfig bot;

        static Config()
        {
            string ConfigLocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.1\KBot.dll", "");
            if (!Directory.Exists(ConfigLocation + configFolder)) Directory.CreateDirectory(ConfigLocation + configFolder);
            if (!File.Exists($"{ConfigLocation}{configFolder}/{configFile}"))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText($"{ConfigLocation}{configFolder}/{configFile}", json);
            }
            else
            {
                string json = File.ReadAllText($"{ConfigLocation}{configFolder}/{configFile}");
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}
