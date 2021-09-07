using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.Helpers
{
    public class FilterCommon
    {
        public string Filter { get; set; }

        public string OrderBy { get; set; }

        public bool Ascending { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
