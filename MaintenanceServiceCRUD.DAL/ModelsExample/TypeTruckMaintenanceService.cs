using System;
using System.Collections.Generic;

#nullable disable

namespace MaintenanceServiceCRUD.DAL.Models
{
    public partial class TypeTruckMaintenanceService
    {
        public TypeTruckMaintenanceService()
        {
            TruckMaintenanceServices = new HashSet<TruckMaintenanceService>();
        }

        public byte IdTypeTruckMaintenanceService { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<TruckMaintenanceService> TruckMaintenanceServices { get; set; }
    }
}
