using DevelopersApi.Core.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopersApi.Test
{
    public static class ConfigurationInitializer
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static AppSettingsModel GetApplicationConfiguration()
        {
            var configuration = new AppSettingsModel();

            var config = GetIConfigurationRoot(AppDomain.CurrentDomain.BaseDirectory.ToString());

            config.GetSection("ApplicationSettings").Bind(configuration);

            return configuration;
        }
    }
}
