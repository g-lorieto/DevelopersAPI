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
        private readonly string _jsonFilePath;

        public JSONDataSource(AppSettingsModel settings)
        {            
            _jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.JSONFIle);            
        }

        public async Task<ICollection<Developer>> GetAllAsync()
        {
            var json = await File.ReadAllTextAsync(_jsonFilePath);

            return JsonConvert.DeserializeObject<ICollection<Developer>>(json);            
        }
    }
}
