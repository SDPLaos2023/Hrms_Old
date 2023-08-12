using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeAllowance
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Allowance { get; set; }
        public float? Rate { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tballowance AllowanceNavigation { get; set; }
        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
