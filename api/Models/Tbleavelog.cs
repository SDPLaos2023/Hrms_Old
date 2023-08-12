using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbleavelog
    {
        public string Id { get; set; }
        public DateTime? LeaveDay { get; set; }
        public string LeaveId { get; set; }
        public string FpUserId { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
    }
}
