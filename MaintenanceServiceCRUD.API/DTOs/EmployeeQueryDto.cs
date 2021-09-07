using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.DTOs
{
    public class EmployeeQueryDto
    {
        public short IdEmployee { get; set; }
        public short IdJob { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public short? IdTruck { get; set; }
    }
}
