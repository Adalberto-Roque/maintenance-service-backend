using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaintenanceServiceCRUD.DAL.Models;
using MaintenanceServiceCRUD.API.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MaintenanceServiceCRUD.API.Helpers;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace MaintenanceServiceCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckMaintenanceServicesController : ControllerBase
    {
        private readonly ContextDb _contextDb;
        private readonly IMapper _mapper;
        private readonly ILogger<TruckMaintenanceServicesController> _logger;
        private readonly IMemoryCache _memoryCache;

        public TruckMaintenanceServicesController(ContextDb contextDb, IMapper mapper,
            ILogger<TruckMaintenanceServicesController> logger,
            IMemoryCache memoryCache)
        {
            _contextDb = contextDb;
            _mapper = mapper;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetTruckMaintenanceServices([FromQuery] FilterCommon filterCommon)
        {
            var result =  _contextDb.TruckMaintenanceServices
                .Include(e => e.DriverNavigation)
                .Include(e => e.DispatcherNavigation)
                .Include(e => e.MechanicalNavigation)
                .Include(e => e.IdTruckNavigation)
                .Include(e => e.IdTypeTruckMaintenanceServiceNavigation)
                .OrderByDescending(e => e.IdTruckMaintenanceServices) 
                .AsQueryable();

            #region Filters
            if (!string.IsNullOrEmpty(filterCommon.Filter))
            {
                var value = filterCommon.Filter.ToLower();
                result = result.Where(e => e.IdTruckNavigation.Number.Contains(value));
            }
            
            PagedResult<TruckMaintenanceService> resultPaged = new PagedResult<TruckMaintenanceService>();
            if (filterCommon.PageSize != 0)
                resultPaged = result.PageResult(filterCommon.Page, filterCommon.PageSize);
            else
                resultPaged.Queryable = result;
            #endregion
            Response.Headers.Add("x-rows-count", resultPaged.RowCount.ToString());

            var response = _mapper.Map<List<TruckMaintenanceServiceDto>>(await resultPaged.Queryable.ToListAsync());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruckMaintenanceService(int Id)
        {
            var entity = await _contextDb.TruckMaintenanceServices.FirstOrDefaultAsync(e => e.IdTruckMaintenanceServices == Id);
            var response = _mapper.Map<TruckMaintenanceServiceInsertDto>(entity);

            return Ok(response);
        }

        [HttpGet("catalog/types")]
        public async Task<IActionResult> GetTypesTruckMaintenanceServices()
        {
            if (_memoryCache.TryGetValue("types", out List<TypeTruckMaintenanceServicesQueryDto> types))
                return Ok(types);

            var result = await _contextDb.TypeTruckMaintenanceServices.ToListAsync();

            types = _mapper.Map<List<TypeTruckMaintenanceServicesQueryDto>>(result);
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(2) };
            _memoryCache.Set("types", types, options);

            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> PostTruckMaintenanceService([FromBody] TruckMaintenanceServiceInsertDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var entity = _mapper.Map<TruckMaintenanceService>(dto);

            _contextDb.TruckMaintenanceServices.Add(entity);

            try
            {
                await _contextDb.SaveChangesAsync();

                _logger.LogInformation("Se insertó correctame el mantenimineto con Id: {0}", entity.IdTruckMaintenanceServices);
                return Ok();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un erro al insertar un mantenimiento de tractor");
                return BadRequest("Ocurrio un erro al insertar un mantenimiento de tractor");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruckMaintenanceService(int id, [FromBody] TruckMaintenanceServiceInsertDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var entity = _mapper.Map<TruckMaintenanceService>(dto);
            entity.IdTruckMaintenanceServices = id;
            _contextDb.Entry(entity).State = EntityState.Modified;

            try
            {
                await _contextDb.SaveChangesAsync();

                _logger.LogInformation("Se actualizó correctame el mantenimineto con Id: {0}", entity.IdTruckMaintenanceServices);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrio un erro al actualizar el mantenimiento de tractor {0}", id);
                return BadRequest("Ocurrio un erro al actualizar el mantenimiento de tractor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruckMaintenanceService(int id)
        {
            var entity = await _contextDb.TruckMaintenanceServices.FirstOrDefaultAsync(e => e.IdTruckMaintenanceServices == id);

            try
            {
                _contextDb.Remove(entity);

                await _contextDb.SaveChangesAsync();

                _logger.LogInformation("Se eliminó el folio {0}", id);

                return NoContent();
            }catch(Exception ex)
            {
                _logger.LogInformation("Ocurrio un erro al eliminar el folio {0}", id);
                return BadRequest("Ocurrio un erro al eliminar el folio");
            }
  
        }
    }
}
