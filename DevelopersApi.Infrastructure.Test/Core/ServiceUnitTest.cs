using DevelopersApi.Core.Developers;
using DevelopersApi.Infrastructure.DataSources;
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
            var service = new DevelopersService(new JSONDataSource());

            var data = await service.GetAllAsync();

            Assert.NotEmpty(data);

            data = await service.GetSkilledAsync();

            Assert.NotEmpty(data);
        }
    }
}
