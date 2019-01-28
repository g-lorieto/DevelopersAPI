using DevelopersApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Interfaces.Generics
{
    public interface IAsyncService<T> where T : class
    {        
        Task<ICollection<T>> GetAllAsync();        
    }
}
