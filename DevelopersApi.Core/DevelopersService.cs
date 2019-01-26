using DevelopersApi.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core
{    
    public class DevelopersService : IDevelopersService
    {
        private string json = File.ReadAllText(@"E:\repos\DevelopersAPI\DevelopersApi.Core\developers.json");

        public async Task<ICollection<Developer>> GetAllAsync()
        {
            return JsonConvert.DeserializeObject<ICollection<Developer>>(json);
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

                return from dev in developers
                       where dev.)
            }
            catch (Exception ex)
            {

                throw;
            }
        }        
    }
}
