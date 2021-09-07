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
    public class EmployeesController : ControllerBase
    {
        private readonly ContextDb _contextDb;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public EmployeesController(ContextDb contextDb,
            IMemoryCache memoryCache, IMapper mapper)
        {
            _contextDb = contextDb;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrucks()
        {
            if (_memoryCache.TryGetValue("employees", out List<EmployeeQueryDto> employees))
                return Ok(employees);

            var result = await _contextDb.Employees.ToListAsync();

            employees = _mapper.Map<List<EmployeeQueryDto>>(result);
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(2) };
            _memoryCache.Set("employees", employees, options);

            return Ok(employees);
        }
    }
}
