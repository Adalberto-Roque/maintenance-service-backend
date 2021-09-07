using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.DTOs
{
    public class TruckMaintenanceServiceInsertDto
    {
        public short IdTruck { get; set; }
        public byte IdTypeTruckMaintenanceService { get; set; }
        public short Driver { get; set; }
        public short Dispatcher { get; set; }
        public DateTime DueDate { get; set; }
        public short Mechanical { get; set; }
    }
}
