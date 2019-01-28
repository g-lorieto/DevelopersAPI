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
        private readonly AppSettingsModel _settings;

        private readonly ICollection<Developer> _collection;

        public JSONDataSource(AppSettingsModel settings)
        {
            _settings = settings;
            _collection = JsonConvert.DeserializeObject<ICollection<Developer>>(File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settings.JSONFIle)).Result);
        }

        public Task<ICollection<Developer>> GetAllAsync()
        {
            var fakeTask = Task.FromResult(_collection);
            fakeTask.Wait();
            return fakeTask;
        }
    }
}
