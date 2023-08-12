using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbworkingperiod
    {
        public Tbworkingperiod()
        {
            TbemployeeWorkingPeriods = new HashSet<TbemployeeWorkingPeriod>();
        }

        public string Id { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public int? Total { get; set; }
        public int? WorkingHrs { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; }

        public virtual ICollection<TbemployeeWorkingPeriod> TbemployeeWorkingPeriods { get; set; }
    }
}
