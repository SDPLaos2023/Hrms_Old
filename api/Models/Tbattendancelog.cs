using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbattendancelog
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public DateTime? AttDate { get; set; }
        public TimeSpan? AttTime { get; set; }
        public string Status { get; set; }
        public string FpId { get; set; }
        public string FpUserId { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual Tbfingerprint Fp { get; set; }
    }
}
