using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbtimeAssigment
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Timetable { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
