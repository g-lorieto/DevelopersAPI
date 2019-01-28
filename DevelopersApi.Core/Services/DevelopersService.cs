using DevelopersApi.Core.Interfaces;
using DevelopersApi.Core.Interfaces.Generics;
using DevelopersApi.Core.Models;
using DevelopersApi.Core.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Services
{
    public class DevelopersService : IDevelopersService
    {
        private IDataSource _dataSource;

        public IAsyncService<Developer> GenericService { get; set; }

        private AppSettingsModel _settings;

        public DevelopersService(IDataSource dataSource, AppSettingsModel settings)
        {
            _dataSource = dataSource;
            _settings = settings;
            this.GenericService = new GenericService(dataSource);
        }

        public async Task<ICollection<Developer>> GetAllAsync()
        {
            return await this.GenericService.GetAllAsync();
        }
               
        public async Task<ICollection<Developer>> GetSkilledAsync()
        {
            try
            {
                ICollection<Developer> developers = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_settings.BaseAddress);

                    var response = await client.GetAsync(_settings.GetAllServiceEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        developers = JsonConvert.DeserializeObject<ICollection<Developer>>(await response.Content.ReadAsStringAsync());
                    }
                }

                return (from dev in developers
                        where dev.Skills.Any(s => s.Level >= 8)
                        select new Developer
                        {
                            FirstName = dev.FirstName,
                            LastName = dev.LastName,
                            Age = dev.Age,
                            Skills = dev.Skills.Where(s => dev.Skills.Where(sk => sk.Level >= 8).Select(sk => sk.Type).Contains(s.Type)).ToList()
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}