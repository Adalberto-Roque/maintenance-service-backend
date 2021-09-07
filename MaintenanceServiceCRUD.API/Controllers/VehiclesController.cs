using AutoMapper;
using MaintenanceServiceCRUD.API.DTOs;
using MaintenanceServiceCRUD.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ContextDb _contextDb;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public VehiclesController(ContextDb contextDb,
            IMemoryCache memoryCache, IMapper mapper)
        {
            _contextDb = contextDb;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        [HttpGet("trucks")]
        public async Task<IActionResult> GetTrucks()
        {
            if (_memoryCache.TryGetValue("trucks", out List<VehicleQueryDto> vehicles))
                return Ok(vehicles);

            var result = await _contextDb.Trucks.ToListAsync();

            vehicles = _mapper.Map<List<VehicleQueryDto>>(result);
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(2) };
            _memoryCache.Set("trucks", vehicles, options);

            return Ok(vehicles);
        }
    }
}
