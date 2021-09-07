using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.DTOs
{
    public class VehicleQueryDto
    {
        public short IdTruck { get; set; }
        public string Number { get; set; }
        public string LicensePlate { get; set; }
    }
}
