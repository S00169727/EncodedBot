using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EncodedBot.Utilities
{
    class Utilities
    {
        private static Dictionary<string, string> alerts;

        static Utilities()
        {
            string json = File.ReadAllText("System Lang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            alerts = data.ToObject<Dictionary<string, string>>();
        }

    }
}
