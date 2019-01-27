using DevelopersApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopersApi.Infrastructure.Interfaces
{
    public interface IDataSource
    {
        IQueryable<Developer> GetAllAsync();
    }
}
