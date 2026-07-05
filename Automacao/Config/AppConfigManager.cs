using System.Text.Json;

namespace Automacao.Config
{
    public static class AppConfigManager
    {
        private static TestSettings? _settings;

        public static TestSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    LoadSettings();
                }
                return _settings!;
            }
        }

        private static void LoadSettings()
        {
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "appsettings.json");
            
            // Fallback for execution from project root instead of bin/Debug
            if (!File.Exists(configFilePath))
            {
                configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Config", "appsettings.json");
            }

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
            }

            var jsonString = File.ReadAllText(configFilePath);
            var root = JsonSerializer.Deserialize<Dictionary<string, TestSettings>>(jsonString);
            
            if (root != null && root.ContainsKey("TestSettings"))
            {
                _settings = root["TestSettings"];
            }
            else
            {
                throw new Exception("Invalid configuration format. 'TestSettings' section is missing.");
            }
        }
    }
}
