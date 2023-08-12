using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbattlog
    {
        public string Id { get; set; }
        public string FpId { get; set; }
        public DateTime? AttDate { get; set; }
        public TimeSpan? AttTime { get; set; }
        public string AttCode { get; set; }
        public string FpUserId { get; set; }

        public virtual Tbfingerprint Fp { get; set; }
    }
}
