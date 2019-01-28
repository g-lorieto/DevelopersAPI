using DevelopersApi.DataAccess.DataSources;
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
            var settings = ConfigurationInitializer.Initialize();

            var dataSource = new JSONDataSource(settings);

            var data = await dataSource.GetAllAsync();

            Assert.True(data != null);
        }
    }
}
