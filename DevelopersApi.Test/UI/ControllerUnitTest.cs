using DevelopersApi.Controllers;
using DevelopersApi.Core.Models;
using DevelopersApi.Core.Services;
using DevelopersApi.Core.Settings;
using DevelopersApi.DataAccess.DataSources;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevelopersApi.Test.UI
{
    public class ControllerUnitTest
    {
        public class FakeHttpMessageHandler : DelegatingHandler
        {
            private HttpResponseMessage _fakeResponse;

            public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
            {
                _fakeResponse = responseMessage;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(_fakeResponse);
            }
        }

        [Fact]
        public async Task ShouldReturnOkBothServices()
        {
            IOptions<AppSettingsModel> settings = Options.Create<AppSettingsModel>(ConfigurationInitializer.GetApplicationConfiguration());

            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.Value.JSONFIle)))
            });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);

            var dataSource = new JSONDataSource(settings);

            var controller = new DevelopersController(new GenericService(dataSource), new DevelopersService(dataSource, settings), httpClientFactoryMock);

            var data = await controller.GetAllAsync();

            Assert.NotEmpty(data);

            data = await controller.GetSkilledAsync();

            Assert.NotEmpty(data);
        }
    }
}
