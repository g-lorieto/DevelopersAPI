using DevelopersApi.Core.Interfaces.Generics;
using DevelopersApi.Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Interfaces
{
    public interface IDevelopersService
    {        
        IAsyncService<Developer> GenericService { get; set; }

        Task<ICollection<Developer>> GetSkilledAsync();
    }
}