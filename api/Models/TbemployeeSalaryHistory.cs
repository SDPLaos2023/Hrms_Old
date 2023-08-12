using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeSalaryHistory
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public float? Salary { get; set; }
        public string Contract { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
