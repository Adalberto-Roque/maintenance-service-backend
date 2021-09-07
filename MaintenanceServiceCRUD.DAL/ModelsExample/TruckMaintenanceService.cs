using System;
using System.Collections.Generic;

#nullable disable

namespace MaintenanceServiceCRUD.DAL.Models
{
    public partial class TruckMaintenanceService
    {
        public int IdTruckMaintenanceServices { get; set; }
        public short IdTruck { get; set; }
        public byte IdTypeTruckMaintenanceService { get; set; }
        public short Driver { get; set; }
        public short Dispatcher { get; set; }
        public DateTime DueDate { get; set; }
        public short Mechanical { get; set; }

        public virtual Employee DispatcherNavigation { get; set; }
        public virtual Employee DriverNavigation { get; set; }
        public virtual Truck IdTruckNavigation { get; set; }
        public virtual TypeTruckMaintenanceService IdTypeTruckMaintenanceServiceNavigation { get; set; }
        public virtual Employee MechanicalNavigation { get; set; }
    }
}
