using DevelopersApi.Infrastructure.DataSources;
using System;
using System.Linq;
using Xunit;

namespace DevelopersApi.Test.Infrastructure
{
    public class DataSourceUnitTest
    {
        [Fact]
        public void ShouldReadJsonFile()
        {
            var jsonDataSource = new JSONDataSource();

            var data = jsonDataSource.GetAllAsync().ToList();

            Assert.True(data != null);
        }
    }
}
