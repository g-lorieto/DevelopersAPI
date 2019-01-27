using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevelopersApi.Infrastructure.Models;
using DevelopersApi.Infrastructure.Interfaces;
using Newtonsoft.Json;

namespace DevelopersApi.Infrastructure.DataSources
{
    public class JSONDataSource : IDataSource
    {
        private readonly string _jsonFile;

        private readonly ICollection<Developer> _collection;

        public JSONDataSource()
        {
            _jsonFile = @"E:\repos\DevelopersAPI\DevelopersApi.Core\developers.json";
            _collection = JsonConvert.DeserializeObject<ICollection<Developer>>(File.ReadAllTextAsync(_jsonFile).Result);
        }

        public IQueryable<Developer> GetAllAsync()
        {
            return _collection.AsQueryable();
        }
    }
}
