using DevelopersApi.Controllers;
using DevelopersApi.Core.Models;
using DevelopersApi.Core.Services;
using DevelopersApi.Core.Settings;
using DevelopersApi.DataAccess.DataSources;
using DevelopersApi.Test.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        [Fact]
        public async Task ShouldReturnOkBothServices()
        {
            IOptions<AppSettingsModel> settings = Options.Create(TestHelper.GetApplicationConfiguration());

            var httpClientFactoryMock = await TestHelper.GetMockHttpClientFactoryAsync(settings);

            var dataSource = new JSONDataSource(settings);

            var genericService = new GenericService(dataSource);

            var developersService = new DevelopersService(dataSource, httpClientFactoryMock, settings);

            var controller = new DevelopersController(genericService, developersService);

            var data = await controller.GetAllAsync();

            Assert.NotEmpty(data);

            data = await controller.GetSkilledAsync();

            Assert.NotEmpty(data);            
            
            foreach(var dev in data)
            {
                Assert.True(dev.Skills.Count() >= 1);

                Assert.Contains(dev.Skills, s => s.Level >= 8);

                Assert.True(dev.Skills.Select(s => s.Type).Distinct().Count() == 1);                
            }
        }
    }
}
