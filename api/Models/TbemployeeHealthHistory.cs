using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeHealthHistory
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string FilePath { get; set; }
        public DateTime? DateLog { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
