using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevelopersApi.Core.Models;
using DevelopersApi.Core.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DevelopersApi.Core.Settings;
using Microsoft.Extensions.Options;

namespace DevelopersApi.DataAccess.DataSources
{
    public class JSONDataSource : IDataSource
    {
        private readonly string _jsonPath;

        private readonly ICollection<Developer> _collection;

        public JSONDataSource(IOptions<AppSettingsModel> settings)
        {
            _jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.Value.JSONFIle);
        }

        public async Task<ICollection<Developer>> GetAllAsync()
        {
            var collection = JsonConvert.DeserializeObject<ICollection<Developer>>(await File.ReadAllTextAsync(_jsonPath));

            return collection;
        }
    }
}
