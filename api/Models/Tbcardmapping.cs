using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbcardmapping
    {
        public string Id { get; set; }
        public string FpId { get; set; }
        public string CardNumber { get; set; }
        public string Employee { get; set; }
        public string Status { get; set; }
    }
}
