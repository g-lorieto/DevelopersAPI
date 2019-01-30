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

namespace DevelopersApi.DataAccess.DataSources
{
    public class JSONDataSource : IDataSource
    {
        private readonly string _jsonPath;

        private readonly ICollection<Developer> _collection;

        public JSONDataSource(AppSettingsModel settings)
        {
            _jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.JSONFIle);
        }

        public async Task<ICollection<Developer>> GetAllAsync()
        {
            var collection = JsonConvert.DeserializeObject<ICollection<Developer>>(await File.ReadAllTextAsync(_jsonPath));

            return collection;
        }
    }
}
