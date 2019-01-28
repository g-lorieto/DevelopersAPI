using DevelopersApi.Core.Interfaces.Generics;
using DevelopersApi.Core.Interfaces;
using DevelopersApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DevelopersApi.Core.Services
{
    public class GenericService : IAsyncService<Developer>
    {
        private IDataSource _dataSource;

        public GenericService(IDataSource dataSource)
        {
            _dataSource = dataSource;            
        }

        public async Task<ICollection<Developer>> GetAllAsync()
        {
            return await _dataSource.GetAllAsync();
        }
    }
}
