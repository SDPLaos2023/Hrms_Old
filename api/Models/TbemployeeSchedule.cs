using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeSchedule
    {
        public string Id { get; set; }
        public string Shift { get; set; }
        public string FpUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tbshiftmanagement ShiftNavigation { get; set; }
    }
}
