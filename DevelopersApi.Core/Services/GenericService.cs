using DevelopersApi.Core.Services.Interfaces.Generic;
using DevelopersApi.Infrastructure.Interfaces;
using DevelopersApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Services
{
    public class GenericService : IAsyncService<Developer>
    {
        private IDataSource _dataSource;

        public GenericService(IDataSource dataSource)
        {
            _dataSource = dataSource;            
        }

        public Task<ICollection<Developer>> GetAllAsync()
        {
            return _dataSource.GetAllAsync();
        }
    }
}
