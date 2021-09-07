using System;
using System.Collections.Generic;

#nullable disable

namespace MaintenanceServiceCRUD.DAL.Models
{
    public partial class Job
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
        }

        public short IdJob { get; set; }
        public string JobDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
