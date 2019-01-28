using DevelopersApi.Core.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopersApi.Test
{
    public static class ConfigurationInitializer
    {
        public static AppSettingsModel Initialize()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            return new AppSettingsModel
            {
                BaseAddress = config["ApplicationSettings:BaseAddress"],
                JSONFIle = config["ApplicationSettings:JSONFIle"],
                GetAllServiceEndpoint = config["ApplicationSettings:GetAllServiceEndpoint"]
            };
        }
    }
}
