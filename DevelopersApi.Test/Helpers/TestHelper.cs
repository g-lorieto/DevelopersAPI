using DevelopersApi.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Test.Helpers
{
    public static class TestHelper
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

        public static async Task<IHttpClientFactory> GetMockHttpClientFactoryAsync(IOptions<AppSettingsModel> settings)
        {
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.Value.JSONFIle)))
            });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);

            return httpClientFactoryMock;
        }
    }
}
