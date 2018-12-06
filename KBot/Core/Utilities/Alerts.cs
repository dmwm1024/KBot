using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Discord.WebSocket;

namespace KBot.Core.Utilities
{
    class Alerts
    {
        private static Dictionary<string, string> alerts;
        private static string AlertsFile;

        static Alerts()
        {
            AlertsFile = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.1\KBot.dll", @"Resources\SystemLang\alerts.json");
            if (!File.Exists(AlertsFile))
            {
                Console.WriteLine("No alerts.json found.");
            }
            string json = File.ReadAllText(AlertsFile);
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            alerts = data.ToObject<Dictionary<string, string>>();
        }

        public static string GetAlert(string key)
        {
            if (alerts.ContainsKey(key)) return alerts[key];
            return String.Empty;
        }

        public static string GetFormattedAlert(string key, params object[] parameter)
        {
            if (alerts.ContainsKey(key))
            {
                return String.Format(alerts[key], parameter);
            }
            return String.Empty;
        }

        public static string GetFormattedAlert(string key, object parameter)
        {
            return GetFormattedAlert(key, new object[] { parameter });
        }
    }
}
