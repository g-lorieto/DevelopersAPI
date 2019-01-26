using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopersApi.Core;
using DevelopersApi.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDevelopersService _service;

        public DevelopersController(IDevelopersService service)
        {
            _service = service;
        }

        // GET: api/Developers
        [HttpGet]
        public async Task<ICollection<Developer>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Developers
        [HttpGet]
        public async Task<ICollection<Developer>> GetSkilledAsync()
        {
            return await _service.GetSkilledAsync();
        }


    }
}
