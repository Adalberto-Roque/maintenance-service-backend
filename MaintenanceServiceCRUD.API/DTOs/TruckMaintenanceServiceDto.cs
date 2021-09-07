using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.DTOs
{
    public class TruckMaintenanceServiceDto
    {
        public int IdTruckMaintenanceServices { get; set; }
        public string Truck { get; set; }
        public string Type { get; set; }
        public string Driver { get; set; }
        public string Dispatcher { get; set; }
        public DateTime DueDate { get; set; }
        public string Mechanical { get; set; }
    }
}
