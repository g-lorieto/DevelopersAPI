using DevelopersApi.Core.Services;
using DevelopersApi.Core.Settings;
using DevelopersApi.DataAccess.DataSources;
using DevelopersApi.Test.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevelopersApi.Test.Core
{
    public class ServiceUnitTest
    {
        [Fact]
        public async Task ShouldGetData()
        {
            IOptions<AppSettingsModel> settings = Options.Create(TestHelper.GetApplicationConfiguration());

            var httpClientFactoryMock = await TestHelper.GetMockHttpClientFactoryAsync(settings);

            var dataSource = new JSONDataSource(settings);

            var service = new DevelopersService(dataSource, httpClientFactoryMock, settings);

            var data = await service.GetAllAsync();

            Assert.NotEmpty(data);

            data = await service.GetSkilledAsync();

            Assert.NotEmpty(data);
        }
    }
}
