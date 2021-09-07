using System;
using System.Collections.Generic;

#nullable disable

namespace MaintenanceServiceCRUD.DAL.Models
{
    public partial class Truck
    {
        public Truck()
        {
            Employees = new HashSet<Employee>();
            TruckMaintenanceServices = new HashSet<TruckMaintenanceService>();
        }

        public short IdTruck { get; set; }
        public string Number { get; set; }
        public string LicensePlate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<TruckMaintenanceService> TruckMaintenanceServices { get; set; }
    }
}
