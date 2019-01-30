using DevelopersApi.Core.Settings;
using DevelopersApi.DataAccess.DataSources;
using DevelopersApi.Test.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DevelopersApi.Test.DataAccess
{
    public class DataSourceUnitTest
    {
        [Fact]
        public async Task ShouldReadJsonFile()
        {
            IOptions<AppSettingsModel> settings = Options.Create(TestHelper.GetApplicationConfiguration());

            var dataSource = new JSONDataSource(settings);

            var data = await dataSource.GetAllAsync();

            Assert.True(data != null);
        }
    }
}
