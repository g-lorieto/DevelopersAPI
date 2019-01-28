using DevelopersApi.Infrastructure.DataSources;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DevelopersApi.Test.Infrastructure
{
    public class DataSourceUnitTest
    {
        [Fact]
        public async Task ShouldReadJsonFile()
        {
            var jsonDataSource = new JSONDataSource();

            var data = await jsonDataSource.GetAllAsync();

            Assert.True(data != null);
        }
    }
}
