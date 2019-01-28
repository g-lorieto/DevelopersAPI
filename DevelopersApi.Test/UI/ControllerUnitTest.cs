using DevelopersApi.Controllers;
using DevelopersApi.Core.Services;
using DevelopersApi.DataAccess.DataSources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevelopersApi.Test.UI
{
    public class ControllerUnitTest
    {
        [Fact]
        public async Task ShouldReturnOkBothServices()
        {
            var settings = ConfigurationInitializer.Initialize();

            var dataSource = new JSONDataSource(settings);

            var controller = new DevelopersController(new GenericService(dataSource), new DevelopersService(dataSource, settings));

            var data = await controller.GetAllAsync();

            Assert.NotEmpty(data);

            data = await controller.GetSkilledAsync();

            Assert.NotEmpty(data);
        }
    }
}
