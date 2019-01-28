using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopersApi.Core.Services.Interfaces.Generic;
using DevelopersApi.Core.Services.Interfaces;
using DevelopersApi.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IAsyncService<Developer> _service;

        private readonly IDevelopersService _developersService;

        public DevelopersController(IAsyncService<Developer> service, IDevelopersService developersService)
        {
            _service = service;
            _developersService = developersService;
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
            return await _developersService.GetSkilledAsync();
        }
    }
}
