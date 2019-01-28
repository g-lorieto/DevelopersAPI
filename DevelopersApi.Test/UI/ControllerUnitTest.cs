using DevelopersApi.Controllers;
using DevelopersApi.Core.Developers;
using DevelopersApi.Infrastructure.DataSources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevelopersApi.Test.UI
{
    public class ControllerUnitTest
    {
        //TODO: Rename method
        [Fact]
        public async Task ShouldPendingName()
        {
            var controller = new DevelopersController(new DevelopersService(new JSONDataSource()));

            var data = await controller.GetAllAsync();

            Assert.NotEmpty(data);

            data = await controller.GetSkilledAsync();

            Assert.NotEmpty(data);
        }
    }
}
