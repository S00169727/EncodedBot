using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EncodedBot.Init
{
    class Startup
    {
        private const string _configPath = "Resources";
        private const string _configFile = "config.json";

        static BotStartup bot;

        static Startup()
        {
            if (!Directory.Exists(_configPath))
            {
                Directory.CreateDirectory(_configPath);
            }

            if (!File.Exists($"{_configPath}/{_configFile}"))
            {
                bot = new BotStartup();

                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText($"{_configPath}/{_configFile}", json);
            }
            else
            {
                string json = File.ReadAllText($"{_configPath}/{_configFile}");
                bot = JsonConvert.DeserializeObject<BotStartup>(json);
            }
        }
    }

    public struct BotStartup
    {
        public string token;
        public string prefix;
    }
}
