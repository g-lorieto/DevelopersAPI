using DevelopersApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Services.Interfaces.Generic
{
    public interface IAsyncService<T> where T : class
    {        
        Task<ICollection<T>> GetAllAsync();        
    }
}
