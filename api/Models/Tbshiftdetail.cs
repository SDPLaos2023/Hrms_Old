using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbshiftdetail
    {
        public string Id { get; set; }
        public string Shift { get; set; }
        public int? Weekday { get; set; }
        public string Timetable { get; set; }

        public virtual Tbshiftmanagement ShiftNavigation { get; set; }
        public virtual Tbtimetable TimetableNavigation { get; set; }
    }
}
