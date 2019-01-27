using DevelopersApi.Infrastructure.Interfaces;
using DevelopersApi.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Developers
{    
    public class DevelopersService : IDevelopersService
    {
        private IDataSource _dataSource;

        public DevelopersService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<ICollection<Developer>> GetAllAsync()
        {            
            return _dataSource.GetAllAsync().ToList();
        }

        public async Task<ICollection<Developer>> GetSkilledAsync()
        {
            try
            {
                ICollection<Developer> developers = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(@"http://localhost:50754");

                    var response = await client.GetAsync("/api/Developers/GetAllAsync");

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
