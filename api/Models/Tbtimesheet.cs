using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbtimesheet
    {
        public string Id { get; set; }
        public DateTime? AttDate { get; set; }
        public TimeSpan? ClockIn { get; set; }
        public TimeSpan? ClockOut { get; set; }
        public TimeSpan? RawIn { get; set; }
        public TimeSpan? RawOut { get; set; }
        public string Remark { get; set; }
        public string Employee { get; set; }
        public int? LateMin { get; set; }
        public int? EarlyMin { get; set; }
        public string ClockStatus { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
