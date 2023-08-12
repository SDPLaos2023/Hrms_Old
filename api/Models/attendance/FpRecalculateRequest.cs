using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.attendance
{
    public class FpRecalculateRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string FpUserId { get; set; }
    }
}
