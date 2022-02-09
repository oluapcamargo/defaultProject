using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace V1.DefaultProject.FunctionsAzure.Util
{
    public static class StartupConfig
    {
        private static readonly object LockerConfiguration = new object();
        private static IConfigurationRoot _configuration = null;

        public static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    lock (LockerConfiguration)
                    {
                        if (_configuration == null)
                            _configuration = CreateConfiguration();
                    }
                }

                return _configuration;
            }
        }

        private static IConfigurationRoot CreateConfiguration()
        {
            string path = GetRootDirectory();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path);

            string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(environmentName) && environmentName != "Production")
            {
                //Não foi possível alterar a Connection das functions QueueTrigger.
                //string environmentSection = _environmentName.ToLower() != "development" ? $".{_environmentName}" : string.Empty;
                //File.Move(Path.Combine(path, "local.settings.json"), Path.Combine(path, "local.settings.original.json"), true);
                //File.Move(Path.Combine(path, "local.settings.Dev2.json"), Path.Combine(path, "local.settings.json"), true);

                configuration.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
            }

            configuration
                //.AddJsonFile("messages.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            return configuration.Build();
        }

        public static string GetRootDirectory()
        {
            string path = "/home/site/wwwroot/";
            if (Directory.Exists(path))
                return path;

            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.GetFullPath(Path.Combine(path, ".."));
            if (Directory.Exists(path))
                return path;

            path = Directory.GetCurrentDirectory();
            if (Directory.Exists(path))
                return path;

            return string.Empty;
        }
    }
}