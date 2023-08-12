using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbfingerprintmapping
    {
        public string Id { get; set; }
        public string FingerUserId { get; set; }
        public string FingerIndex { get; set; }
        public string FingerImg { get; set; }
        public string Status { get; set; }
    }
}
