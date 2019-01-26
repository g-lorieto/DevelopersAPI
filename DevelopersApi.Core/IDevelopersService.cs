using DevelopersApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core
{
    public interface IDevelopersService
    {
        Task<ICollection<Developer>> GetAllAsync();
        Task<ICollection<Developer>> GetSkilledAsync();
    }
}
