using System;
using System.Collections.Generic;

#nullable disable

namespace MaintenanceServiceCRUD.DAL.Models
{
    public partial class Employee
    {
        public Employee()
        {
            TruckMaintenanceServiceDispatcherNavigations = new HashSet<TruckMaintenanceService>();
            TruckMaintenanceServiceDriverNavigations = new HashSet<TruckMaintenanceService>();
            TruckMaintenanceServiceMechanicalNavigations = new HashSet<TruckMaintenanceService>();
        }

        public short IdEmployee { get; set; }
        public short IdJob { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public short? IdTruck { get; set; }

        public virtual Job IdJobNavigation { get; set; }
        public virtual Truck IdTruckNavigation { get; set; }
        public virtual ICollection<TruckMaintenanceService> TruckMaintenanceServiceDispatcherNavigations { get; set; }
        public virtual ICollection<TruckMaintenanceService> TruckMaintenanceServiceDriverNavigations { get; set; }
        public virtual ICollection<TruckMaintenanceService> TruckMaintenanceServiceMechanicalNavigations { get; set; }
    }
}
