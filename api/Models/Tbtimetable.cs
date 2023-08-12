using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbtimetable
    {
        public Tbtimetable()
        {
            Tbshiftdetails = new HashSet<Tbshiftdetail>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public TimeSpan? StartIn { get; set; }
        public TimeSpan? BreakOut { get; set; }
        public TimeSpan? BreakIn { get; set; }
        public TimeSpan? StartOut { get; set; }
        public int? LateIn { get; set; }
        public int? EarlyOut { get; set; }
        public string DayOfWeek { get; set; }
        public string Status { get; set; }
        public TimeSpan? LateAt { get; set; }
        public TimeSpan? EarlyOutAt { get; set; }
        public int? WorkingHourRatio { get; set; }
        public string Company { get; set; }

        public virtual Tbcompany CompanyNavigation { get; set; }
        public virtual ICollection<Tbshiftdetail> Tbshiftdetails { get; set; }
    }
}
