using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeWorkingPeriod
    {
        public string Id { get; set; }
        public string WorkingPeriod { get; set; }
        public string FpUserId { get; set; }

        public virtual Tbworkingperiod WorkingPeriodNavigation { get; set; }
    }
}
