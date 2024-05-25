using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace SeleniumCommand.Configuration
{
    public class Config : IConfig
    {
        // private JToken _jToken;
        private readonly JObject _config;
        private readonly string _environment;

        public Config()
        {
//             JObject jsonConfig = JObject.Parse(GetConfig());
// #if DEBUG
//             _jToken = jsonConfig.SelectToken("$.local");
// #elif UAT
//             _jToken = jsonConfig.SelectToken("$.uat");
// #elif RELEASE
//             _jToken = jsonConfig.SelectToken("$.production");
// #endif
            _config = JObject.Parse(GetConfig());
            _environment = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "local";
        
        }

        public string ChromeDriverPath()
        {
            // return _jToken.SelectToken("$..chromeDriverPath").ToString();
            var path = (string)_config[_environment]["chromeDriverPath"];
            if (_environment == "azure")
            {
                path = Environment.GetEnvironmentVariable("CHROMEWEBDRIVER") ?? throw new InvalidOperationException("CHROMEWEBDRIVER environment variable is not set.");
            }
            return path;
        }

        public string TestUrl()
        {
            // return _jToken.SelectToken("$..testUrl").ToString();
            return (string)_config[_environment]["testUrl"];
        }

        private string GetConfig()
        {
            using (StreamReader r = new StreamReader(GetJsonFilePath()))
            {
                return r.ReadToEnd();
            }
        }

        private string GetJsonFilePath()
        {
            string dirName = AppDomain.CurrentDomain.BaseDirectory;
            FileInfo fileInfo = new FileInfo(dirName);
            DirectoryInfo parentDir = fileInfo.Directory.Parent;
            string parentDirName = parentDir.FullName;
            string jsonFilePath = $@"{parentDirName.Substring(0, parentDirName.IndexOf(@"\bin"))}\config.json";

            return jsonFilePath;
        }
    }
}
