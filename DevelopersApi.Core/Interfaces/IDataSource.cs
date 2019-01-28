using DevelopersApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersApi.Core.Interfaces
{
    public interface IDataSource
    {
        Task<ICollection<Developer>> GetAllAsync();
    }
}
