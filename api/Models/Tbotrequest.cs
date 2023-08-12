using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbotrequest
    {
        public string Id { get; set; }
        public DateTime? OtDate { get; set; }
        public TimeSpan? OtIn { get; set; }
        public TimeSpan? OtOut { get; set; }
        public string AuthorizerId { get; set; }
        public string Employee { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
    }
}
