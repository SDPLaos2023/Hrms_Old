using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeLeaveSetting
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string EmployeeAnnualLeave { get; set; }
        public int? Ratio { get; set; }
        public int? Remain { get; set; }

        public virtual TbannualLeaveType EmployeeAnnualLeaveNavigation { get; set; }
        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
