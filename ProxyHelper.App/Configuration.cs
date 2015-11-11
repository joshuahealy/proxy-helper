using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ProxyHelper.App
{
    public class Configuration
    {
        public static Configuration LoadFromConfigFile()
        {
            var filename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
            return Load(File.ReadAllText(filename));
        }

        public static Configuration Load(string json)
        {
            return JsonConvert.DeserializeObject<Configuration>(json);
        }

        public Configuration()
        {
            RuleSets = new List<RuleSet>();
        }

        public int Port { get; set; }
        public int LogSize { get; set; }
        public List<RuleSet> RuleSets { get; set; }
    }
}