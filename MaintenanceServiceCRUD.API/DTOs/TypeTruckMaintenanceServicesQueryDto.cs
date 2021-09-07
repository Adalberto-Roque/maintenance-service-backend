using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.DTOs
{
    public class TypeTruckMaintenanceServicesQueryDto
    {
        public byte IdTypeTruckMaintenanceService { get; set; }
        public string TypeDescription { get; set; }
    }
}
