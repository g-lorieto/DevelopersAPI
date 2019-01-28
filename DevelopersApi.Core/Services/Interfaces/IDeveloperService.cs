using DevelopersApi.Core.Services.Interfaces.Generic;
using DevelopersApi.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Services.Interfaces
{
    public interface IDevelopersService
    {
        IAsyncService<Developer> GenericService { get; set; }

        Task<ICollection<Developer>> GetSkilledAsync();
    }
}