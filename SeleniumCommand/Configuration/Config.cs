using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace SeleniumCommand.Configuration
{
    public class Config : IConfig
    {
        private JToken _jToken;

        public Config()
        {
            JObject jsonConfig = JObject.Parse(GetConfig());
#if DEBUG
            _jToken = jsonConfig.SelectToken("$.local");
#elif UAT
            _jToken = jsonConfig.SelectToken("$.uat");
#elif RELEASE
            _jToken = jsonConfig.SelectToken("$.production");
#endif
        }

        public string ChromeDriverPath()
        {
            return _jToken.SelectToken("$..chromeDriverPath").ToString();
        }

        public string TestUrl()
        {
            return _jToken.SelectToken("$..testUrl").ToString();
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
