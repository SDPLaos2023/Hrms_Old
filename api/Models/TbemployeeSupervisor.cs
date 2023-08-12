using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeSupervisor
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Supervisor { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual Tbemployee SupervisorNavigation { get; set; }
    }
}
